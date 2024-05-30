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
        public BarDisplayOrder()
        {
            InitializeComponent();
        }
        int nrOfOrders;
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
        }
        public void DisplayOrderData()
        {
            orderInfLabel.Text = $"Order: {Order.OrderID}                               Tafel: {Order.TafelNR}";
            foreach (Product product in Order.ProductList)
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
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            CompleteBtn.Enabled = true;
            DialogResult result = MessageBox.Show(
                $"Weet u zeker dat u order nummer {Order.OrderID} wilt starten?",
                $"Order : {Order.OrderID} Starten",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                StartBtn.Enabled = false;
                // changing status to preparing in database (DAO)
                timeLabel.BackColor = Color.FromArgb(23, 185, 8);
                Order.Status = OrderStatus.Preparing;
                orderService.UpdateToPreparingOrders(Order.OrderID, Order.Status);
            }
            else if (result == DialogResult.No)
            {
                CompleteBtn.Enabled = false;
            }
        }

        private void CompleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Weet u zeker dat u order nummer {Order.OrderID} wilt voltooien?",
                $"Order : {Order.OrderID} Voltooien", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                StartBtn.Enabled = false;
                timeLabel.BackColor = Color.FromArgb(23, 185, 8);
                Order.Status = OrderStatus.Ready;
                orderService.UpdateToReadyOrders(Order.OrderID, Order.Status);
                int nrOfOrders = int.Parse(orderLabel.Text.Substring(6));
                nrOfOrders--;
                orderLabel.Text = $"Open: {nrOfOrders}";
                OrderPanel.Parent.Parent.Controls.Remove(this);
            }
        }
    }
}
