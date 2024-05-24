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
    public class BottomLeftRoundedButton : Button
    {
        private int cornerRadius = 20;
        private Image backgroundImage;
        public BottomLeftRoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
        }
        public new Image BackgroundImage
        {
            get { return backgroundImage; }
            set
            {
                backgroundImage = value;
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, ClientRectangle.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            path.AddLine(0, ClientRectangle.Height - cornerRadius, 0, 0);
            path.AddLine(0, 0, ClientRectangle.Width, 0);
            path.AddLine(ClientRectangle.Width, 0, ClientRectangle.Width, ClientRectangle.Height);
            path.AddLine(ClientRectangle.Width, ClientRectangle.Height, cornerRadius, ClientRectangle.Height);
            path.CloseFigure();
            this.Region = new Region(path);

            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                pevent.Graphics.FillPath(brush, path);
            }

            if (BackgroundImage != null)
            {
                int x = (Width - BackgroundImage.Width) / 2;
                int y = (Height - BackgroundImage.Height) / 2;
                pevent.Graphics.DrawImage(BackgroundImage, new Rectangle(x, y, BackgroundImage.Width, BackgroundImage.Height));
            }
        }
    }
}
