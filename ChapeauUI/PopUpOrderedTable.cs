using ChapeauModel;
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
    public partial class PopUpOrderedTable : Form
    {
        Employee employee;
        Tafel table;
        OrderForm orderForm;
        TableOverview tableOverview;
        public PopUpOrderedTable(Employee employee, Tafel table, TableOverview tableOverview)
        {
            InitializeComponent();
            this.table = table;
            this.employee = employee;
            tableLbl.Text = $"Tafel {table.TafelNummer.ToString()}";
            this.tableOverview = tableOverview;
        }

        private void PopUpOrderedTable_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OrderBtn_Click(object sender, EventArgs e)
        {
            orderForm = new OrderForm(table);
            orderForm.Show();
            tableOverview.Close();
            this.Close();
        }
    }
}
