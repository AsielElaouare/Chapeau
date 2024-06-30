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
        

        private Bill bill;
       

        //een bool om aan te geven of de bon al is betaald, afhankelijk van het antwoord laat het een andere button zien
        bool everything_IsPaid;

        public PaymentForm(Table table, Employee employee)
        {
            this.bill = new Bill(table, employee);


            InitializeComponent();
          
           
            ShowOrder(GetBillOrders());

            //verandert de tekst van alle labels gebasseerd op het bill object.
            CreateLabels();
            UpdatePaid();
            if (everything_IsPaid) { FreeTable(); }



        }
        private List<Orderline> GetBillOrders()
        {
            InvoiceService invoiceService = new InvoiceService();
            List<Orderline> orderlines = invoiceService.GetOrderlinesForBill(bill);
            return orderlines;
        }
        private void UpdatePaid()
        {   
            if (bill.unpaid == null) { bill.unpaid = bill.totalPrice; }
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
            lbl_BTW.Text = $"BTW: {bill.VAT:C}";
            lbl_Tip.Text = $"Fooi: {bill.tip:C}";

          
        }

       
       
        private void ShowOrder(List<Orderline> orderlines)
        { // verbindt en weergeeft een lijst van orderlines aan de listview
            listview_Bestelling.Items.Clear();
            foreach (Orderline ol in orderlines)
            {
                ListViewItem orderline = new ListViewItem(ol.product.Name);
                orderline.SubItems.Add(ol.Quantity.ToString());
                orderline.SubItems.Add(ol.product.Prijs.ToString());
                



                orderline.Tag = ol;
                listview_Bestelling.Items.Add(orderline);

            }

            listview_Bestelling.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

       

      

        private void bttn_PauzeerBetaling_Click(object sender, EventArgs e)
        {

           TableOverview tableOverview = new TableOverview(bill.employee);
            tableOverview.Show();
            this.Close();
        }

      


        private void bttn_Pay_Click(object sender, EventArgs e)
        {
            bill.review = txtb_Review.Text;
            //als nog niet alles is betaald krijg je een popup om bethaalmethode te kiezen
            if (!everything_IsPaid)
            {
                PopUpPayment popUpPayment = new PopUpPayment(bill, this);
               
                popUpPayment.Show();
            }
            //als alles is betaald wordt nog een keer de bill naar de database gestuurd en de tafel vrijgemaakt
            else
            {
                InvoiceService invoiceService = new InvoiceService();
                invoiceService.FinishInvoice(bill);

                TafelService tafelService = new TafelService();
                bill.table.Status = TableStatusEnum.Free;
                tafelService.UpdateTableStatus(bill.table);
                
               TableOverview tableOverview = new TableOverview(bill.employee);
                tableOverview.Show();
                this.Close();



            }
        }
    }
}
