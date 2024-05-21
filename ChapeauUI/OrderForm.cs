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
            products= GetProducts();
            tafels = GetTafels();
            PopulateComboBox();
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
                MessageBox.Show("Selecteer een nummer uit de lijst.");
            }
        }

        private void drinksButton_Click(object sender, EventArgs e)
        {
            MakeSelectedButtonDark(drinksButton);
            FillProductLayoutPanel(ProductKaart.Drinks);
        }

        private void lunchButton_Click(object sender, EventArgs e)
        {
            MakeSelectedButtonDark(lunchButton);
            FillProductLayoutPanel(ProductKaart.Lunch);
        }
        private void dinerButton_Click(object sender, EventArgs e)
        {
            MakeSelectedButtonDark(dinerButton);
            FillProductLayoutPanel(ProductKaart.Diner);
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
                    categoryLabel.Text = item.Categorie.ToString()+":";
                    categoryLabel.Size = new Size(690, 20);
                    productLayoutPanel.Controls.Add(categoryLabel);
                    MakePruductForCategorie(item.Kaart,item.Categorie);
                    categories.Add(item.Categorie);
                }
            }
        }
        private void MakePruductForCategorie(ProductKaart kaart,ProductCategorie categorie)
        {   
            foreach (var item in products)
            {
                if (kaart == item.Kaart && categorie == item.Categorie)
                {
                    Button btn = new Button();
                    btn.Text = item.Naam;
                    btn.Size = new Size(165, 55);
                    btn.Click += Button_Click;
                    btn.BackColor = SystemColors.ControlDark;
                    productLayoutPanel.Controls.Add(btn);
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
        private void PopulateComboBox()
        {
            foreach(var tafel in tafels)
            {
                TafelSelecter.Items.Add($"tafel {tafel.TafelNummer}");
            }
        }
    }
}
