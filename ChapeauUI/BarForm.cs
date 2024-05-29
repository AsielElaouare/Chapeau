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
    public partial class BarForm : Form, IObserver
    {
        private OrderService orderService;
        private List<Order> orders;
        private string name;
        private ISubject subject;
        public ISubject Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public BarForm(ISubject subject)
        {
            InitializeComponent();
            subject.Attach(this);
            DisplayOrders();
            this.subject = subject;
            this.orderService = new OrderService();
        }

        public BarForm()
        {
            InitializeComponent();
            DisplayOrders();
            this.orderService = new OrderService();
        }
        public void Update()
        {

            List<Order> latestOrders = orderService.GetAllPendingOrdersForBar();

            foreach (Order order in latestOrders)
            {
                if (!orders.Any(o => o.OrderID == order.OrderID))
                {
                    orders.Add(order);
                    BarDisplayOrder kitchenDisplayOrder = new BarDisplayOrder(order, OpenOrdersBarLabel);
                    barFlowLayoutPanel.Controls.Add(kitchenDisplayOrder);
                    OpenOrdersBarLabel.Text = $"Open: {orders.Count}";
                    playNotificationSound();
                }
            }
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
                BarDisplayOrder kitchenDisplayOrder = new BarDisplayOrder(order, OpenOrdersBarLabel);
                barFlowLayoutPanel.Controls.Add(kitchenDisplayOrder);
            }
            OpenOrdersBarLabel.Text = $"Open: {orders.Count}";
        }

        private void playNotificationSound()
        {
            SoundPlayer sound = new SoundPlayer("NewOrder.wav");
            sound.Play();
        }
    }
}
