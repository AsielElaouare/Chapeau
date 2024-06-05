using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class ReservationForm : Form
    {
        string videoUrl = "https://youtu.be/dQw4w9WgXcQ?si=LgX_TA_mweng-1Bp";
        public ReservationForm()
        {
            InitializeComponent();
        }

        private void ReturnToTableOverviewBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReservationForm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SupriseBtn_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = videoUrl,
                UseShellExecute = true
            });
        }
    }
}
