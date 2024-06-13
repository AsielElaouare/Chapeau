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
    public partial class PopUpPayment : Form
    {
        Bill bill;
        PaymentForm paymentform;
        TableOverview tableOverview;
        public PopUpPayment(Bill bill, PaymentForm paymentForm)
        {
            InitializeComponent();
            this.bill = bill;
            this.paymentform = paymentForm;
        }

        private void bttn_Cash_Click(object sender, EventArgs e)
        {
            PayBill();
        }

        private void bttn_Pin_Click(object sender, EventArgs e)
        {
            PayBill();
        }

        private void PayBill()
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
            paymentform.Close();
            this.Close();


        }

        private void exitPopUpBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
