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
using System.Media;
using System.IO;


namespace ChapeauUI
{
    public partial class KitchenForm : Form
    {

        public KitchenForm(Employee employee)
        {
            InitializeComponent();
            if (employee.role == EmployeeRoleEnum.Chef)
            {
                DisplayOrdersForKitchen();
                InitTimerKitchen();
            }
            else if (employee.role == EmployeeRoleEnum.Barista)
            {
                DisplayOrdersForBar();
            }
            UpdateLabelOpenOrders();
        }

        private void DisplayOrdersForKitchen()
        {
            List<Order> orders = GetKitchenOrders();
            foreach (Order order in orders)
            {
                KitchenDisplayOrder kitchenDisplayOrder = new KitchenDisplayOrder(order, openOrdersLabel, orders);
                flowLayoutKitchenPnl.Controls.Add(kitchenDisplayOrder);
            }
        }


        private void DisplayOrdersForBar()
        {
            List<Order> orders = GetBarOrders();
            foreach (Order order in orders)
            {
                BarDisplayOrder barDisplayOrder = new BarDisplayOrder(order, openOrdersLabel);
                flowLayoutKitchenPnl.Controls.Add(barDisplayOrder);
            }
        }


        public void UpdateOrdersForKitchen()
        {
            List<Order> latestOrders = GetKitchenOrders();
            foreach (Order order in latestOrders)
            {
                foreach (Control control in flowLayoutKitchenPnl.Controls)
                {
                    Order orderTag = control.Tag as Order;
                    if (orderTag.OrderID != order.OrderID)
                    {
                        KitchenDisplayOrder kitchenDisplayOrder = new KitchenDisplayOrder(order, openOrdersLabel);
                        flowLayoutKitchenPnl.Controls.Add(kitchenDisplayOrder);
                    }
                }
            }
            latestOrders.Clear();
            playNotificationSound();
            UpdateLabelOpenOrders();
        }
        private List<Order> GetBarOrders()
        {
            OrderService orderService = new OrderService();
            List<Order> orders = orderService.GetOrdersForBar(OrderStatus.Pending, GetDateToday()); ;
            return orders;
        }
        private List<Order> GetKitchenOrders()
        {
            OrderService orderService = new OrderService();
            List<Order> orders = orderService.GetOrdersForKitchen(OrderStatus.Pending, GetDateToday()); ;
            return orders;
        }
        private void timer_TickKitchen(object sender, EventArgs e)
        {
            UpdateOrdersForKitchen();
        }

        private void historyOrders_Click(object sender, EventArgs e)
        {
            PreviousOrders previousOrders = new PreviousOrders(this);
            this.Hide();
            previousOrders.Show();
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void playNotificationSound()
        {
            string file = "..\\..\\..\\Resources\\order-sound.wav";
            if (File.Exists(file))
            {
                SoundPlayer sound = new SoundPlayer(file);
                sound.Play();
            }
        }
        private void UpdateLabelOpenOrders()
        {
            openOrdersLabel.Text = $"Open: {flowLayoutKitchenPnl.Controls.Count}";
        }
        public void InitTimerKitchen()
        {
            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer_TickKitchen);
            timer.Interval = 5000;
            timer.Start();
        }

        public DateOnly GetDateToday()
        {
            DateOnly dateToday;
            return dateToday = DateOnly.FromDateTime(DateTime.Now);

        }
    }
}
