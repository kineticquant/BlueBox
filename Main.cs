using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BlueBox
{
    public partial class Main : Form
    {
        private Win32Api.WinEventDelegate _winEventDelegate;
        private IntPtr _winEventHook;
        private Dictionary<IntPtr, OutlineForm> _activeOutlines = new Dictionary<IntPtr, OutlineForm>();
        private HashSet<IntPtr> _excludedWindows = new HashSet<IntPtr>();
        private readonly object _lock = new object();

        private System.Windows.Forms.Timer _uiUpdateTimer;
        private int _positionalTicksLeft;
        private int _fullRefreshTicksLeft;

        public Main()
        {
            InitializeComponent();
            _winEventDelegate = new Win32Api.WinEventDelegate(WinEventProc);
        }

        #region Form Events & UI Handlers
        private void Main_Load(object? sender, EventArgs e)
        {
            colorPreviewPanel.BackColor = Color.DeepSkyBlue;
            SetupNotifyIcon();
            SetupUiUpdateTimer();

            _winEventHook = Win32Api.SetWinEventHook(
                Win32Api.EVENT_OBJECT_CREATE, Win32Api.EVENT_OBJECT_LOCATIONCHANGE,
                IntPtr.Zero, _winEventDelegate, 0, 0, Win32Api.WINEVENT_OUTOFCONTEXT);

            if (_winEventHook == IntPtr.Zero)
            {
                MessageBox.Show("Failed to set up Windows event hook.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            RefreshAndApplyBorders();
        }

        private void Main_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_uiUpdateTimer != null) { _uiUpdateTimer.Stop(); _uiUpdateTimer.Dispose(); }
            if (_winEventHook != IntPtr.Zero) Win32Api.UnhookWinEvent(_winEventHook);

            foreach (var outline in _activeOutlines.Values)
            {
                outline.Dispose();
            }
            notifyIcon.Dispose();
        }

        private void refreshButton_Click(object? sender, EventArgs e) => RefreshAndApplyBorders();
        private void colorPreviewPanel_Click(object? sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    colorPreviewPanel.BackColor = colorDialog.Color;
                    UpdateAllBordersStyles();
                }
            }
        }

        private void thicknessNumericUpDown_ValueChanged(object? sender, EventArgs e) => UpdateAllBordersStyles();
        private void gapNumericUpDown_ValueChanged(object? sender, EventArgs e) => UpdateAllBordersStyles();
        private void positionalTimerNumericUpDown_ValueChanged(object? sender, EventArgs e) => _positionalTicksLeft = (int)positionalTimerNumericUpDown.Value;
        private void fullTimerNumericUpDown_ValueChanged(object? sender, EventArgs e) => _fullRefreshTicksLeft = (int)fullTimerNumericUpDown.Value * 60;
        #endregion

        #region Timer Setup and Event
        private void SetupUiUpdateTimer()
        {
            _positionalTicksLeft = (int)positionalTimerNumericUpDown.Value;
            _fullRefreshTicksLeft = (int)fullTimerNumericUpDown.Value * 60;
            _uiUpdateTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            _uiUpdateTimer.Tick += UiUpdateTimer_Tick;
            _uiUpdateTimer.Start();
        }

        private void UiUpdateTimer_Tick(object? sender, EventArgs e)
        {
            _positionalTicksLeft--;
            _fullRefreshTicksLeft--;

            if (_positionalTicksLeft <= 0)
            {
                UpdateAllBordersPositions();
                _positionalTicksLeft = (int)positionalTimerNumericUpDown.Value;
            }

            if (_fullRefreshTicksLeft <= 0)
            {
                RefreshAndApplyBorders();
                _fullRefreshTicksLeft = (int)fullTimerNumericUpDown.Value * 60;
            }

            positionalCountdownLabel.Text = $"({_positionalTicksLeft}s)";
            fullCountdownLabel.Text = $"({TimeSpan.FromSeconds(_fullRefreshTicksLeft):mm\\:ss})";
        }
        #endregion

        #region Window Management
        private void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hWnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            if (idObject != 0 || idChild != 0 || hWnd == IntPtr.Zero) return;
            this.BeginInvoke((MethodInvoker)(() => HandleWindowEvent(eventType, hWnd)));
        }

        private void HandleWindowEvent(uint eventType, IntPtr hWnd)
        {
            switch (eventType)
            {
                case Win32Api.EVENT_OBJECT_CREATE:
                case Win32Api.EVENT_OBJECT_SHOW:
                    if (IsManageableWindow(hWnd)) AddOutline(hWnd);
                    break;
                case Win32Api.EVENT_OBJECT_DESTROY:
                case Win32Api.EVENT_OBJECT_HIDE:
                    RemoveOutline(hWnd);
                    break;
                case Win32Api.EVENT_OBJECT_LOCATIONCHANGE:
                    UpdateOutlinePosition(hWnd);
                    break;
            }
        }

        private void AddOutline(IntPtr hWnd)
        {
            lock (_lock)
            {
                if (_excludedWindows.Contains(hWnd) || _activeOutlines.ContainsKey(hWnd)) return;
                var outline = new OutlineForm(hWnd);
                _activeOutlines[hWnd] = outline;
                UpdateOutlineStyle(outline);
                UpdateOutlinePosition(hWnd);
            }
        }

        private void RemoveOutline(IntPtr hWnd)
        {
            lock (_lock)
            {
                if (_activeOutlines.TryGetValue(hWnd, out OutlineForm outline))
                {
                    outline.Hide();
                    outline.Dispose();
                    _activeOutlines.Remove(hWnd);
                }
            }
        }

        private void UpdateOutlinePosition(IntPtr hWnd)
        {
            if (_activeOutlines.TryGetValue(hWnd, out OutlineForm outline))
            {
                var gap = (int)gapNumericUpDown.Value;
                var thickness = (int)thicknessNumericUpDown.Value;
                outline.SetTarget(hWnd, gap, thickness);
            }
        }

        private void UpdateOutlineStyle(OutlineForm outline)
        {
            var color = colorPreviewPanel.BackColor;
            var thickness = (int)thicknessNumericUpDown.Value;
            outline.SetStyle(color, thickness);
        }

       
        private void UpdateAllBordersPositions()
        {
            foreach (var hWnd in _activeOutlines.Keys)
            {
                UpdateOutlinePosition(hWnd);
            }
        }

        private void UpdateAllBordersStyles()
        {
            foreach (var pair in _activeOutlines)
            {
                UpdateOutlineStyle(pair.Value);
                UpdateOutlinePosition(pair.Key);
            }
        }

        private void RefreshAndApplyBorders()
        {
            windowListView.ItemChecked -= windowListView_ItemChecked;
            windowListView.Items.Clear();
            var currentWindows = new HashSet<IntPtr>();

            Win32Api.EnumWindows((hWnd, lParam) =>
            {
                if (IsManageableWindow(hWnd))
                {
                    currentWindows.Add(hWnd);
                    var title = GetWindowTitle(hWnd);
                    var item = new ListViewItem(title) { Tag = hWnd };
                    lock (_lock) { item.Checked = !_excludedWindows.Contains(hWnd); }
                    windowListView.Items.Add(item);
                    if (item.Checked) AddOutline(hWnd); else RemoveOutline(hWnd);
                }
                return true;
            }, IntPtr.Zero);

            var closedWindows = _activeOutlines.Keys.Where(hWnd => !currentWindows.Contains(hWnd)).ToList();
            foreach (var hWnd in closedWindows) RemoveOutline(hWnd);
            windowListView.ItemChecked += windowListView_ItemChecked;
        }
        #endregion

        #region Helper Methods & Unchanged UI
        private string GetWindowTitle(IntPtr hWnd)
        {
            int length = Win32Api.GetWindowTextLength(hWnd);
            if (length == 0) return "";
            StringBuilder builder = new StringBuilder(length + 1);
            Win32Api.GetWindowText(hWnd, builder, builder.Capacity);
            return builder.ToString();
        }

        private bool IsManageableWindow(IntPtr hWnd)
        {
            if (!Win32Api.IsWindowVisible(hWnd) || Win32Api.GetWindowTextLength(hWnd) == 0 || hWnd == Win32Api.GetShellWindow()) return false;
            Win32Api.DwmGetWindowAttribute(hWnd, Win32Api.DWMWA_CLOAKED, out bool isCloaked, Marshal.SizeOf<bool>());
            if (isCloaked) return false;
            int exStyle = Win32Api.GetWindowLong(hWnd, Win32Api.GWL_EXSTYLE);
            if ((exStyle & Win32Api.WS_EX_TOOLWINDOW) != 0) return false;
            return true;
        }

        private void SetupNotifyIcon()
        {
            notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.Add("Show Settings", null, (sender, e) => notifyIcon_MouseDoubleClick(sender, null));
            notifyIcon.ContextMenuStrip.Items.Add("Exit", null, (sender, e) => Application.Exit());
        }

        private void Main_Resize(object? sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) { this.Hide(); notifyIcon.Visible = true; }
        }

        private void notifyIcon_MouseDoubleClick(object? sender, MouseEventArgs? e)
        {
            this.Show(); this.WindowState = FormWindowState.Normal; this.Activate();
        }

        private void windowListView_ItemChecked(object? sender, ItemCheckedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                var item = e.Item;
                if (item.Tag is IntPtr hWnd)
                {
                    lock (_lock)
                    {
                        if (item.Checked) { _excludedWindows.Remove(hWnd); if (IsManageableWindow(hWnd)) AddOutline(hWnd); }
                        else { _excludedWindows.Add(hWnd); RemoveOutline(hWnd); }
                    }
                }
            });
        }
        #endregion
    }
}