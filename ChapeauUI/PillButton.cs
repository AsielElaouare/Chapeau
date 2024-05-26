using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ChapeauUI
{
    
    public class PillButton : Button
    {
        public PillButton()
        {
            
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.DoubleBuffered = true;
            this.Size = new Size(272, 38);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            int cornerRadius = Height / 2; 
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius * 2, cornerRadius * 2, 90, 180);
            path.AddArc(Width - cornerRadius * 2, 0, cornerRadius * 2, cornerRadius * 2, 270, 180);
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
            TextRenderer.DrawText(pevent.Graphics, Text, Font, ClientRectangle, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }

}
