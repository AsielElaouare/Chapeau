using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public class RoundButton : Button
    {

        public RoundButton()
        {
            this.FlatStyle = FlatStyle.Flat;   
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.FromArgb(0xD9, 0xD9, 0xD9);
            this.Size = new Size(50, 50);
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath graphics = new GraphicsPath();
            graphics.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(graphics);
            base.OnPaint(pevent);
        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GraphicsPath graphics = new GraphicsPath();
            graphics.AddEllipse(0, 0, this.Width, this.Height);
            this.Region = new System.Drawing.Region(graphics);
            Invalidate();  // Ensures the control is redrawn
        }
    }
}
