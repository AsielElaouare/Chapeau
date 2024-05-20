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
    public class BottomRightRoundedButton : Button
    {
        private int cornerRadius = 20;

        public BottomRightRoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            GraphicsPath path = new GraphicsPath();
            path.AddArc(ClientRectangle.Width - cornerRadius * 2, ClientRectangle.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            path.AddLine(ClientRectangle.Width - cornerRadius, ClientRectangle.Height, 0, ClientRectangle.Height);
            path.AddLine(0, ClientRectangle.Height, 0, 0);
            path.AddLine(0, 0, ClientRectangle.Width, 0);
            path.AddLine(ClientRectangle.Width, 0, ClientRectangle.Width, ClientRectangle.Height - cornerRadius);
            path.CloseFigure();
            this.Region = new Region(path);

            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                pevent.Graphics.FillPath(brush, path);
            }
        }
    }
}
