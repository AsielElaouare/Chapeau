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
    public class BottomRoundedButton :Button
    {
        private int cornerRadius = 20;
        public BottomRoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
        }


        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            // Create a path for the button's shape
            GraphicsPath path = new GraphicsPath();
            path.AddLine(0, 0, Width, 0);
            path.AddLine(Width, 0, Width, Height - cornerRadius);
            path.AddArc(Width - cornerRadius * 2, Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            path.AddLine(Width - cornerRadius, Height, cornerRadius, Height);
            path.AddArc(0, Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            path.AddLine(0, Height - cornerRadius, 0, 0);
            path.CloseFigure();

            this.Region = new Region(path);

            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                pevent.Graphics.FillPath(brush, path);
            }
        }
    }
}
