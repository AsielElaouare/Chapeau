using ChapeauModel;
using ChapeauService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class OrderForm : Form
    {
        List<Product> products;
        List<Orderline> orders;
        List<Tafel> tafel;

        Employee employee;
        Tafel table;

        public OrderForm()
        {
            InitializeComponent();
            products = GetProducts();
            FillTableBox();
            orders = new List<Orderline>();
        }
        public OrderForm(Tafel table)
        {
            InitializeComponent();
            products = GetProducts();
            FillTableBox();
            orders = new List<Orderline>();
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
        private void PlaceOrderIDInOrderline(int orderID)
        {
            foreach (Orderline order in orders)
            {
                order.SetOrderID(orderID);
            }
        }
        private int GetNewOrderID(DateTime timeOfOrde, int selectedTable)
        {
            OrderService orderService = new OrderService();
            return orderService.GetNewOrderID(timeOfOrde, selectedTable);
        }
        private void StoreOrdersInDB(List<Orderline> ordersList)
        {
            OrderlineService orderlineService = new OrderlineService();
            orderlineService.StoreOrder(ordersList);
        }
        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (tableSelectbox.SelectedItem != null)
            {
                DateTime timeOfOrder = DateTime.Now;
                int selectedTable = (int)tableSelectbox.SelectedItem;
                int orderID = GetNewOrderID(timeOfOrder, selectedTable);
                PlaceOrderIDInOrderline(orderID);
                StoreOrdersInDB(orders);
            }
            else
            {
                MessageBox.Show("Selecteer een tafel uit de lijst.");
            }
            //go to taffel overzicht!!!
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            //naar tafel overzicht
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
        private void FillTableBox()
        {
            tafel = GetTafels();

            foreach (Tafel table in tafel)
            {
                tableSelectbox.Items.Add(table.TafelNummer);
            }
        }
        private void FillProductLayoutPanel(ProductKaart kaart)
        {
            productLayoutPanel.Controls.Clear();
            List<ProductCategorie> categories = new List<ProductCategorie>();

            foreach (Product item in products)
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
            foreach (Product product in products)
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
                Clickedproduct(clickedButton.Text);
            }
        }
        private void Clickedproduct(string productnaam)
        {
            foreach (Product product in products)
            {
                if (productnaam == product.Naam)
                {
                    AddProductToList(product.Artikelid);
                    break;
                }
            }
        }
        private void AddProductToList(int ProductID)
        {
            if (CheckIfProductIsInList(ProductID))
            {
                foreach (Orderline order in orders)
                {
                    if (order.ArtikelID == ProductID)
                    {
                        order.IncreaseQuantity();
                        break;
                    }
                }
            }
            else
            {
                Orderline newProduct = new Orderline(0, 1, null, ProductID);
                orders.Add(newProduct);
            }
            DislpayOrders();
        }
        private bool CheckIfProductIsInList(int ProductID)
        {
            if (orders.Count != 0)
            {
                foreach (Orderline order in orders)
                {
                    if (order.ArtikelID == ProductID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void DislpayOrders()
        {
            orderLayoutPanel.Controls.Clear();
            foreach (Orderline order in orders)
            {
                Label procductNaamLabel = new Label();
                procductNaamLabel.Text = ProductIDToProductName(order.ArtikelID);
                procductNaamLabel.Size = new Size(280, 40);
                orderLayoutPanel.Controls.Add(procductNaamLabel);
                //hier moet nog een aantal selcter komen
                Label procductAantalmLabel = new Label();
                procductAantalmLabel.Text = order.Aantal.ToString();
                procductAantalmLabel.Size = new Size(25, 40);
                orderLayoutPanel.Controls.Add(procductAantalmLabel);
                //verwijder button
                Button verwijderBtn = new Button();
                verwijderBtn.Text = "-1";
                verwijderBtn.Size = new Size(150, 35);
                verwijderBtn.Tag = order.ArtikelID;
                verwijderBtn.Click += Verwijder_Button_Click;
                verwijderBtn.BackColor = Color.Red;
                orderLayoutPanel.Controls.Add(verwijderBtn);
                //opmerking button
                Button opmerkingBtn = new Button();
                opmerkingBtn.Text = "opmerking";
                opmerkingBtn.Size = new Size(150, 35);
                opmerkingBtn.Tag = order.ArtikelID;
                opmerkingBtn.Click += Opmerking_Button_Click;
                opmerkingBtn.BackColor = Color.DodgerBlue;
                orderLayoutPanel.Controls.Add(opmerkingBtn);
                //laat opmerking zien
                if (order.Opmerking != null)
                {
                    Label commentLabel = new Label();
                    commentLabel.Text = order.Opmerking;
                    commentLabel.Size = new Size(280, 20);
                    orderLayoutPanel.Controls.Add(commentLabel);
                }
            }
        }
        private void Opmerking_Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            AddCommentToList(clickedButton);
        }
        private void AddCommentToList(Button clickedButton)
        {

            foreach (Orderline order in orders)
            {
                if (order.ArtikelID == (int)clickedButton.Tag && order.Opmerking == null)
                {
                    order.AddComment(Microsoft.VisualBasic.Interaction.InputBox("Voer iets in:")); break;
                }
                else if (order.ArtikelID == (int)clickedButton.Tag)
                {
                    order.AddComment(Microsoft.VisualBasic.Interaction.InputBox("Voer iets in:", "", order.Opmerking)); break;
                }
            }
            DislpayOrders();
        }
        private void Verwijder_Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                foreach (Orderline order in orders)
                {
                    if (order.ArtikelID == (int)clickedButton.Tag && order.Aantal == 1)
                    {
                        orders.Remove(order);
                        break;
                    }
                    else if (order.ArtikelID == (int)clickedButton.Tag)
                    {
                        order.DecreaseQuantity();
                    }
                }
            }
            DislpayOrders();
        }
        private string ProductIDToProductName(int productID)
        {
            foreach (Product product in products)
            {
                if (productID == product.Artikelid)
                {
                    return product.Naam;
                }
            }
            return "";
        }


    }
}
