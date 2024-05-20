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
            ProductDisplay("drinks");
        }

        private void lunchButton_Click(object sender, EventArgs e)
        {
            MakeSelectedButtonDark(lunchButton);
        }
        private void dinerButton_Click(object sender, EventArgs e)
        {
            MakeSelectedButtonDark(dinerButton);
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
        
    }
}
