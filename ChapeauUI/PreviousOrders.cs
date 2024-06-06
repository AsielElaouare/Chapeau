using ChapeauModel;
using ChapeauService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class PreviousOrders : Form
    {
        KitchenForm kitchenForm;
        OrderService orderService;
        public PreviousOrders(KitchenForm kitchenForm)
        {
            this.orderService = new OrderService();
            this.kitchenForm = kitchenForm;
            InitializeComponent();
            DisplayOrders();
            madeOrdersLabel.Text = $"Vooltoide bestellingen: {flowLayoutPreviousOrdersPanel.Controls.Count}";
        }

        private void DisplayOrders()
        {
            DateOnly dateToday = DateOnly.FromDateTime(DateTime.Now);
            List<Order> orders = orderService.GetReadyOrdersForKitchen(dateToday);

            foreach (Order order in orders)
            {
                KitchenDisplayOrder kitchenDisplayOrder = new KitchenDisplayOrder(order, madeOrdersLabel);
                flowLayoutPreviousOrdersPanel.Controls.Add(kitchenDisplayOrder);
            }
        }

        private void goBackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            kitchenForm.Show();
        }

    }
}
