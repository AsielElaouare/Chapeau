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
    public partial class KitchenAndBarForm : Form
    {
        public KitchenAndBarForm(Employee employee)
        {
            InitializeComponent();
            DisplayOrders(employee);
            SetupEventHandlers(employee);
            InitTimerKitchen(employee);
            UpdateLabelOpenOrders();
        }
        private void DisplayOrders(Employee employee)
        {
            try
            {
                if (employee.role == EmployeeRoleEnum.Chef)
                {
                    List<Order> orders = GetKitchenOrders();
                    foreach (Order order in orders)
                    {
                        UserControlOrder kitchenDisplayOrder = new UserControlOrder(order, openOrdersLabel, OrderType.Kitchen);
                        flowLayoutKitchenPnl.Controls.Add(kitchenDisplayOrder);
                    }
                }
                else if (employee.role == EmployeeRoleEnum.Barista)
                {
                    List<Order> orders = GetBarOrders();
                    foreach (Order order in orders)
                    {
                        UserControlOrder barDisplayOrder = new UserControlOrder(order, openOrdersLabel, OrderType.Bar);
                        flowLayoutKitchenPnl.Controls.Add(barDisplayOrder);
                    }
                }
            }
            catch (Exception ex) { throw new Exception("An Error occured while displaying Orders: ", ex); }
        }
        public void UpdateOrders(Employee employee)
        {
            List<Order> latestOrders;
            List<Order> currentOrders = GetControlsTagOrders();
            try
            {
                if (employee.role == EmployeeRoleEnum.Chef)
                    latestOrders = GetKitchenOrders();
                else
                    latestOrders = GetBarOrders();

                foreach (Order order in latestOrders)
                {
                    if (!currentOrders.Any(o => o.OrderID == order.OrderID))
                    {
                        UserControlOrder DisplayOrder = new UserControlOrder(order, openOrdersLabel, OrderType.Kitchen);
                        flowLayoutKitchenPnl.Controls.Add(DisplayOrder);
                        playNotificationSound();
                    }
                }
                latestOrders.Clear();
                UpdateLabelOpenOrders();
            }
            catch (Exception ex) { throw new Exception("An Error occured while updating Orders: ", ex); }
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
        private void timer_Tick(object sender, EventArgs e, Employee employee)
        {
            UpdateOrders(employee);
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
        public void InitTimerKitchen(Employee employee)
        {
            Timer timer = new Timer();
            timer.Tick += (sender, e) =>
            {
                timer_Tick(sender, e, employee);
            };
            timer.Interval = 10000;
            timer.Start();
        }
        public DateOnly GetDateToday()
        {
            DateOnly dateToday;
            return dateToday = DateOnly.FromDateTime(DateTime.Now);

        }
        public List<Order> GetControlsTagOrders()
        {
            List<Order> list = new List<Order>();
            foreach (Control control in flowLayoutKitchenPnl.Controls)
            {
                Order orderTag = control.Tag as Order;
                list.Add(orderTag);
            }
            return list;
        }
        private void SetupEventHandlers(Employee employee)
        {
            historyOrders.Click += (sender, e) =>
            {
                PreviousOrders previousOrders = new PreviousOrders(employee, this);

                previousOrders.Show();
            };

        }

    }
}
