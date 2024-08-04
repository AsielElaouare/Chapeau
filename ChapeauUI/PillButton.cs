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

            int imageWidth = Image != null ? Image.Width : 0;
            int imageHeight = Image != null ? Image.Height : 0;
            int textWidth = TextRenderer.MeasureText(Text, Font).Width;
            int padding = 20;

            int totalWidth = imageWidth + padding + textWidth;
            int imageX = (Width - totalWidth) / 2;
            int textX = imageX + imageWidth + padding;
            int centerY = (Height - Math.Max(imageHeight, Font.Height)) / 2;

            if (Image != null)
            {
                pevent.Graphics.DrawImage(Image, new Rectangle(imageX, centerY, imageWidth, imageHeight));
            }
            TextRenderer.DrawText(pevent.Graphics, Text, Font, ClientRectangle, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }

}
