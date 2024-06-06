using ChapeauModel;
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
    public partial class PopUpOccupiedTable : Form
    {
        Employee employee;
        Tafel table;
        OrderForm orderForm;
        TableOverview tableOverview;
        private int cornerRadius = 30;
        public PopUpOccupiedTable(Employee employee, Tafel table, TableOverview tableOverview)
        {
            InitializeComponent();
            SetRoundedRegion();
            this.table = table;
            this.employee = employee;
            tableLbl.Text = $"Tafel {table.TafelNummer.ToString()}";
            this.tableOverview = tableOverview;
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

        private void OrderBtn_Click(object sender, EventArgs e)
        {

            orderForm = new OrderForm(table,employee);
            orderForm.Show();
            tableOverview.Close();
            this.Close();
        }

        private void RecieptBtn_Click(object sender, EventArgs e)
        {
            //////Open reciept form

            this.Close();
            tableOverview.Close();
        }

        private void PopUpOccupiedTable_Deactivate(object sender, EventArgs e)
        {
            this.Close();
            tableOverview.RefreshTableButtons();
        }

        private void exitPopUpBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            tableOverview.RefreshTableButtons();
        }
    }
}
