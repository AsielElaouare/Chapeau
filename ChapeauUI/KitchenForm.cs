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


namespace ChapeauUI
{
    public partial class KitchenForm : Form, IObserver
    {
        private List<Order> orders;
        private OrderService orderService;
        private string name;
        private ISubject subject;
        public ISubject Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public KitchenForm(ISubject subject)
        {
            InitializeComponent();
            subject.Attach(this);
            DisplayOrders();
            this.subject = subject;
            this.orderService = new OrderService();
        }

        public KitchenForm()
        {
            InitializeComponent();
            subject.Attach(this);
            DisplayOrders();
            this.orderService = new OrderService();
        }

        public void Update()
        {

            List<Order> latestOrders = orderService.GetPendingOrdersForKitchen();

            foreach (Order order in latestOrders)
            {
                if (!orders.Any(o => o.OrderID == order.OrderID))
                {
                    orders.Add(order);
                    KitchenDisplayOrder kitchenDisplayOrder = new KitchenDisplayOrder(order, openOrdersLabel);
                    flowLayoutKitchenPnl.Controls.Add(kitchenDisplayOrder);
                    openOrdersLabel.Text = $"Open: {orders.Count}";
                    playNotificationSound();
                }
            }

        }
        private List<Order> GetKitchenOrders()
        {
            OrderService orderService = new OrderService();
            List<Order> orders = orderService.GetPendingOrdersForKitchen(); ;
            return orders;
        }

        private void DisplayOrders()
        {
            orders = GetKitchenOrders();
            foreach (Order order in orders)
            {
                KitchenDisplayOrder kitchenDisplayOrder = new KitchenDisplayOrder(order, openOrdersLabel);
                flowLayoutKitchenPnl.Controls.Add(kitchenDisplayOrder);
            }
            openOrdersLabel.Text = $"Open: {orders.Count}";
        }

        //private void historyOrders_Click(object sender, EventArgs e)
        //{
        //    previousOrdersForm.Show();
        //    this.Hide();
        //}

        private void playNotificationSound()
        {
            SoundPlayer sound = new SoundPlayer("NewOrder.wav");
            sound.Play();
        }
    }
}
