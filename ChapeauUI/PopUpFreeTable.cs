using ChapeauModel;
using ChapeauService;
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
    public partial class PopUpFreeTable : Form
    {
        Employee employee;
        Tafel table;
        OrderForm orderForm;
        TableOverview tableOverview;
        TafelService tableService;
        string status = "Bezet";
        public PopUpFreeTable(Employee employee, Tafel table, TableOverview tableOverview)
        {
            InitializeComponent();
            this.table = table;
            this.employee = employee;
            tableLbl.Text = $"Tafel {table.TafelNummer.ToString()}";
            this.tableOverview = tableOverview;
            tableService = new TafelService();
        }

        private void StartOrderBtn_Click(object sender, EventArgs e)
        {
            orderForm = new OrderForm(table);
            orderForm.Show();
            tableOverview.Close();
            this.Close();
        }

        private void PopUpFreeTable_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MarkTableOccupiedBtn_Click(object sender, EventArgs e)
        {
            tableService.UpdateTableStatus(table, status);
            this.Close();
            tableOverview.ReOpenForm();
            //make a bill when merged

        }
    }
}
