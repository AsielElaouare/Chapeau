using ChapeauModel;
using ChapeauService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ChapeauUI
{
    public partial class BarForm : Form
    {
        Timer timer;
        private OrderService orderService;
        private List<Order> orders;
        DateOnly dateToday;
        public BarForm()
        {
            this.orderService = new OrderService();
            dateToday = DateOnly.FromDateTime(DateTime.Now);
            InitializeComponent();
            InitTimer();
            DisplayOrders();
            UpdateLabelOpenOrders();
        }


        public void Update()
        {


            List<Order> latestOrders = orderService.GetOrdersForBar(OrderStatus.Pending, dateToday);

            foreach (Order order in latestOrders)
            {
                if (!orders.Any(o => o.OrderID == order.OrderID))
                {
                    orders.Add(order);
                    BarDisplayOrder barDisplayOrder = new BarDisplayOrder(order, OpenOrdersBarLabel);
                    barFlowLayoutPanel.Controls.Add(barDisplayOrder);
                    playNotificationSound();
                }
            }
            UpdateLabelOpenOrders();
        }
        private void UpdateLabelOpenOrders()
        {
            OpenOrdersBarLabel.Text = $"Open: {barFlowLayoutPanel.Controls.Count}";
        }

        private List<Order> GetBarOrders()
        {
            OrderService orderService = new OrderService();
            List<Order> orders = orderService.GetOrdersForBar(OrderStatus.Pending, dateToday); ;
            return orders;
        }

        private void DisplayOrders()
        {
            orders = GetBarOrders();
            foreach (Order order in orders)
            {
                BarDisplayOrder barDisplayOrder = new BarDisplayOrder(order, OpenOrdersBarLabel);
                barFlowLayoutPanel.Controls.Add(barDisplayOrder);
            }
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
        public void InitTimer()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 5000;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Update();
        }

        private void previousOrdersBar_Click(object sender, EventArgs e)
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
    }
}

