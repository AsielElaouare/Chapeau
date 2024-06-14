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
            lbl_AmountUnpaid.Text = $"Nog te betalen Bedrag: {bill.unpaid:C}";
            txtb_Payment.Text = $"{bill.unpaid:0.00}";
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
            if (txtb_fooi.Text != "")
            {
                bill.tip = bill.tip + decimal.Parse(txtb_fooi.Text);
            }

            if (txtb_Payment.Text != "")
            {
                if (decimal.Parse(txtb_Payment.Text) > bill.unpaid) { MessageBox.Show("Het bedrag dat wordt betaald is te hoog, mocht de klant meer willen betalen voer dat dan in bij fooi."); }
                else
                {
                    bill.unpaid = bill.unpaid - decimal.Parse(txtb_Payment.Text);



                    invoiceService.FinishInvoice(bill);

                    if (bill.table.Status == TableStatusEnum.Occupied)

                    {
                        TafelService tafelService = new TafelService();
                        bill.table.Status = TableStatusEnum.Free;
                        tafelService.UpdateTableStatus(bill.table);
                    }

                    if (bill.unpaid == 0)
                    {
                        tableOverview = new TableOverview(bill.employee);
                        tableOverview.Show();
                        paymentform.Close();
                        this.Close();
                    }
                    else
                    {
                        this.Close(); paymentform.Close();
                        paymentform = new PaymentForm(bill);
                        paymentform.Show();

                    }
                }
            }
        }

        private void exitPopUpBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txtb_Payment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {

                e.Handled = true;
            }
        }

        private void bttn_Pin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {

                e.Handled = true;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {

                e.Handled = true;
            }
        }

        private void bttn_Split_Click(object sender, EventArgs e)
        {
            if (txtb_Split.Text != "")
            { txtb_Payment.Text = $"{bill.unpaid / int.Parse(txtb_Split.Text)}"; }
        }
    }
}
