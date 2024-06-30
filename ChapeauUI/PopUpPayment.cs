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

        public PopUpPayment(Bill bill, PaymentForm paymentForm)
        {
            InitializeComponent();
            this.bill = bill;
            this.paymentform = paymentForm;
            lbl_AmountUnpaid.Text = $"Nog te betalen Bedrag: {bill.unpaid:C}";
            // hij vult direct de nog te betalen bedrag in
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
            decimal paymentAmount;
            decimal tipmount;

            if (txtb_Payment.Text != "")
            { // checkt eerst of de input klopt
                if (!checkinput(txtb_Payment)) { MessageBox.Show("foutieve invoer bij betalingsveld, probeer opniew"); return; }
                if (txtb_Fooi.Text != "")
                {
                    if (!checkinput(txtb_Fooi)) { MessageBox.Show("foutieve invoer bij fooi, probeer opniew"); return; }
                    bill.tip = bill.tip + decimal.Parse(txtb_Fooi.Text);
                }
                //checkt of de input niet te hoog is
                if (decimal.Parse(txtb_Payment.Text) > bill.unpaid) { MessageBox.Show("Het bedrag dat wordt betaald is te hoog, mocht de klant meer willen betalen voer dat dan in bij fooi."); }
                else
                {
                    bill.unpaid = bill.unpaid - decimal.Parse(txtb_Payment.Text);
                    invoiceService.FinishInvoice(bill);
                    if (bill.unpaid == 0) { BackToTables();  } else { BackToBill(); }
                }
            }
            else MessageBox.Show("Voer het bedrag in dat de klant wil betalen");
        }


        // hij blijft op de bill form zolang niet alles is betaald
        private void BackToBill()
        {
            this.Close(); paymentform.Close();
            paymentform = new PaymentForm(bill.table, bill.employee);
            paymentform.Show();
        }
        private void BackToTables()
        { //als de tafel zijn bestelling heeft ontvangen en is betaald wordt hij op vrij gezet
            if (bill.table.Status == TableStatusEnum.Occupied)

            {
                TafelService tafelService = new TafelService();
                bill.table.Status = TableStatusEnum.Free;
                tafelService.UpdateTableStatus(bill.table);
            }
            TableOverview tableOverview = new TableOverview(bill.employee);
            tableOverview.Show();
            paymentform.Close();
            this.Close();
        }
  
        //probeert het te parsen en mocht dat niet lukken return hij false
        private bool checkinput(TextBox textBox)
        { if (decimal.TryParse(textBox.Text, out decimal result))
            { return true; }
            else return false;
        }
      
        private void exitPopUpBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        //zolang er geen cijfer wordt ingevoerd registreert hij de input niet
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



        private void bttn_Split_Click(object sender, EventArgs e)
        {
            if (txtb_Split.Text != "")
            { txtb_Payment.Text = $"{bill.unpaid / int.Parse(txtb_Split.Text)}"; }
        }

        private void txtb_fooi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {

                e.Handled = true;
            }
        }

        private void txtb_Split_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {

                e.Handled = true;
            }
        }
    }
}
