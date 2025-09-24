using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BlueBox
{
    public partial class OutlineForm : Form
    {
        private int _outlineThickness = 2; // Default thickness
        private Color _outlineColor = Color.DeepSkyBlue;

        public OutlineForm(IntPtr targetHwnd)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = Color.Magenta;
            this.TransparencyKey = this.BackColor;
            Win32Api.SetWindowLong(this.Handle, Win32Api.GWL_HWNDPARENT, targetHwnd.ToInt32());
        }

        protected override bool ShowWithoutActivation => true;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= Win32Api.WS_EX_LAYERED | Win32Api.WS_EX_TRANSPARENT | Win32Api.WS_EX_NOACTIVATE | Win32Api.WS_EX_TOOLWINDOW;
                return cp;
            }
        }

        public void SetStyle(Color color, int thickness)
        {
            if (_outlineColor != color || _outlineThickness != thickness)
            {
                _outlineColor = color;
                _outlineThickness = thickness;
                this.Invalidate();
            }
        }

        public void SetTarget(IntPtr targetHwnd, int gap, int thickness)
        {
            // --- THE GAP FIX ---
            // First, try to get the accurate DWM frame rectangle.
            int result = Win32Api.DwmGetWindowAttribute(targetHwnd, Win32Api.DWMWA_EXTENDED_FRAME_BOUNDS, out Win32Api.RECT rect, Marshal.SizeOf<Win32Api.RECT>());

            // If DWM fails (e.g., on old OS or non-DWM window), fall back to the old method.
            if (result != 0)
            {
                Win32Api.GetWindowRect(targetHwnd, out rect);
            }

            if ((rect.Right - rect.Left) == 0)
            {
                this.Hide();
                return;
            }

            int newX = rect.Left - gap;
            int newY = rect.Top - gap;
            int newWidth = (rect.Right - rect.Left) + (2 * gap);
            int newHeight = (rect.Bottom - rect.Top) + (2 * gap);

            Win32Api.SetWindowPos(this.Handle, IntPtr.Zero, newX, newY, newWidth, newHeight, Win32Api.SWP_NOACTIVATE);

            if (!this.Visible)
            {
                this.Show();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // This drawing logic is more precise for different thicknesses.
            var pen = new Pen(_outlineColor, _outlineThickness);
            var rect = new Rectangle(0, 0, this.Width, this.Height);
            ControlPaint.DrawBorder(e.Graphics, rect, pen.Color, _outlineThickness, ButtonBorderStyle.Solid, pen.Color, _outlineThickness, ButtonBorderStyle.Solid, pen.Color, _outlineThickness, ButtonBorderStyle.Solid, pen.Color, _outlineThickness, ButtonBorderStyle.Solid);
            pen.Dispose();
        }
    }
}