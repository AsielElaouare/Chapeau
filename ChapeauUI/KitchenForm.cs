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
using ChapeauModel;


namespace ChapeauUI
{
    public partial class KitchenForm : Form
    {
        PreviousOrders previousOrdersForm;
        public KitchenForm()
        {
            InitializeComponent();
            this.previousOrdersForm = new PreviousOrders();
        }

        private void KitchenForm_Load(object sender, EventArgs e)
        {
            DisplayOrders();

        }

        private List<Order> GetKitchenOrders()
        {
            OrderService orderService = new OrderService();
            List<Order> orders = orderService.GetPendingOrdersForKitchen(); ;
            return orders;
        }

        private void DisplayOrders()
        {
            List<Order> orders = GetKitchenOrders();
            int numberOfOrders = 0;
            foreach (Order order in orders)
            {
                KitchenDisplayOrder kitchenDisplayOrder = new KitchenDisplayOrder(order);
                flowLayoutKitchenPnl.Controls.Add(kitchenDisplayOrder);
                numberOfOrders++;
            }
            openOrdersLabel.Text = $"Open: {numberOfOrders}";
        }

        private void historyOrders_Click(object sender, EventArgs e)
        {
            previousOrdersForm.Show();
            this.Hide();
        }
    }
}
