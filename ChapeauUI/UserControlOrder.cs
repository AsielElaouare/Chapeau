using ChapeauModel;
using ChapeauService;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class UserControlOrder : UserControl
    {
        public UserControlOrder(Order order, Label openOrdersLabel, OrderType orderType)
        {
            this.Tag = order;
            InitializeComponent();
            DisplayOrderData(order);
            CheckTypeOfOrder(order);
            SetupEventHandelers(order, openOrdersLabel, orderType);
        }

        private void DisplayOrderData(Order order)
        {
            Timer orderTimer = new Timer();
            orderTimer.Interval = 1000;
            orderInfLabel.Text = $"Order: {order.OrderID}                             Tafel: {order.TafelNR}";


            foreach (Orderline orderLine in order.orderlines)
            {
                DrawLabels(orderLine);
            }
            orderTimer.Tick += (sender, e) => UpdateOrderTime(sender, e, order);
            orderTimer.Start();
        }

        private void CheckTypeOfOrder(Order order)
        {
            if (order.Status == OrderStatus.Ready)
            {
                remakeOrder.Visible = true;
                remakeOrder.Enabled = true;
                StartBtn.Visible = false;
                CompleteBtn.Visible = false;
            }
        }
        private void DrawLabels(Orderline orderline)
        {
            Label dishlabel = new Label();
            Label dishLabelComment = new Label();

            CheckProductCategory(orderline, dishlabel, dishLabelComment);

            dishLabelComment.ForeColor = Color.White;
            dishLabelComment.Font = new Font(dishLabelComment.Font, FontStyle.Italic);
            dishLabelComment.Width = 200;
            dishlabel.BackColor = Color.FromArgb(123, 123, 123);
            dishlabel.Width = 200;
            dishlabel.Height = 30;
            dishlabel.Margin = new Padding(0, 10, 0, 0);
        }

        private void CheckProductCategory(Orderline orderline, Label dishLabel, Label dishLabelComment)
        {
            dishLabel.Text = $"{orderline.Quantity}x {orderline.product.Name}";
            switch (orderline.product.Category)
            {
                case ProductCategorie.Voorgerechten:
                    sideDishesLabel.Visible = true;
                    sideDishesLayoutPanel.Controls.Add(dishLabel);
                    sideDishesLayoutPanel.Controls.Add(dishLabelComment);
                    break;
                case ProductCategorie.Tussengerechten:
                    tussengerechtenLabel.Visible = true;
                    entreesFlowLayoutPanel.Controls.Add(dishLabel);
                    entreesFlowLayoutPanel.Controls.Add(dishLabelComment);
                    break;
                case ProductCategorie.Hoofdgerechten:
                    mainDishesLabel.Visible = true;
                    mainDishesLayoutPanel.Controls.Add(dishLabel);
                    mainDishesLayoutPanel.Controls.Add(dishLabelComment);
                    break;
                case ProductCategorie.Nagerechten:
                    dessertsLabel.Visible = true;
                    dessetsDishesLayoutPanel.Controls.Add(dishLabel);
                    dessetsDishesLayoutPanel.Controls.Add(dishLabelComment);
                    break;
                default:
                    drinksHeaderLabel.Visible = true;
                    drinksFlowLayout.Controls.Add(dishLabel);
                    drinksFlowLayout.Controls.Add(dishLabelComment);
                    break;
            }
            if (!string.IsNullOrWhiteSpace(orderline.Commentary))
                dishLabelComment.Text = "Opmerking: " + orderline.Commentary;
        }

        private void UpdateOrderTime(object sender, EventArgs e, Order order)
        {
            TimeSpan elapsedTime = DateTime.Now - order.OrderTime;
            string formatString = elapsedTime.ToString(@"hh\:mm\:ss");
            timeLabel.Text = $"{formatString}";
        }

        private void SetupEventHandelers(Order order, Label orderLabel, OrderType orderType)
        {
            OrderService orderService = new OrderService();
            remakeOrder.Click += (sender, e) =>
            {
                orderService.UpdateToRemakingOrder(order.OrderID, OrderStatus.Pending, orderType);
                orderLabel.Text = $"Voltooide Bestellingen: {flowLayoutPanelOrder.Parent.Parent.Controls.Count - 1}";
                flowLayoutPanelOrder.Parent.Parent.Controls.Remove(this);
            };
            StartBtn.Click += (sender, e) =>
            {
                CompleteBtn.Enabled = true;
                StartBtn.Enabled = false;
                timeLabel.BackColor = Color.FromArgb(23, 185, 8);
                orderService.UpdateToPreparingOrders(order.OrderID, OrderStatus.Preparing, orderType);
            };
            CompleteBtn.Click += (sender, e) =>
            {
                StartBtn.Enabled = false;
                timeLabel.BackColor = Color.FromArgb(23, 185, 8);
                orderService.UpdateToReadyOrders(order.OrderID, OrderStatus.Ready, orderType);
                orderLabel.Text = $"Open: {flowLayoutPanelOrder.Parent.Parent.Controls.Count - 1}";
                flowLayoutPanelOrder.Parent.Parent.Controls.Remove(this);
            };
        }
    }
}
