using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ChapeauUI
{
    public class RoundShape : UserControl
    {
        public RoundShape()
        {
            this.Size = new Size(50, 50);
            this.BackColor = Color.FromArgb(0xD9, 0xD9, 0xD9);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath graphics = new GraphicsPath();
            graphics.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new Region(graphics);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(this.Parent.BackColor);

            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillEllipse(brush, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
            }

            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GraphicsPath graphics = new GraphicsPath();
            graphics.AddEllipse(0, 0, this.Width, this.Height);
            this.Region = new Region(graphics);
            Invalidate();
        }
    }
}
