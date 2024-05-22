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
        List<Product> products;
        List<Tafel> tafels;
        public OrderForm()
        {
            InitializeComponent();
            products = GetProducts();
            tafels = GetTafels();
            FillComboBoxWithTables();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (TafelSelecter.SelectedItem != null)
            {
                string selectedTafel = (string)TafelSelecter.SelectedItem;
                MessageBox.Show("de geselecteerde tafel is: " + selectedTafel);
            }
            else
            {
                MessageBox.Show("Selecteer een tafel uit de lijst.");
            }
        }

        private void drinksButton_Click(object sender, EventArgs e)
        {
            MakeSelectedButtonDarkDark(drinksButton);
            FillProductLayoutPanel(ProductKaart.Drinks);
        }

        private void lunchButton_Click(object sender, EventArgs e)
        {
            MakeSelectedButtonDarkDark(lunchButton);
            FillProductLayoutPanel(ProductKaart.Lunch);
        }
        private void dinerButton_Click(object sender, EventArgs e)
        {
            MakeSelectedButtonDarkDark(dinerButton);
            FillProductLayoutPanel(ProductKaart.Diner);
        }
        private void MakeSelectedButtonDarkDark(Button selectedButton)
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
        private List<Tafel> GetTafels()
        {
            TafelService tafelService = new TafelService();
            List<Tafel> tafels = tafelService.GetTafel();
            return tafels;
        }
        private void FillProductLayoutPanel(ProductKaart kaart)
        {
            productLayoutPanel.Controls.Clear();
            List<ProductCategorie> categories = new List<ProductCategorie>();

            foreach (var item in products)
            {
                if (kaart == item.Kaart && !categories.Contains(item.Categorie))
                {
                    Label categoryLabel = new Label();
                    categoryLabel.Text = item.Categorie.ToString() + ":";
                    categoryLabel.Size = new Size(690, 20);
                    productLayoutPanel.Controls.Add(categoryLabel);
                    MakePruductForCategorie(item.Kaart, item.Categorie);
                    categories.Add(item.Categorie);
                }
            }
        }
        private void MakePruductForCategorie(ProductKaart kaart, ProductCategorie categorie)
        {
            foreach (var product in products)
            {
                if (kaart == product.Kaart && categorie == product.Categorie)
                {
                    Button productBtn = new Button();
                    productBtn.Text = product.Naam;
                    productBtn.Size = new Size(165, 55);
                    productBtn.Click += Product_Button_Click;
                    productBtn.BackColor = SystemColors.ControlDark;
                    productLayoutPanel.Controls.Add(productBtn);
                }
            }
        }
        private void Product_Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                MessageBox.Show($"{clickedButton.Text} clicked");
            }
        }
        private void FillComboBoxWithTables()
        {
            foreach (var tafel in tafels)
            {
                TafelSelecter.Items.Add($"tafel {tafel.TafelNummer}");
            }
        }

        
    }
}
