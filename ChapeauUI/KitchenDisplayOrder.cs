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

namespace ChapeauUI
{
    public partial class KitchenDisplayOrder : UserControl
    {
        Order Order;
        private bool timerElapsed = false;
        public KitchenDisplayOrder(Order order)
        {
            this.Order = order;
            InitializeComponent();
            DisplayOrderData();
            orderInfLabel.Text = $"Order: {order.OrderID}                                 Tafel: {order.TafelNR}";

        }
        public void DisplayOrderData()
        {
            foreach (Product product in Order.ProductList)
            {
                Label dishlabel = new Label();
                if (product.Categorie == ProductCategorie.Hoofdgerechten)
                {
                    dishlabel.Text = product.Naam;
                    mainDishesLayoutPanel.Controls.Add(dishlabel);
                }
                else if (product.Categorie == ProductCategorie.Voorgerechten)
                {
                    dishlabel.Text = product.Naam;
                    sideDishesLayoutPanel.Controls.Add(dishlabel);
                }
                else if (product.Categorie == ProductCategorie.Nagerechten)
                {
                    dishlabel.Text = product.Naam;
                    dessetsDishesLayoutPanel.Controls.Add(dishlabel);
                }
                dishlabel.BackColor = Color.FromArgb(123, 123, 123);
                dishlabel.Width = 200;
                dishlabel.Margin = new Padding(0, 10, 0, 0);
                dishlabel.Height = 30;
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
                $"Order : {Order.OrderID} Voltooien",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                StartBtn.Enabled = false;
                // changing status to preparing in database (DAO)
                timeLabel.BackColor = Color.FromArgb(23, 185, 8);
            }
            else if (result == DialogResult.No)
            {

            }
        }
    }
}
