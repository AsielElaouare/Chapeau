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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class PreviousOrders : Form
    {
        private KitchenForm kitchenForm;
        private BarForm barForm;
        private OrderService orderService;
        public PreviousOrders(KitchenForm kitchenForm)
        {
            this.orderService = new OrderService();
            this.kitchenForm = kitchenForm;
            InitializeComponent();
            DisplayOrdersKitchen();
            madeOrdersLabel.Text = $"Voltooide bestellingen: {flowLayoutPreviousOrdersPanel.Controls.Count}";
        }

        public PreviousOrders(BarForm barForm)
        {
            this.orderService = new OrderService();
            this.barForm = barForm;
            InitializeComponent();
            DisplayOrdersBar();
            madeOrdersLabel.Text = $"Voltooide bestellingen: {flowLayoutPreviousOrdersPanel.Controls.Count}";
        }

        private void DisplayOrdersKitchen()
        {
            DateOnly dateToday = DateOnly.FromDateTime(DateTime.Now);
            List<Order> orders = orderService.GetOrdersForKitchen(OrderStatus.Ready, dateToday);

            foreach (Order order in orders)
            {
                KitchenDisplayOrder kitchenDisplayOrder = new KitchenDisplayOrder(order, madeOrdersLabel);
                flowLayoutPreviousOrdersPanel.Controls.Add(kitchenDisplayOrder);
            }
        }

        private void DisplayOrdersBar()
        {
            DateOnly dateToday = DateOnly.FromDateTime(DateTime.Now);
            List<Order> orders = orderService.GetOrdersForKitchen(OrderStatus.Ready, dateToday);

            foreach (Order order in orders)
            {
                BarDisplayOrder kitchenDisplayOrder = new BarDisplayOrder(order, madeOrdersLabel);
                flowLayoutPreviousOrdersPanel.Controls.Add(kitchenDisplayOrder);
            }
        }

        private void goBackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            if (kitchenForm != null)
            {
                kitchenForm.Show();
            }
            else
            {
                barForm.Show();
            }
        }

    }
}
