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
        Employee employee;
        Tafel table;
        TafelService tafelService = new TafelService();
        string besteldeTafelStatus = "Besteld";
        public OrderForm()
        {
            InitializeComponent();
            products = GetProducts();
            orders = new List<Orderline>();
        }
        public OrderForm(Tafel table, Employee employee)
        {
            InitializeComponent();
            products = GetProducts();
            orders = new List<Orderline>();
            this.employee= employee;
            this.table = table;
            tafelNRText.Text = $"bestelling voor tafel {table.TafelNummer}.";
        }
        private List<Product> GetProducts()
        {
            ProductService productService = new ProductService();
            List<Product> products = productService.GetProducts();
            return products;
        }
        private void StoreThisOrder(DateTime timeOfOrde, int selectedTable)
        {
            OrderService orderService = new OrderService();
            orderService.StoreOrder(timeOfOrde, selectedTable,orders);
        }
        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (orders.Count != 0)
            {
                StoreThisOrder(DateTime.Now, table.TafelNummer);
                ChangeTableStatus();
                GoToTableOverview();
            }
            else 
            {
                MessageBox.Show("Selecteer een producten");
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            GoToTableOverview();
        }
        private void GoToTableOverview()
        {
            TableOverview tableOverview = new TableOverview(employee);
            tableOverview.Show();
            this.Close();
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
        private void FillProductLayoutPanel(ProductKaart kaart)
        {
            productLayoutPanel.Controls.Clear();
            List<ProductCategorie> categories = new List<ProductCategorie>();

            foreach (Product item in products)
            {
                if (kaart == item.Menu && !categories.Contains(item.Category))
                {
                    Label categoryLabel = new Label();
                    categoryLabel.Text = item.Category.ToString() + ":";
                    categoryLabel.Size = new Size(690, 20);
                    productLayoutPanel.Controls.Add(categoryLabel);
                    MakePruductForCategorie(item.Menu, item.Category);
                    categories.Add(item.Category);
                }
            }
        }
        private void MakePruductForCategorie(ProductKaart kaart, ProductCategorie categorie)
        {
            foreach (Product product in products)
            {
                if (kaart == product.Menu && categorie == product.Category)
                {
                    Button productBtn = new Button();
                    productBtn.Text = product.Name;
                    productBtn.Size = new Size(165, 55);
                    productBtn.Click += Product_Button_Click;
                    productBtn.Tag = product.Stock;
                    productBtn.BackColor = SelectProductBtnColor(product);
                    productLayoutPanel.Controls.Add(productBtn);
                }
            }
        }
        private Color SelectProductBtnColor(Product product)
        {
            if (product.Stock > 10)
            {
                return SystemColors.ControlDark;
            }
            else if (product.Stock > 0)
            {
                return Color.Yellow; 
            }
            else
            {
                return Color.Red; 
            }
        }

        private void Product_Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null&&(int)clickedButton.Tag!=0)
            {
                Clickedproduct(clickedButton.Text);
            }
            else
            {
                MessageBox.Show($"{clickedButton.Text} is op");
            }
        }
        private void Clickedproduct(string productnaam)
        {
            foreach (Product product in products)
            {
                if (productnaam == product.Name)
                {
                    AddProductToList(product.Artikelid);
                    break;
                }
            }
        }
        private void AddProductToList(int productID)
        {
            if (CheckIfProductIsInList(productID))
            {
                foreach (Orderline order in orders)
                {
                    if (order.ArticleID == productID&&EnoughStock(productID,order.Quantity))
                    {
                        order.IncreaseQuantity();
                        break;
                    }
                }
            }
            else
            {
                Orderline newProduct = new Orderline( 1, null, productID);
                orders.Add(newProduct);
            }
            DislpayOrders();
        }
        private bool EnoughStock(int productID, int amountOfOrderdProduct)
        {
            foreach(Product product in products) 
            {
                if (product.Artikelid == productID && product.Stock > amountOfOrderdProduct)
                {
                    return true;
                }
            }
            MessageBox.Show($"niet genoeg meer op voorraad van {ProductIDToProductName(productID)}");
            return false;
        }
        private bool CheckIfProductIsInList(int ProductID)
        {
            if (orders.Count != 0)
            {
                foreach (Orderline order in orders)
                {
                    if (order.ArticleID == ProductID)
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
                //productnaam in lijst
                MakeProductNameInOrderlist(order);
                //Aantal producten
                ShowQuantityInOrderList(order);
                //verwijder button
                AddDeleteButton(order);
                //opmerking button
                AddComentarryButton(order);
                //laat opmerking zien
                if (order.Commentary != null)
                {
                    ShowComment(order);
                }
            }
        }
        private void ShowComment(Orderline order)
        {
            Label commentLabel = new Label();
            commentLabel.Text = order.Commentary;
            commentLabel.Size = new Size(280, 20);
            commentLabel.BackColor = Color.DarkGray;
            orderLayoutPanel.Controls.Add(commentLabel);
        }
        private void AddComentarryButton(Orderline order)
        {
            Button opmerkingBtn = new Button();
            opmerkingBtn.Text = "opmerking";
            opmerkingBtn.Size = new Size(135, 35);
            opmerkingBtn.Tag = order.ArticleID;
            opmerkingBtn.Click += Opmerking_Button_Click;
            opmerkingBtn.BackColor = Color.DodgerBlue;
            orderLayoutPanel.Controls.Add(opmerkingBtn);
        }
        private void AddDeleteButton(Orderline order)
        {
            Button verwijderBtn = new Button();
            verwijderBtn.Text = "-1";
            verwijderBtn.Size = new Size(135, 35);
            verwijderBtn.Tag = order.ArticleID;
            verwijderBtn.Click += Verwijder_Button_Click;
            verwijderBtn.BackColor = Color.Red;
            orderLayoutPanel.Controls.Add(verwijderBtn);
        }
        private void ShowQuantityInOrderList(Orderline order)
        {
            Label procductAantalmLabel = new Label();
            procductAantalmLabel.Text = order.Quantity.ToString();
            procductAantalmLabel.Size = new Size(20, 35);
            orderLayoutPanel.Controls.Add(procductAantalmLabel);
        }
        private void MakeProductNameInOrderlist(Orderline order)
        {
            Label procductNaamLabel = new Label();
            procductNaamLabel.Text = ProductIDToProductName(order.ArticleID);
            procductNaamLabel.Size = new Size(250, 35);
            orderLayoutPanel.Controls.Add(procductNaamLabel);
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
                if (order.ArticleID == (int)clickedButton.Tag && order.Commentary == null)
                {
                    order.AddComment(Microsoft.VisualBasic.Interaction.InputBox("Voer iets in:")); break;
                }
                else if(order.ArticleID == (int)clickedButton.Tag)
                {
                    order.AddComment(Microsoft.VisualBasic.Interaction.InputBox("Voer iets in:", "", order.Commentary)); break;
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
                    if (order.ArticleID == (int)clickedButton.Tag && order.Quantity == 1)
                    {
                        orders.Remove(order);
                        break;
                    }
                    else if (order.ArticleID == (int)clickedButton.Tag)
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
                    return product.Name;
                }
            }
            return "";
        }
        private void ChangeTableStatus()
        {
            tafelService.UpdateTableStatus(table,besteldeTafelStatus);
        }
    }
}
