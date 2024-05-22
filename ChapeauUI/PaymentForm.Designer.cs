namespace ChapeauUI
{
    partial class PaymentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentForm));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            lbl_tijd = new System.Windows.Forms.Label();
            listView1 = new System.Windows.Forms.ListView();
            lbl_Total = new System.Windows.Forms.Label();
            lbl_BTW = new System.Windows.Forms.Label();
            lbl_Waiter = new System.Windows.Forms.Label();
            lbl_Table = new System.Windows.Forms.Label();
            lbl_ReceiptNumber = new System.Windows.Forms.Label();
            bttn_payment = new System.Windows.Forms.Button();
            bttn_Split = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(800, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(310, 210);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lbl_tijd
            // 
            lbl_tijd.AutoSize = true;
            lbl_tijd.Location = new System.Drawing.Point(967, 654);
            lbl_tijd.Name = "lbl_tijd";
            lbl_tijd.Size = new System.Drawing.Size(123, 25);
            lbl_tijd.TabIndex = 1;
            lbl_tijd.Text = "xx/xx/xxx xx:xx";
            lbl_tijd.Click += label1_Click;
            // 
            // listView1
            // 
            listView1.Location = new System.Drawing.Point(30, 199);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(431, 215);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // lbl_Total
            // 
            lbl_Total.AutoSize = true;
            lbl_Total.Location = new System.Drawing.Point(32, 434);
            lbl_Total.Name = "lbl_Total";
            lbl_Total.Size = new System.Drawing.Size(67, 25);
            lbl_Total.TabIndex = 3;
            lbl_Total.Text = "Totaal: ";
            // 
            // lbl_BTW
            // 
            lbl_BTW.AutoSize = true;
            lbl_BTW.Location = new System.Drawing.Point(32, 473);
            lbl_BTW.Name = "lbl_BTW";
            lbl_BTW.Size = new System.Drawing.Size(56, 25);
            lbl_BTW.TabIndex = 4;
            lbl_BTW.Text = "BTW: ";
            // 
            // lbl_Waiter
            // 
            lbl_Waiter.AutoSize = true;
            lbl_Waiter.Location = new System.Drawing.Point(50, 33);
            lbl_Waiter.Name = "lbl_Waiter";
            lbl_Waiter.Size = new System.Drawing.Size(146, 25);
            lbl_Waiter.TabIndex = 5;
            lbl_Waiter.Text = "Gastheer/vrouw: ";
            // 
            // lbl_Table
            // 
            lbl_Table.AutoSize = true;
            lbl_Table.Location = new System.Drawing.Point(50, 69);
            lbl_Table.Name = "lbl_Table";
            lbl_Table.Size = new System.Drawing.Size(56, 25);
            lbl_Table.TabIndex = 6;
            lbl_Table.Text = "Tafel: ";
            // 
            // lbl_ReceiptNumber
            // 
            lbl_ReceiptNumber.AutoSize = true;
            lbl_ReceiptNumber.Location = new System.Drawing.Point(50, 105);
            lbl_ReceiptNumber.Name = "lbl_ReceiptNumber";
            lbl_ReceiptNumber.Size = new System.Drawing.Size(96, 25);
            lbl_ReceiptNumber.TabIndex = 7;
            lbl_ReceiptNumber.Text = "Bestelling: ";
            // 
            // bttn_payment
            // 
            bttn_payment.Location = new System.Drawing.Point(164, 562);
            bttn_payment.Name = "bttn_payment";
            bttn_payment.Size = new System.Drawing.Size(187, 66);
            bttn_payment.TabIndex = 8;
            bttn_payment.Text = "Betalen";
            bttn_payment.UseVisualStyleBackColor = true;
            // 
            // bttn_Split
            // 
            bttn_Split.Location = new System.Drawing.Point(472, 562);
            bttn_Split.Name = "bttn_Split";
            bttn_Split.Size = new System.Drawing.Size(187, 66);
            bttn_Split.TabIndex = 9;
            bttn_Split.Text = "Splitten";
            bttn_Split.UseVisualStyleBackColor = true;
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1111, 688);
            Controls.Add(bttn_Split);
            Controls.Add(bttn_payment);
            Controls.Add(lbl_ReceiptNumber);
            Controls.Add(lbl_Table);
            Controls.Add(lbl_Waiter);
            Controls.Add(lbl_BTW);
            Controls.Add(lbl_Total);
            Controls.Add(listView1);
            Controls.Add(lbl_tijd);
            Controls.Add(pictureBox1);
            Name = "PaymentForm";
            Text = "PaymentForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_tijd;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.Label lbl_BTW;
        private System.Windows.Forms.Label lbl_Waiter;
        private System.Windows.Forms.Label lbl_Table;
        private System.Windows.Forms.Label lbl_ReceiptNumber;
        private System.Windows.Forms.Button bttn_payment;
        private System.Windows.Forms.Button bttn_Split;
    }
}