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
    public partial class PaymentForm : Form
    {
        private List<Order> orders;
        private OrderService orderService;
        Tafel table;
        Employee employee;
        TableOverview tableOverview;

        public PaymentForm(Tafel table, Employee employee)
        {
            InitializeComponent();
            this.table = table;
            this.employee = employee;
            ShowOrder(GetBillOrders(table));
            UpdateTotal(listview_Bestelling);
            UpdateBtw(listview_Bestelling);
            lbl_Waiter.Text = $"Gastheer/gastvrouw: {employee.name}";
            lbl_Table.Text = $"Tafel: {table.TafelNummer}";


        }
        private List<Order> GetBillOrders(Tafel table)
        {
            OrderService orderService = new OrderService();
            List<Order> orders = orderService.GetNotPAidOrdersForBill(table.TafelNummer);
            return orders;
        }

        private void UpdateTotal(ListView Bill)
        { decimal total=0;
            Order order;
            foreach(ListViewItem item in Bill.Items) {
                order = item.Tag as Order;
              total += order.ProductList[0].Prijs; }

            lbl_Total.Text = $"Totaal: {total:C}";
        
        }

        private void UpdateBtw(ListView Bill)
        { decimal totalbtw=0;
            Order order;
            foreach (ListViewItem item in Bill.Items)
            {
                order = item.Tag as Order;
                switch (order.ProductList[0].Categorie)
                {
                    case ProductCategorie.Bier: totalbtw += order.ProductList[0].Prijs * 0.21m; break;
                    case ProductCategorie.Frisdrank: totalbtw += order.ProductList[0].Prijs * 0.09m; break;
                    case ProductCategorie.Gedistilleerd: totalbtw += order.ProductList[0].Prijs * 0.21m; break;
                    case ProductCategorie.Hoofdgerechten: totalbtw += order.ProductList[0].Prijs * 0.09m; break;
                    case ProductCategorie.KoffieThee: totalbtw += order.ProductList[0].Prijs * 0.09m; break;
                    case ProductCategorie.Nagerechten: totalbtw += order.ProductList[0].Prijs * 0.09m; break;
                    case ProductCategorie.Tussengerechten: totalbtw += order.ProductList[0].Prijs * 0.09m; break;
                    case ProductCategorie.Voorgerechten: totalbtw += order.ProductList[0].Prijs * 0.09m; break;
                    case ProductCategorie.Wijn: totalbtw += order.ProductList[0].Prijs * 0.21m; break;
                    default: break;
                }

             
                lbl_BTW.Text =  $"BTW: {totalbtw:C}";
            }


        }
        public void ShowOrder(List<Order> orders)
        {
            listview_Bestelling.Items.Clear();
            foreach (Order ord in orders)
            {
                ListViewItem order = new ListViewItem(ord.ProductList[0].Naam);
                order.SubItems.Add(ord.orders[0].Aantal.ToString());
                order.SubItems.Add(ord.ProductList[0].Prijs.ToString());
                //order.SubItems.Add(ord.OrderID.ToString());



                order.Tag = ord;
                listview_Bestelling.Items.Add(order);

            }

            listview_Bestelling.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {

        }

        private void lbl_ReceiptNumber_Click(object sender, EventArgs e)
        {

        }

        private void bttn_PauzeerBetaling_Click(object sender, EventArgs e)
        {
           // paymentForm.close();
           tableOverview = new TableOverview(employee);
            tableOverview.ReOpenForm();
            this.Close();
        }
    }
}
