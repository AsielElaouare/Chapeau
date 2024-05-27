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
    public partial class PreviousOrders : Form
    {
        KitchenForm kitchenForm;
        public PreviousOrders()
        {
            InitializeComponent();

        }

        //private void DisplayOrders()
        //{
        //    List<Order> orders = GetPreviousKitchenOrders();
        //    int numberOfOrders = 0;
        //    foreach (Order order in orders)
        //    {
        //        KitchenDisplayOrder kitchenDisplayOrder = new KitchenDisplayOrder(order);
        //        flowLayoutPreviousOrdersPanel.Controls.Add(kitchenDisplayOrder);
        //        numberOfOrders++;
        //    }
        //    PreviousOrdersLabel.Text = $"Open: {numberOfOrders}";
        //}

        private void goBackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            kitchenForm.Show();
        }
    }
}
