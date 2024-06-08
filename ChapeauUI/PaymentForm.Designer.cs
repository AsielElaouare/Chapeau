﻿namespace ChapeauUI
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
            listview_Bestelling = new System.Windows.Forms.ListView();
            column_Items = new System.Windows.Forms.ColumnHeader();
            column_Aantal = new System.Windows.Forms.ColumnHeader();
            column_Prijs = new System.Windows.Forms.ColumnHeader();
            column_Openstaand = new System.Windows.Forms.ColumnHeader();
            lbl_Total = new System.Windows.Forms.Label();
            lbl_BTW = new System.Windows.Forms.Label();
            lbl_Waiter = new System.Windows.Forms.Label();
            lbl_Table = new System.Windows.Forms.Label();
            lbl_ReceiptNumber = new System.Windows.Forms.Label();
            bttn_payment = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            bttn_PauzeerBetaling = new System.Windows.Forms.Button();
            textBox1 = new System.Windows.Forms.TextBox();
            lbl_Review = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(762, 540);
            pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(351, 189);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // listview_Bestelling
            // 
            listview_Bestelling.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { column_Items, column_Aantal, column_Prijs, column_Openstaand });
            listview_Bestelling.Location = new System.Drawing.Point(35, 144);
            listview_Bestelling.Margin = new System.Windows.Forms.Padding(2);
            listview_Bestelling.Name = "listview_Bestelling";
            listview_Bestelling.Size = new System.Drawing.Size(802, 357);
            listview_Bestelling.TabIndex = 2;
            listview_Bestelling.UseCompatibleStateImageBehavior = false;
            listview_Bestelling.View = System.Windows.Forms.View.Details;
            // 
            // column_Items
            // 
            column_Items.Text = "Items";
            // 
            // column_Aantal
            // 
            column_Aantal.Text = "Aantal";
            // 
            // column_Prijs
            // 
            column_Prijs.Text = "Prijs";
            // 
            // column_Openstaand
            // 
            column_Openstaand.Text = "Openstaand";
            column_Openstaand.Width = 80;
            // 
            // lbl_Total
            // 
            lbl_Total.AutoSize = true;
            lbl_Total.Location = new System.Drawing.Point(35, 540);
            lbl_Total.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lbl_Total.Name = "lbl_Total";
            lbl_Total.Size = new System.Drawing.Size(44, 15);
            lbl_Total.TabIndex = 3;
            lbl_Total.Text = "Totaal: ";
            // 
            // lbl_BTW
            // 
            lbl_BTW.AutoSize = true;
            lbl_BTW.Location = new System.Drawing.Point(35, 567);
            lbl_BTW.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lbl_BTW.Name = "lbl_BTW";
            lbl_BTW.Size = new System.Drawing.Size(36, 15);
            lbl_BTW.TabIndex = 4;
            lbl_BTW.Text = "BTW: ";
            // 
            // lbl_Waiter
            // 
            lbl_Waiter.AutoSize = true;
            lbl_Waiter.Location = new System.Drawing.Point(35, 118);
            lbl_Waiter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lbl_Waiter.Name = "lbl_Waiter";
            lbl_Waiter.Size = new System.Drawing.Size(97, 15);
            lbl_Waiter.TabIndex = 5;
            lbl_Waiter.Text = "Gastheer/vrouw: ";
            // 
            // lbl_Table
            // 
            lbl_Table.AutoSize = true;
            lbl_Table.Location = new System.Drawing.Point(312, 118);
            lbl_Table.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lbl_Table.Name = "lbl_Table";
            lbl_Table.Size = new System.Drawing.Size(37, 15);
            lbl_Table.TabIndex = 6;
            lbl_Table.Text = "Tafel: ";
            // 
            // lbl_ReceiptNumber
            // 
            lbl_ReceiptNumber.AutoSize = true;
            lbl_ReceiptNumber.Location = new System.Drawing.Point(563, 118);
            lbl_ReceiptNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lbl_ReceiptNumber.Name = "lbl_ReceiptNumber";
            lbl_ReceiptNumber.Size = new System.Drawing.Size(80, 15);
            lbl_ReceiptNumber.TabIndex = 7;
            lbl_ReceiptNumber.Text = "Bon nummer:";
            lbl_ReceiptNumber.Click += lbl_ReceiptNumber_Click;
            // 
            // bttn_payment
            // 
            bttn_payment.Location = new System.Drawing.Point(886, 425);
            bttn_payment.Margin = new System.Windows.Forms.Padding(2);
            bttn_payment.Name = "bttn_payment";
            bttn_payment.Size = new System.Drawing.Size(131, 40);
            bttn_payment.TabIndex = 8;
            bttn_payment.Text = "Betalen";
            bttn_payment.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.Firebrick;
            button2.Location = new System.Drawing.Point(924, 375);
            button2.Margin = new System.Windows.Forms.Padding(2);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(0, 0);
            button2.TabIndex = 11;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = System.Drawing.Color.Firebrick;
            button3.Location = new System.Drawing.Point(924, 469);
            button3.Margin = new System.Windows.Forms.Padding(2);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(0, 0);
            button3.TabIndex = 12;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = System.Drawing.Color.Gainsboro;
            button4.Location = new System.Drawing.Point(855, 133);
            button4.Margin = new System.Windows.Forms.Padding(2);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(188, 110);
            button4.TabIndex = 13;
            button4.Text = "splitten";
            button4.UseVisualStyleBackColor = false;
            // 
            // bttn_PauzeerBetaling
            // 
            bttn_PauzeerBetaling.BackColor = System.Drawing.Color.LightGray;
            bttn_PauzeerBetaling.Location = new System.Drawing.Point(855, 265);
            bttn_PauzeerBetaling.Margin = new System.Windows.Forms.Padding(2);
            bttn_PauzeerBetaling.Name = "bttn_PauzeerBetaling";
            bttn_PauzeerBetaling.Size = new System.Drawing.Size(188, 110);
            bttn_PauzeerBetaling.TabIndex = 14;
            bttn_PauzeerBetaling.Text = "keer terug naar tafeloverzicht";
            bttn_PauzeerBetaling.UseVisualStyleBackColor = false;
            bttn_PauzeerBetaling.Click += bttn_PauzeerBetaling_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(218, 564);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(492, 150);
            textBox1.TabIndex = 15;
            // 
            // lbl_Review
            // 
            lbl_Review.AutoSize = true;
            lbl_Review.Location = new System.Drawing.Point(218, 540);
            lbl_Review.Name = "lbl_Review";
            lbl_Review.Size = new System.Drawing.Size(47, 15);
            lbl_Review.TabIndex = 16;
            lbl_Review.Text = "Review:";
            // 
            // PaymentForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1133, 740);
            ControlBox = false;
            Controls.Add(lbl_Review);
            Controls.Add(textBox1);
            Controls.Add(bttn_PauzeerBetaling);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(bttn_payment);
            Controls.Add(lbl_ReceiptNumber);
            Controls.Add(lbl_Table);
            Controls.Add(lbl_Waiter);
            Controls.Add(lbl_BTW);
            Controls.Add(lbl_Total);
            Controls.Add(listview_Bestelling);
            Controls.Add(pictureBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(2);
            Name = "PaymentForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Load += PaymentForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView listview_Bestelling;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.Label lbl_BTW;
        private System.Windows.Forms.Label lbl_Waiter;
        private System.Windows.Forms.Label lbl_Table;
        private System.Windows.Forms.Label lbl_ReceiptNumber;
        private System.Windows.Forms.Button bttn_payment;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColumnHeader column_Items;
        private System.Windows.Forms.ColumnHeader column_Aantal;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button bttn_PauzeerBetaling;
        private System.Windows.Forms.ColumnHeader column_Prijs;
        private System.Windows.Forms.ColumnHeader column_Openstaand;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_Review;
    }
}