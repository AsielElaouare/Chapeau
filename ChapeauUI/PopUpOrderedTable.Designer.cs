﻿namespace ChapeauUI
{
    partial class PopUpOrderedTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopUpOrderedTable));
            tableLbl = new System.Windows.Forms.Label();
            OrderBtn = new PillButton();
            BillBtn = new PillButton();
            BarBtn = new PillButton();
            KitchenBtn = new PillButton();
            exitPopUpBtn = new BottomLeftRoundedButton();
            SuspendLayout();
            // 
            // tableLbl
            // 
            tableLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tableLbl.Location = new System.Drawing.Point(0, 20);
            tableLbl.Name = "tableLbl";
            tableLbl.Size = new System.Drawing.Size(432, 30);
            tableLbl.TabIndex = 0;
            tableLbl.Text = "Table";
            tableLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // OrderBtn
            // 
            OrderBtn.BackColor = System.Drawing.Color.Black;
            OrderBtn.FlatAppearance.BorderSize = 0;
            OrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            OrderBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            OrderBtn.ForeColor = System.Drawing.Color.White;
            OrderBtn.Image = (System.Drawing.Image)resources.GetObject("OrderBtn.Image");
            OrderBtn.Location = new System.Drawing.Point(80, 49);
            OrderBtn.Name = "OrderBtn";
            OrderBtn.Size = new System.Drawing.Size(272, 38);
            OrderBtn.TabIndex = 1;
            OrderBtn.Text = "Bestellen";
            OrderBtn.UseVisualStyleBackColor = false;
            OrderBtn.Click += OrderBtn_Click;
            // 
            // BillBtn
            // 
            BillBtn.BackColor = System.Drawing.Color.Black;
            BillBtn.FlatAppearance.BorderSize = 0;
            BillBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BillBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BillBtn.ForeColor = System.Drawing.Color.White;
            BillBtn.Image = (System.Drawing.Image)resources.GetObject("BillBtn.Image");
            BillBtn.Location = new System.Drawing.Point(80, 165);
            BillBtn.Name = "BillBtn";
            BillBtn.Size = new System.Drawing.Size(272, 38);
            BillBtn.TabIndex = 2;
            BillBtn.Text = "Bon";
            BillBtn.UseVisualStyleBackColor = false;
            BillBtn.Click += BillBtn_Click;
            // 
            // BarBtn
            // 
            BarBtn.BackColor = System.Drawing.Color.Black;
            BarBtn.FlatAppearance.BorderSize = 0;
            BarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BarBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BarBtn.ForeColor = System.Drawing.Color.White;
            BarBtn.Image = (System.Drawing.Image)resources.GetObject("BarBtn.Image");
            BarBtn.Location = new System.Drawing.Point(80, 109);
            BarBtn.Name = "BarBtn";
            BarBtn.Size = new System.Drawing.Size(134, 38);
            BarBtn.TabIndex = 3;
            BarBtn.Text = "Bar";
            BarBtn.UseVisualStyleBackColor = false;
            BarBtn.Click += BarBtn_Click;
            // 
            // KitchenBtn
            // 
            KitchenBtn.BackColor = System.Drawing.Color.Black;
            KitchenBtn.FlatAppearance.BorderSize = 0;
            KitchenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            KitchenBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            KitchenBtn.ForeColor = System.Drawing.Color.White;
            KitchenBtn.Image = (System.Drawing.Image)resources.GetObject("KitchenBtn.Image");
            KitchenBtn.Location = new System.Drawing.Point(218, 109);
            KitchenBtn.Name = "KitchenBtn";
            KitchenBtn.Size = new System.Drawing.Size(134, 38);
            KitchenBtn.TabIndex = 4;
            KitchenBtn.Text = "Keuken";
            KitchenBtn.UseVisualStyleBackColor = false;
            KitchenBtn.Click += KitchenBtn_Click;
            // 
            // exitPopUpBtn
            // 
            exitPopUpBtn.BackColor = System.Drawing.Color.FromArgb(255, 20, 20);
            exitPopUpBtn.BackgroundImage = (System.Drawing.Image)resources.GetObject("exitPopUpBtn.BackgroundImage");
            exitPopUpBtn.FlatAppearance.BorderSize = 0;
            exitPopUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            exitPopUpBtn.Location = new System.Drawing.Point(384, 0);
            exitPopUpBtn.Name = "exitPopUpBtn";
            exitPopUpBtn.Size = new System.Drawing.Size(48, 48);
            exitPopUpBtn.TabIndex = 5;
            exitPopUpBtn.UseVisualStyleBackColor = false;
            exitPopUpBtn.Click += exitPopUpBtn_Click;
            // 
            // PopUpOrderedTable
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
            ClientSize = new System.Drawing.Size(432, 226);
            Controls.Add(exitPopUpBtn);
            Controls.Add(KitchenBtn);
            Controls.Add(BarBtn);
            Controls.Add(BillBtn);
            Controls.Add(OrderBtn);
            Controls.Add(tableLbl);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "PopUpOrderedTable";
            RightToLeft = System.Windows.Forms.RightToLeft.No;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "PopUpOrderedTable";
            Deactivate += PopUpOrderedTable_Deactivate;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label tableLbl;
        private PillButton OrderBtn;
        private PillButton BillBtn;
        private PillButton BarBtn;
        private PillButton KitchenBtn;
        private BottomLeftRoundedButton exitPopUpBtn;
    }
}