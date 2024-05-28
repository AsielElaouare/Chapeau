using ChapeauModel;
using ChapeauService;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class KitchenDisplayOrder : UserControl
    {
        int nrOfOrders;
        Order Order;
        Label orderLabel;
        OrderService orderService;

        public KitchenDisplayOrder(Order order, Label orderLabel)
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
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            CompleteBtn.Enabled = true;
            DialogResult result = MessageBox.Show($"Weet u zeker dat u order nummer {Order.OrderID} wilt starten?", $"Order : {Order.OrderID} Starten", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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
                $"Weet u zeker dat u order nummer {Order.OrderID} wilt voltooien?", $"Order : {Order.OrderID} Voltooien", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                StartBtn.Enabled = false;
                timeLabel.BackColor = Color.FromArgb(23, 185, 8);
                Order.Status = OrderStatus.Ready;
                orderService.UpdateToReadyOrders(Order.OrderID, Order.Status);
                int nrOfOrders = int.Parse(orderLabel.Text.Substring(6));
                nrOfOrders--;
                orderLabel.Text = $"Open: {nrOfOrders}";
                flowLayoutPanelOrder.Parent.Parent.Controls.Remove(this);
            }
        }

        public void CheckProductCategory(Product product, Label dishlabel, Label dishLabelComment)
        {
            if (product.Categorie == ProductCategorie.Hoofdgerechten)
            {
                dishlabel.Text = product.Naam;
                mainDishesLayoutPanel.Controls.Add(dishlabel);
                mainDishesLayoutPanel.Controls.Add(dishLabelComment);
            }
            else if (product.Categorie == ProductCategorie.Voorgerechten)
            {
                dishlabel.Text = product.Naam;
                sideDishesLayoutPanel.Controls.Add(dishlabel);
                sideDishesLayoutPanel.Controls.Add(dishLabelComment);
            }
            else if (product.Categorie == ProductCategorie.Nagerechten)
            {
                dishlabel.Text = product.Naam;
                dessetsDishesLayoutPanel.Controls.Add(dishlabel);
                dessetsDishesLayoutPanel.Controls.Add(dishLabelComment);
            }
            if (!Order.OrderLineComment.Opmerking.IsNullOrEmpty())
            {
                dishLabelComment.Text = "Opmerking: " + Order.OrderLineComment.Opmerking;
            }
        }
    }
}
