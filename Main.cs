using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BlueBox
{
    public partial class Main : Form
    {
        // ====================================================================
        // --- CONFIGURATION AREA ---
        // ====================================================================
        private readonly Color _activeBorderColor = Color.DeepSkyBlue;
        private readonly Color _inactiveBorderColor = Color.FromArgb(255, 64, 64, 64); // Dark Gray
        private readonly int _borderThickness = 3; // In pixels
        // ====================================================================

        private Win32Api.WinEventDelegate _winEventDelegate;
        private Win32Api.WinEventDelegate _foregroundEventDelegate; // For focus tracking
        private IntPtr _winEventHook;
        private IntPtr _foregroundEventHook; // For focus tracking

        private Dictionary<IntPtr, OutlineForm> _activeOutlines = new Dictionary<IntPtr, OutlineForm>();
        private HashSet<IntPtr> _excludedWindows = new HashSet<IntPtr>();
        private readonly object _lock = new object();

        public Main()
        {
            InitializeComponent();
            _winEventDelegate = new Win32Api.WinEventDelegate(WinEventProc);
            _foregroundEventDelegate = new Win32Api.WinEventDelegate(ForegroundWinEventProc); // New delegate
            SetupNotifyIcon();
        }

        #region Form Events
        private void Main_Load(object sender, EventArgs e)
        {
            // Hook for window creation, destruction, movement, etc.
            _winEventHook = Win32Api.SetWinEventHook(
                Win32Api.EVENT_OBJECT_CREATE, Win32Api.EVENT_OBJECT_LOCATIONCHANGE,
                IntPtr.Zero, _winEventDelegate, 0, 0, Win32Api.WINEVENT_OUTOFCONTEXT);

            // --- NEW ---
            // Hook specifically for tracking the active (foreground) window
            _foregroundEventHook = Win32Api.SetWinEventHook(
                0x0003, 0x0003, // EVENT_SYSTEM_FOREGROUND
                IntPtr.Zero, _foregroundEventDelegate, 0, 0, Win32Api.WINEVENT_OUTOFCONTEXT);

            RefreshWindowList();
            UpdateAllBorders(); // Update styles after initial load
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Win32Api.UnhookWinEvent(_winEventHook);
            Win32Api.UnhookWinEvent(_foregroundEventHook); // Unhook the new hook
            foreach (var outline in _activeOutlines.Values)
            {
                outline.Dispose();
            }
            notifyIcon.Dispose();
        }
        #endregion

        // --- All other form events (Resize, Button Clicks, etc.) remain the same ---
        #region Unchanged UI Events
        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshWindowList();
        }

        private void windowListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // This needs to be invoked to prevent UI lag while checking many items
            this.BeginInvoke((MethodInvoker)delegate
            {
                var item = e.Item;
                if (item.Tag is IntPtr hWnd)
                {
                    lock (_lock)
                    {
                        if (item.Checked)
                        {
                            _excludedWindows.Remove(hWnd);
                            if (IsManageableWindow(hWnd)) AddOutline(hWnd);
                        }
                        else
                        {
                            _excludedWindows.Add(hWnd);
                            RemoveOutline(hWnd);
                        }
                    }
                    UpdateAllBorders();
                }
            });
        }
        #endregion

        #region Window Management
        // This handles window create, destroy, move, and resize events
        private void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hWnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            if (idObject != 0 || idChild != 0) return;

            this.BeginInvoke((MethodInvoker)delegate
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
                        UpdateOutline(hWnd);
                        break;
                }
            });
        }

        // --- NEW METHOD ---
        // This handles ONLY the foreground changed event
        private void ForegroundWinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hWnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            // Event 0x0003 is EVENT_SYSTEM_FOREGROUND
            if (eventType == 0x0003)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    UpdateAllBorders();
                });
            }
        }

        private void AddOutline(IntPtr hWnd)
        {
            lock (_lock)
            {
                if (_excludedWindows.Contains(hWnd)) return;
            }

            if (!_activeOutlines.ContainsKey(hWnd))
            {
                var outline = new OutlineForm();
                _activeOutlines[hWnd] = outline;
                UpdateOutline(hWnd); // Will also set style
            }
            UpdateAllBorders();
        }

        private void RemoveOutline(IntPtr hWnd)
        {
            if (_activeOutlines.TryGetValue(hWnd, out OutlineForm outline))
            {
                outline.Hide();
                outline.Dispose();
                _activeOutlines.Remove(hWnd);
            }
        }

        private void UpdateOutline(IntPtr hWnd)
        {
            if (_activeOutlines.TryGetValue(hWnd, out OutlineForm outline))
            {
                outline.SetTarget(hWnd);
            }
        }

        // --- NEW METHOD ---
        // Updates the colors of all borders based on which window is active
        private void UpdateAllBorders()
        {
            IntPtr foregroundHwnd = GetForegroundWindow();
            foreach (var pair in _activeOutlines)
            {
                var hWnd = pair.Key;
                var outline = pair.Value;
                if (hWnd == foregroundHwnd)
                {
                    outline.SetStyle(_activeBorderColor, _borderThickness);
                }
                else
                {
                    outline.SetStyle(_inactiveBorderColor, _borderThickness);
                }
            }
        }

        // --- MODIFIED METHOD ---
        // Now creates the initial borders
        private void RefreshWindowList()
        {
            windowListView.ItemChecked -= windowListView_ItemChecked; // Prevent event from firing during refresh
            windowListView.Items.Clear();
            var currentWindows = new HashSet<IntPtr>();

            Win32Api.EnumWindows((hWnd, lParam) =>
            {
                if (IsManageableWindow(hWnd))
                {
                    currentWindows.Add(hWnd); // Keep track of current windows
                    StringBuilder titleBuilder = new StringBuilder(256);
                    Win32Api.GetWindowText(hWnd, titleBuilder, titleBuilder.Capacity);
                    var item = new ListViewItem(titleBuilder.ToString()) { Tag = hWnd };
                    lock (_lock)
                    {
                        item.Checked = !_excludedWindows.Contains(hWnd);
                    }
                    windowListView.Items.Add(item);

                    // --- SOLUTION #1 ---
                    // If it's checked, ensure an outline exists for it
                    if (item.Checked)
                    {
                        AddOutline(hWnd);
                    }
                }
                return true;
            }, IntPtr.Zero);

            // Clean up outlines for windows that no longer exist
            var closedWindows = new List<IntPtr>();
            foreach (var hWnd in _activeOutlines.Keys)
            {
                if (!currentWindows.Contains(hWnd))
                {
                    closedWindows.Add(hWnd);
                }
            }
            foreach (var hWnd in closedWindows)
            {
                RemoveOutline(hWnd);
            }

            windowListView.ItemChecked += windowListView_ItemChecked; // Re-enable event
        }
        #endregion

        #region Unchanged Helper Methods
        private bool IsManageableWindow(IntPtr hWnd)
        {
            if (!Win32Api.IsWindowVisible(hWnd) || Win32Api.GetWindowTextLength(hWnd) == 0 || hWnd == Win32Api.GetShellWindow())
                return false;

            Win32Api.DwmGetWindowAttribute(hWnd, Win32Api.DWMWA_CLOAKED, out bool isCloaked, Marshal.SizeOf<bool>());
            if (isCloaked) return false;

            int exStyle = Win32Api.GetWindowLong(hWnd, Win32Api.GWL_EXSTYLE);
            if ((exStyle & Win32Api.WS_EX_TOOLWINDOW) != 0) return false;

            return true;
        }

        private void SetupNotifyIcon()
        {
            notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.Add("Show Settings", null, (s, e) => notifyIcon_MouseDoubleClick(s, null));
            notifyIcon.ContextMenuStrip.Items.Add("Exit", null, (s, e) => Application.Exit());
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        #endregion
    }
}