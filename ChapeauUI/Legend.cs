using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class Legend : Form
    {
        private int cornerRadius = 30;
        public Legend()
        {
            InitializeComponent();
            SetRoundedRegion();
            DisableButtons();
        }
        private void SetRoundedRegion()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(this.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(this.Width - cornerRadius, this.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, this.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
            this.Invalidate();
        }

        private void DisableButtons()
        {
            ReserveTableDeactivatedBtn.Enabled = false;
            OpenLegendDeactivatedBtn.Enabled = false;
            LogOutDeactivatedBtn.Enabled = false;
        }

        private void Legend_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
