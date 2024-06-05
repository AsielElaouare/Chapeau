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
        Order Order;
        Label orderLabel;
        OrderService orderService;

        public KitchenDisplayOrder(Order order, Label openOrdersLabel)
        {
            this.Order = order;
            this.orderService = new OrderService();
            this.orderLabel = openOrdersLabel;
            InitializeComponent();
            DisplayOrderData();
        }
        private void DisplayOrderData()
        {
            CheckTypeOfOrder();
            orderInfLabel.Text = $"Order: {Order.OrderID}                               Tafel: {Order.TafelNR}";
            foreach (Product product in Order.ProductList)
            {
                DrawLabels(product);
            }
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
            orderService.UpdateToPreparingOrders(Order.OrderID, OrderStatus.Preparing);
        }

        private void CompleteBtn_Click(object sender, EventArgs e)
        {
            StartBtn.Enabled = false;
            timeLabel.BackColor = Color.FromArgb(23, 185, 8);
            orderService.UpdateToReadyOrders(Order.OrderID, OrderStatus.Ready);
            orderLabel.Text = $"Open: {flowLayoutPanelOrder.Parent.Parent.Controls.Count - 1}";
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
            dishLabel.Text = product.Naam;
            switch (product.Categorie)
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
            if (!string.IsNullOrEmpty(Order.OrderLineComment.Opmerking))
                dishLabelComment.Text = "Opmerking: " + Order.OrderLineComment.Opmerking;
        }

        private void remakeOrder_Click(object sender, EventArgs e)
        {
            orderService.UpdateToRemakingOrder(Order.OrderID, OrderStatus.Pending);
            flowLayoutPanelOrder.Parent.Parent.Controls.Remove(this);

        }
    }
}
