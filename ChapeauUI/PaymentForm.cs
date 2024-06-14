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
        bool everything_IsPaid;

        public PaymentForm(Bill bill)
        {
            this.bill = bill;


            InitializeComponent();

            ShowOrder(GetBillOrders());

            CreateLabels();
            if (everything_IsPaid) { FreeTable(); }



        }
        private List<Orderline> GetBillOrders()
        {
            InvoiceService invoiceService = new InvoiceService();
            bill = invoiceService.GetBillNumber(bill);
            List<Orderline> orderlines = invoiceService.GetNotPaidOrderlinesForBill(bill);
            return orderlines;
        }
        private void UpdatePaid()
        {
            if (bill.unpaid == null) { bill.unpaid = bill.totalPrice; }

            /*  decimal total = 0;
             * Orderline orderline; 
            foreach (ListViewItem item in bill.Items)
            {
                orderline = item.Tag as Orderline;
               if (!orderline.Is_Paid)
                { total += orderline.product.Prijs * orderline.Quantity; }
            } */

            lbl_Due.Text = $"Openstaand: {bill.unpaid:C}";
            if (bill.unpaid == 0) { everything_IsPaid = true; }
        }
        private void FreeTable()
        { bttn_Pay.Text = "Maak tafel vrij"; }
        private void CreateLabels()
        {
            lbl_Waiter.Text = $"Gastheer/gastvrouw: {bill.employee.name}";
            lbl_Table.Text = $"Tafel: {bill.table.TafelNummer}";
            lbl_ReceiptNumber.Text = $"Bon nummer: {bill.billNumber}";
            lbl_Total.Text = $"Totaal: {bill.totalPrice:C}";
        
            DetermineBtw();
            UpdatePaid();
        }

       
       

        private void DetermineBtw()
        {
            decimal totalbtw = 0;
            Orderline orderline;
            foreach (ListViewItem item in listview_Bestelling.Items)
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

       

      

        private void bttn_PauzeerBetaling_Click(object sender, EventArgs e)
        {

            tableOverview = new TableOverview(bill.employee);
            tableOverview.Show();
            this.Close();
        }

      

        private void bttn_Pay_Click(object sender, EventArgs e)
        {
            if (!everything_IsPaid)
            {
                PopUpPayment popUpPayment = new PopUpPayment(bill, this);
                bill.review = txtb_Review.Text;
                popUpPayment.Show();
            }
            else
            {
                InvoiceService invoiceService = new InvoiceService();
                invoiceService.FinishInvoice(bill);

                TafelService tafelService = new TafelService();
                bill.table.Status = TableStatusEnum.Free;
                tafelService.UpdateTableStatus(bill.table);

                tableOverview = new TableOverview(bill.employee);
                tableOverview.Show();
                this.Close();



            }
        }
    }
}
