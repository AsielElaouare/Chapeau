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
        public PreviousOrders(Employee employee, KitchenAndBarForm form)
        {
            InitializeComponent();
            form.Hide();
            if (employee.role == EmployeeRoleEnum.Barista)
            {
                DisplayOrdersBar();
            }
            else if (employee.role == EmployeeRoleEnum.Chef)
            {
                DisplayOrdersKitchen();
            }
            madeOrdersLabel.Text = $"Voltooide bestellingen: {flowLayoutPreviousOrdersPanel.Controls.Count}";
            SetupEventHandlers(form);
        }
        private void DisplayOrdersKitchen()
        {
            OrderService orderService = new OrderService();
            DateOnly dateToday = DateOnly.FromDateTime(DateTime.Now);
            List<Order> orders = orderService.GetOrdersForKitchen(OrderStatus.Ready, dateToday);

            foreach (Order order in orders)
            {
                UserControlOrder kitchenDisplayOrder = new UserControlOrder(order, madeOrdersLabel, OrderType.Kitchen);
                flowLayoutPreviousOrdersPanel.Controls.Add(kitchenDisplayOrder);
            }
        }

        private void DisplayOrdersBar()
        {
            OrderService orderService = new OrderService();
            DateOnly dateToday = DateOnly.FromDateTime(DateTime.Now);
            List<Order> orders = orderService.GetOrdersForBar(OrderStatus.Ready, dateToday);

            foreach (Order order in orders)
            {
                UserControlOrder kitchenDisplayOrder = new UserControlOrder(order, madeOrdersLabel, OrderType.Bar);
                flowLayoutPreviousOrdersPanel.Controls.Add(kitchenDisplayOrder);
            }
        }

        private void SetupEventHandlers(KitchenAndBarForm kitchen)
        {
            goBackBtn.Click += (sender, e) =>
            {
                this.Close();
                kitchen.Show();
            };
        }
    }
}
