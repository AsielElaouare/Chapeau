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
        Bill bill;
        TableOverview tableOverview;

        public PaymentForm(Bill bill)
        {
            this.bill = bill;

            InitializeComponent();

            ShowOrder(GetBillOrders(bill));

            CreateLabels(bill, listview_Bestelling);



        }
        private List<Orderline> GetBillOrders(Bill bill)
        {
            InvoiceService invoiceService = new InvoiceService();
            bill = invoiceService.GetBillNumber(bill);
            List<Orderline> orderlines = invoiceService.GetNotPaidOrderlinesForBill(bill);
            return orderlines;
        }
        private void UpdatePaid(ListView bill)
        {
            decimal total = 0;
            Orderline orderline;
            foreach (ListViewItem item in bill.Items)
            {
                orderline = item.Tag as Orderline;
                total += orderline.product.Prijs * orderline.Quantity;
            }

            lbl_Openstaand.Text = $"Openstaand: {total:C}";
        }
        private void CreateLabels(Bill bill, ListView listView)
        {
            lbl_Waiter.Text = $"Gastheer/gastvrouw: {bill.employee.name}";
            lbl_Table.Text = $"Tafel: {bill.table.TafelNummer}";
            lbl_ReceiptNumber.Text = $"Bon nummer: {bill.billNumber}";
            UpdateTotal(listView);
            UpdateBtw(listView);
            UpdatePaid(listView);
        }
        private void UpdateTotal(ListView bill)
        {
            decimal total = 0;
            Orderline orderline;
            foreach (ListViewItem item in bill.Items)
            {
                orderline = item.Tag as Orderline;
                total += orderline.product.Prijs * orderline.Quantity;
            }

            lbl_Total.Text = $"Totaal: {total:C}";

        }


        private void UpdateBtw(ListView Bill)
        {
            decimal totalbtw = 0;
            Orderline orderline;
            foreach (ListViewItem item in Bill.Items)
            {
                orderline = item.Tag as Orderline;
                switch (orderline.product.Category)
                {
                    case ProductCategorie.Bier: totalbtw += orderline.product.Prijs * 0.21m * orderline.Quantity; break;
                    case ProductCategorie.Frisdrank: totalbtw += orderline.product.Prijs * 0.09m * orderline.Quantity; break;
                    case ProductCategorie.Gedistilleerd: totalbtw += orderline.product.Prijs * 0.21m * orderline.Quantity; break;
                    case ProductCategorie.Hoofdgerechten: totalbtw += orderline.product.Prijs * 0.09m * orderline.Quantity; break;
                    case ProductCategorie.KoffieThee: totalbtw += orderline.product.Prijs * 0.09m * orderline.Quantity; break;
                    case ProductCategorie.Nagerechten: totalbtw += orderline.product.Prijs * 0.09m * orderline.Quantity; break;
                    case ProductCategorie.Tussengerechten: totalbtw += orderline.product.Prijs * 0.09m * orderline.Quantity; break;
                    case ProductCategorie.Voorgerechten: totalbtw += orderline.product.Prijs * 0.09m * orderline.Quantity; break;
                    case ProductCategorie.Wijn: totalbtw += orderline.product.Prijs * 0.21m * orderline.Quantity; break;
                    default: break;
                }


                lbl_BTW.Text = $"BTW: {totalbtw:C}";
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

            tableOverview = new TableOverview(bill.employee);
            tableOverview.Show();
            this.Close();
        }

        private void bttn_payment_Click(object sender, EventArgs e)
        {
            InvoiceService invoiceService = new InvoiceService();
            invoiceService.FinishInvoice(bill);

            if (bill.table.Status == TableStatusEnum.Occupied) 

            {
                TafelService tafelService = new TafelService();
                bill.table.Status = TableStatusEnum.Free;
                tafelService.UpdateTableStatus(bill.table);
            }


            tableOverview = new TableOverview(bill.employee);
            tableOverview.Show();
            this.Close();

        }

        private void bttn_splitpayment_Click(object sender, EventArgs e)
        {
           
        }
    }
}
