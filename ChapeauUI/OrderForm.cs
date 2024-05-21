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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {

        }

        private void drinksButton_Click(object sender, EventArgs e)
        {
            MakeSelectedButtonDark(drinksButton);
            PlaceRightProductButtons(" Drinks");
        }

        private void lunchButton_Click(object sender, EventArgs e)
        {
            MakeSelectedButtonDark(lunchButton);
            PlaceRightProductButtons("Lunch");
        }
        private void dinerButton_Click(object sender, EventArgs e)
        {
            MakeSelectedButtonDark(dinerButton);
            PlaceRightProductButtons("Diner");
        }
        private void MakeSelectedButtonDark(Button selectedButton)
        {
            dinerButton.BackColor = SystemColors.ControlDark;
            lunchButton.BackColor = SystemColors.ControlDark;
            drinksButton.BackColor = SystemColors.ControlDark;
            selectedButton.BackColor = SystemColors.ControlDarkDark;
        }
        private List<Product> GetProducts()
        {
            ProductService productService = new ProductService();
            List<Product> products = productService.GetProducts();
            return products;
        }
        
        private void PlaceRightProductButtons(string product)
        {
            flowLayoutPanel1.Controls.Clear();
            List<Product> products = GetProducts();

            foreach (var item in products)
             {
                 if (product ==item.Kaart) 
                 {
                     Button btn = new Button();
                     btn.Text = item.Naam;
                     btn.Size = new Size(160, 55);
                     btn.Click += Button_Click;
                     btn.BackColor = SystemColors.ControlDark;
                     flowLayoutPanel1.Controls.Add(btn); 
                 }
             }

        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                MessageBox.Show($"{clickedButton.Text} clicked");
            }
        }
    }
}
