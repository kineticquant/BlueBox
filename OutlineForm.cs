using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlueBox
{
    public partial class OutlineForm : Form
    {
        private int _outlineThickness = 3;
        private Color _outlineColor = Color.DeepSkyBlue;

        public OutlineForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = Color.Magenta;
            this.TransparencyKey = this.BackColor;
        }

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
            this._outlineColor = color;
            this._outlineThickness = thickness;
            // bounds need to be recalculated if thickness changes
            if (this.IsHandleCreated && this.Visible)
            {
                this.Invalidate(); // redraw with the new color
            }
        }

        public void SetTarget(IntPtr targetHwnd)
        {
            if (!Win32Api.GetWindowRect(targetHwnd, out Win32Api.RECT rect) || (rect.Right - rect.Left) == 0)
            {
                this.Hide();
                return;
            }

            this.Bounds = new Rectangle(
                rect.Left - _outlineThickness,
                rect.Top - _outlineThickness,
                (rect.Right - rect.Left) + (2 * _outlineThickness),
                (rect.Bottom - rect.Top) + (2 * _outlineThickness)
            );

            if (!this.Visible)
            {
                // ensure top most window without activating it
                Win32Api.SetWindowPos(this.Handle, Win32Api.HWND_TOPMOST, 0, 0, 0, 0, Win32Api.SWP_NOACTIVATE);
                this.Show();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
         
            using (var pen = new Pen(_outlineColor, _outlineThickness * 2))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width, this.Height));
            }
        }
    }
}