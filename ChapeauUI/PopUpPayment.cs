using ChapeauModel;
using ChapeauService;
using Microsoft.IdentityModel.Logging;
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
           if (txtb_Payment.Text != "")
            { // checkt eerst of de input klopt
                if (!checkinput(txtb_Payment)) { MessageBox.Show("foutieve invoer bij betalingsveld, probeer opniew"); return; }
                if (txtb_Fooi.Text != "")
                {
                    if (!checkinput(txtb_Fooi)) { MessageBox.Show("foutieve invoer bij fooi, probeer opniew"); return; }
                    bill.tip = bill.tip + decimal.Parse(txtb_Fooi.Text);
                }

                //checkt of de input niet te hoog is, rondt af op 2 decimalen om te voorkomen dat er 0,000001 nog betaald moet worden
                if (Math.Round(decimal.Parse(txtb_Payment.Text),2) > Math.Round(bill.unpaid,2)) { MessageBox.Show("Het bedrag dat wordt betaald is te hoog, mocht de klant meer willen betalen voer dat dan in bij fooi."); }
                else { Pay();}
            }
            else MessageBox.Show("Voer het bedrag in dat de klant wil betalen");
        }

        private void Pay()
        {
            InvoiceService invoiceService = new InvoiceService();
            bill.paid = Math.Round(bill.paid, 2) + Math.Round(decimal.Parse(txtb_Payment.Text), 2);
            invoiceService.FinishInvoice(bill);
            if (bill.unpaid == 0) { BackToTables(); } else { BackToBillPopUp(); }
        }
        // hij blijft op de bill popup form zolang niet alles is betaald
        private void BackToBillPopUp()
        {
            this.Close(); paymentform.Close();
           PaymentForm paymentformnew = new PaymentForm(bill.table, bill.employee);
            paymentformnew.Show();
            PopUpPayment popUpPayment = new PopUpPayment(bill, paymentformnew);
            popUpPayment.Show();
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
  
        //probeert het te parsen en mocht dat niet lukken returnt hij false
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
        //kommas worden gezien als correcte input
        private void bttn_Pin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {

                e.Handled = true;
            }

        }



        private void bttn_Split_Click(object sender, EventArgs e)
        {
            if (txtb_Split.Text != "" && int.Parse(txtb_Split.Text) != 0)
            {
                decimal split = Math.Round(bill.unpaid / int.Parse(txtb_Split.Text), 2);
                txtb_Payment.Text = split.ToString();
            }
            else { MessageBox.Show("Vul alsjeblieft een correct getal in om het bedrag door te splitten"); }
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
