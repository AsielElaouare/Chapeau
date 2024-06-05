using ChapeauModel;
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

namespace ChapeauUI
{
    public partial class BarDisplayOrder : UserControl
    {

        Order Order;
        Label orderLabel;
        OrderService orderService;

        public BarDisplayOrder(Order order, Label orderLabel)
        {
            this.Order = order;
            this.orderLabel = orderLabel;
            this.orderService = new OrderService();
            InitializeComponent();
            DisplayOrderData();
            CheckTypeOfOrder();
        }

        private void CheckTypeOfOrder()
        {
            if (Order.Status == OrderStatus.Ready)
            {
                remakeOrderBtn.Visible = true;
                remakeOrderBtn.Enabled = true;
                StartBtn.Visible = false;
                CompleteBtn.Visible = false;
            }
        }
        public void DisplayOrderData()
        {
            orderInfLabel.Text = $"Order: {Order.OrderID}                               Tafel: {Order.TafelNR}";
            foreach (Product product in Order.ProductList)
            {
                DrawLabels(product);
            }
        }

        private void DrawLabels(Product product)
        {
            Label drinkLabel = new Label();
            Label drinkLabelCommment = new Label();

                drinkLabel.Text = product.Name;

            drinkLabelCommment.ForeColor = Color.White;
            drinkLabelCommment.Font = new Font(drinkLabelCommment.Font, FontStyle.Italic);
            drinkLabelCommment.Width = 200;
            drinkLabel.BackColor = Color.FromArgb(123, 123, 123);
            drinkLabel.Width = 200;
            drinkLabel.Height = 30;
            drinkLabel.Margin = new Padding(0, 10, 0, 0);
            drinksFlowLayoutPnl.Controls.Add(drinkLabel);
            drinksFlowLayoutPnl.Controls.Add(drinkLabelCommment);
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            StartBtn.Enabled = false;
            CompleteBtn.Enabled = true;
            timeLabel.BackColor = Color.FromArgb(23, 185, 8);
            orderService.UpdateToPreparingOrders(Order.OrderID, OrderStatus.Preparing);
        }

        private void CompleteBtn_Click(object sender, EventArgs e)
        {
            StartBtn.Enabled = false;
            timeLabel.BackColor = Color.FromArgb(23, 185, 8);
            orderService.UpdateToReadyOrders(Order.OrderID, OrderStatus.Ready);
            OrderPanel.Parent.Parent.Controls.Remove(this);
        }

        private void remakeOrderBtn_Click(object sender, EventArgs e)
        {
            orderService.UpdateToRemakingOrder(Order.OrderID, OrderStatus.Pending);
            OrderPanel.Parent.Parent.Controls.Remove(this);
        }
    }
}
