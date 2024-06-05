using ChapeauModel;
using ChapeauService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public BarForm()
        {
            this.orderService = new OrderService();
            InitializeComponent();
            InitTimer();
            DisplayOrders();
            UpdateLabelOpenOrders();
        }

        public void Update()
        {

            List<Order> latestOrders = orderService.GetAllPendingOrdersForBar();

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
            List<Order> orders = orderService.GetAllPendingOrdersForBar(); ;
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
            SoundPlayer sound = new SoundPlayer("NewOrder.wav");
            sound.Play();
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
    }
}
