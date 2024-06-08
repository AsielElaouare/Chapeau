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

        public PaymentForm(Tafel table, Employee employee, Bill bill)
        {
            InitializeComponent();
            this.table = table;
            this.employee = employee;
            ShowOrder(GetBillOrders(bill));
            UpdateTotal(listview_Bestelling);
            UpdateBtw(listview_Bestelling);
            lbl_Waiter.Text = $"Gastheer/gastvrouw: {employee.name}";
            lbl_Table.Text = $"Tafel: {table.TafelNummer}";


        }
        private List<Orderline> GetBillOrders(Bill bill)
        {
            InvoiceService invoiceService = new InvoiceService();
            List<Orderline> orderlines = invoiceService.GetNotPaidOrderlinesForBill(bill);
            return orderlines;
        }

        private void UpdateTotal(ListView Bill)
        { decimal total=0;
            Orderline orderline;
            foreach(ListViewItem item in Bill.Items) {
                orderline = item.Tag as Orderline;
              total += orderline.product.Prijs; }

            lbl_Total.Text = $"Totaal: {total:C}";
        
        }

        private void UpdateBtw(ListView Bill)
        { decimal totalbtw=0;
            Orderline orderline;
            foreach (ListViewItem item in Bill.Items)
            {
                orderline = item.Tag as Orderline;
                switch (orderline.product.Category)
                {
                    case ProductCategorie.Bier: totalbtw += orderline.product.Prijs * 0.21m; break;
                    case ProductCategorie.Frisdrank: totalbtw += orderline.product.Prijs * 0.09m; break;
                    case ProductCategorie.Gedistilleerd: totalbtw += orderline.product.Prijs * 0.21m; break;
                    case ProductCategorie.Hoofdgerechten: totalbtw += orderline.product.Prijs * 0.09m; break;
                    case ProductCategorie.KoffieThee: totalbtw += orderline.product.Prijs * 0.09m; break;
                    case ProductCategorie.Nagerechten: totalbtw += orderline.product.Prijs * 0.09m; break;
                    case ProductCategorie.Tussengerechten: totalbtw += orderline.product.Prijs * 0.09m; break;
                    case ProductCategorie.Voorgerechten: totalbtw += orderline.product.Prijs * 0.09m; break;
                    case ProductCategorie.Wijn: totalbtw += orderline.product.Prijs * 0.21m; break;
                    default: break;
                }

             
                lbl_BTW.Text =  $"BTW: {totalbtw:C}";
            }


        }
        public void ShowOrder(List<Orderline> orders)
        {
            listview_Bestelling.Items.Clear();
            foreach (Orderline ol in orders)
            {
                ListViewItem orderline = new ListViewItem(ol.product.Name);
                orderline.SubItems.Add(ol.Quantity.ToString());
                orderline.SubItems.Add(ol.product.Prijs.ToString());
                //order.SubItems.Add(ord.OrderID.ToString());



                orderline.Tag = ol;
                listview_Bestelling.Items.Add(orderline);

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
            tableOverview.Show();
            this.Close();
        }
    }
}
