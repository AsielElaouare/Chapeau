using ChapeauModel;
using ChapeauService;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class KitchenDisplayOrder : UserControl
    {
        private Order Order;
        private Label orderLabel;
        private OrderService orderService;
        private List<Order> orders;
        private Timer orderTimer = new Timer();


        public KitchenDisplayOrder(Order order, Label openOrdersLabel)
        {
            this.Order = order;
            this.orderService = new OrderService();
            this.orderLabel = openOrdersLabel;
            InitializeComponent();
            DisplayOrderData();
            CheckTypeOfOrder();
        }
        public KitchenDisplayOrder(Order order, Label openOrdersLabel, List<Order> orders)
        {
            this.Order = order;
            this.orderService = new OrderService();
            this.orderLabel = openOrdersLabel;
            this.orders = orders;
            InitializeComponent();
            DisplayOrderData();
            CheckTypeOfOrder();
        }
        private void DisplayOrderData()
        {
            orderTimer.Interval = 1000;
            orderInfLabel.Text = $"Order: {Order.OrderID}                               Tafel: {Order.TafelNR}";
            foreach (Product product in Order.ProductList)
            {
                DrawLabels(product);
            }
            orderTimer.Tick += new EventHandler(UpdateOrderTime);
            orderTimer.Start();
        }

        private void CheckTypeOfOrder()
        {
            if (Order.Status == OrderStatus.Ready)
            {
                remakeOrder.Visible = true;
                remakeOrder.Enabled = true;
                StartBtn.Visible = false;
                CompleteBtn.Visible = false;
            }
        }
        private void StartBtn_Click(object sender, EventArgs e)
        {
            CompleteBtn.Enabled = true;

            StartBtn.Enabled = false;
            // changing status to preparing in database (DAO)
            timeLabel.BackColor = Color.FromArgb(23, 185, 8);
            orderService.UpdateToPreparingOrders(Order.OrderID, OrderStatus.Preparing, OrderType.Kitchen);
        }

        private void CompleteBtn_Click(object sender, EventArgs e)
        {
            StartBtn.Enabled = false;
            timeLabel.BackColor = Color.FromArgb(23, 185, 8);
            orderService.UpdateToReadyOrders(Order.OrderID, OrderStatus.Ready, OrderType.Kitchen);
            orderLabel.Text = $"Open: {flowLayoutPanelOrder.Parent.Parent.Controls.Count - 1}";
            orders.Remove(Order);
            flowLayoutPanelOrder.Parent.Parent.Controls.Remove(this);
        }

        private void DrawLabels(Product product)
        {
            Label dishlabel = new Label();
            Label dishLabelComment = new Label();

            CheckProductCategory(product, dishlabel, dishLabelComment);

            dishLabelComment.ForeColor = Color.White;
            dishLabelComment.Font = new Font(dishLabelComment.Font, FontStyle.Italic);
            dishLabelComment.Width = 200;
            dishlabel.BackColor = Color.FromArgb(123, 123, 123);
            dishlabel.Width = 200;
            dishlabel.Height = 30;
            dishlabel.Margin = new Padding(0, 10, 0, 0);
        }


        private void CheckProductCategory(Product product, Label dishLabel, Label dishLabelComment)
        {
            dishLabel.Text = product.Name;
            switch (product.Category)
            {
                case ProductCategorie.Voorgerechten:
                    sideDishesLayoutPanel.Controls.Add(dishLabel);
                    sideDishesLayoutPanel.Controls.Add(dishLabelComment);
                    break;
                case ProductCategorie.Hoofdgerechten:
                    mainDishesLayoutPanel.Controls.Add(dishLabel);
                    mainDishesLayoutPanel.Controls.Add(dishLabelComment);
                    break;
                case ProductCategorie.Nagerechten:
                    dessetsDishesLayoutPanel.Controls.Add(dishLabel);
                    dessetsDishesLayoutPanel.Controls.Add(dishLabelComment);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(Order.OrderLine.Commentary))
                dishLabelComment.Text = "Opmerking: " + Order.OrderLine.Commentary;
        }

        private void remakeOrder_Click(object sender, EventArgs e)
        {
            orderService.UpdateToRemakingOrder(Order.OrderID, OrderStatus.Pending, OrderType.Kitchen);
            flowLayoutPanelOrder.Parent.Parent.Controls.Remove(this);
        }
        private void UpdateOrderTime(object sender, EventArgs e)
        {
            TimeSpan elapsedTime = DateTime.Now - Order.OrderTime;
            string formatString = elapsedTime.ToString(@"hh\:mm\:ss");
            timeLabel.Text = $"{formatString}";
        }
    }
}
