using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class Legend : Form
    {
        public Legend()
        {
            InitializeComponent();
            DisableButtons();
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
