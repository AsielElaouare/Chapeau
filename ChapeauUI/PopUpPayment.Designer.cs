namespace ChapeauUI
{
    partial class PopUpPayment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopUpPayment));
            exitPopUpBtn = new BottomLeftRoundedButton();
            bttn_Cash = new PillButton();
            bttn_Pin = new PillButton();
            txtb_Payment = new System.Windows.Forms.TextBox();
            lbl_AmountUnpaid = new System.Windows.Forms.Label();
            lbl_chooseamount = new System.Windows.Forms.Label();
            lbl_fooi = new System.Windows.Forms.Label();
            txtb_Fooi = new System.Windows.Forms.TextBox();
            bttn_Split = new System.Windows.Forms.Button();
            txtb_Split = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // exitPopUpBtn
            // 
            exitPopUpBtn.BackColor = System.Drawing.Color.FromArgb(255, 20, 20);
            exitPopUpBtn.BackgroundImage = (System.Drawing.Image)resources.GetObject("exitPopUpBtn.BackgroundImage");
            exitPopUpBtn.FlatAppearance.BorderSize = 0;
            exitPopUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            exitPopUpBtn.Location = new System.Drawing.Point(528, -1);
            exitPopUpBtn.Name = "exitPopUpBtn";
            exitPopUpBtn.Size = new System.Drawing.Size(48, 48);
            exitPopUpBtn.TabIndex = 7;
            exitPopUpBtn.UseVisualStyleBackColor = false;
            exitPopUpBtn.Click += exitPopUpBtn_Click;
            // 
            // bttn_Cash
            // 
            bttn_Cash.BackColor = System.Drawing.Color.Black;
            bttn_Cash.FlatAppearance.BorderSize = 0;
            bttn_Cash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bttn_Cash.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            bttn_Cash.ForeColor = System.Drawing.Color.White;
            bttn_Cash.Image = (System.Drawing.Image)resources.GetObject("bttn_Cash.Image");
            bttn_Cash.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            bttn_Cash.Location = new System.Drawing.Point(12, 203);
            bttn_Cash.Name = "bttn_Cash";
            bttn_Cash.Size = new System.Drawing.Size(272, 68);
            bttn_Cash.TabIndex = 8;
            bttn_Cash.Text = " Betalen met cash";
            bttn_Cash.UseVisualStyleBackColor = false;
            bttn_Cash.Click += bttn_Cash_Click;
            // 
            // bttn_Pin
            // 
            bttn_Pin.BackColor = System.Drawing.Color.Black;
            bttn_Pin.FlatAppearance.BorderSize = 0;
            bttn_Pin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bttn_Pin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            bttn_Pin.ForeColor = System.Drawing.Color.White;
            bttn_Pin.Image = (System.Drawing.Image)resources.GetObject("bttn_Pin.Image");
            bttn_Pin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            bttn_Pin.Location = new System.Drawing.Point(290, 203);
            bttn_Pin.Name = "bttn_Pin";
            bttn_Pin.Size = new System.Drawing.Size(272, 68);
            bttn_Pin.TabIndex = 9;
            bttn_Pin.Text = " Betalen met pin";
            bttn_Pin.UseVisualStyleBackColor = false;
            bttn_Pin.Click += bttn_Pin_Click;
            bttn_Pin.KeyPress += bttn_Pin_KeyPress;
            // 
            // txtb_Payment
            // 
            txtb_Payment.Location = new System.Drawing.Point(47, 149);
            txtb_Payment.Name = "txtb_Payment";
            txtb_Payment.Size = new System.Drawing.Size(174, 31);
            txtb_Payment.TabIndex = 10;
            txtb_Payment.KeyPress += txtb_Payment_KeyPress;
            // 
            // lbl_AmountUnpaid
            // 
            lbl_AmountUnpaid.AutoSize = true;
            lbl_AmountUnpaid.Location = new System.Drawing.Point(159, 11);
            lbl_AmountUnpaid.Name = "lbl_AmountUnpaid";
            lbl_AmountUnpaid.Size = new System.Drawing.Size(201, 25);
            lbl_AmountUnpaid.TabIndex = 11;
            lbl_AmountUnpaid.Text = "Nog te betalen bedrag: ";
            // 
            // lbl_chooseamount
            // 
            lbl_chooseamount.AutoSize = true;
            lbl_chooseamount.Location = new System.Drawing.Point(47, 121);
            lbl_chooseamount.Name = "lbl_chooseamount";
            lbl_chooseamount.Size = new System.Drawing.Size(174, 25);
            lbl_chooseamount.TabIndex = 12;
            lbl_chooseamount.Text = "Wat betaalt de klant:";
            // 
            // lbl_fooi
            // 
            lbl_fooi.AutoSize = true;
            lbl_fooi.Location = new System.Drawing.Point(290, 121);
            lbl_fooi.Name = "lbl_fooi";
            lbl_fooi.Size = new System.Drawing.Size(228, 25);
            lbl_fooi.TabIndex = 13;
            lbl_fooi.Text = "wat geeft de klant aan fooi:";
            // 
            // txtb_Fooi
            // 
            txtb_Fooi.Location = new System.Drawing.Point(290, 149);
            txtb_Fooi.Name = "txtb_Fooi";
            txtb_Fooi.Size = new System.Drawing.Size(228, 31);
            txtb_Fooi.TabIndex = 14;
            txtb_Fooi.KeyPress += txtb_fooi_KeyPress;
            // 
            // bttn_Split
            // 
            bttn_Split.Location = new System.Drawing.Point(59, 61);
            bttn_Split.Name = "bttn_Split";
            bttn_Split.Size = new System.Drawing.Size(147, 34);
            bttn_Split.TabIndex = 15;
            bttn_Split.Text = "Split rekening";
            bttn_Split.UseVisualStyleBackColor = true;
            bttn_Split.Click += bttn_Split_Click;
            // 
            // txtb_Split
            // 
            txtb_Split.Location = new System.Drawing.Point(232, 64);
            txtb_Split.Name = "txtb_Split";
            txtb_Split.Size = new System.Drawing.Size(87, 31);
            txtb_Split.TabIndex = 16;
            txtb_Split.KeyPress += txtb_Split_KeyPress;
            // 
            // PopUpPayment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(574, 294);
            Controls.Add(txtb_Split);
            Controls.Add(bttn_Split);
            Controls.Add(txtb_Fooi);
            Controls.Add(lbl_fooi);
            Controls.Add(lbl_chooseamount);
            Controls.Add(lbl_AmountUnpaid);
            Controls.Add(txtb_Payment);
            Controls.Add(bttn_Pin);
            Controls.Add(bttn_Cash);
            Controls.Add(exitPopUpBtn);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MinimizeBox = false;
            Name = "PopUpPayment";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "PopUpPayment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BottomLeftRoundedButton exitPopUpBtn;
        private PillButton bttn_Cash;
        private PillButton bttn_Pin;
        private System.Windows.Forms.TextBox txtb_Payment;
        private System.Windows.Forms.Label lbl_AmountUnpaid;
        private System.Windows.Forms.Label lbl_chooseamount;
        private System.Windows.Forms.Label lbl_fooi;
        private System.Windows.Forms.TextBox txtb_Fooi;
        private System.Windows.Forms.Button bttn_Split;
        private System.Windows.Forms.TextBox txtb_Split;
    }
}