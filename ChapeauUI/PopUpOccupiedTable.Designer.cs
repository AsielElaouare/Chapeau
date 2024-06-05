namespace ChapeauUI
{
    partial class PopUpOccupiedTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopUpOccupiedTable));
            tableLbl = new System.Windows.Forms.Label();
            OrderBtn = new PillButton();
            RecieptBtn = new PillButton();
            exitPopUpBtn = new BottomLeftRoundedButton();
            SuspendLayout();
            // 
            // tableLbl
            // 
            tableLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tableLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            tableLbl.Location = new System.Drawing.Point(80, 26);
            tableLbl.Name = "tableLbl";
            tableLbl.Size = new System.Drawing.Size(272, 30);
            tableLbl.TabIndex = 3;
            tableLbl.Text = "Tafel";
            tableLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OrderBtn
            // 
            OrderBtn.BackColor = System.Drawing.Color.Black;
            OrderBtn.FlatAppearance.BorderSize = 0;
            OrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            OrderBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            OrderBtn.ForeColor = System.Drawing.Color.White;
            OrderBtn.Image = (System.Drawing.Image)resources.GetObject("OrderBtn.Image");
            OrderBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            OrderBtn.Location = new System.Drawing.Point(80, 78);
            OrderBtn.Name = "OrderBtn";
            OrderBtn.Size = new System.Drawing.Size(272, 38);
            OrderBtn.TabIndex = 4;
            OrderBtn.Text = "Bestellen";
            OrderBtn.UseVisualStyleBackColor = false;
            OrderBtn.Click += OrderBtn_Click;
            // 
            // RecieptBtn
            // 
            RecieptBtn.BackColor = System.Drawing.Color.Black;
            RecieptBtn.FlatAppearance.BorderSize = 0;
            RecieptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            RecieptBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            RecieptBtn.ForeColor = System.Drawing.Color.White;
            RecieptBtn.Image = (System.Drawing.Image)resources.GetObject("RecieptBtn.Image");
            RecieptBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            RecieptBtn.Location = new System.Drawing.Point(80, 153);
            RecieptBtn.Name = "RecieptBtn";
            RecieptBtn.Size = new System.Drawing.Size(272, 38);
            RecieptBtn.TabIndex = 5;
            RecieptBtn.Text = "Bon";
            RecieptBtn.UseVisualStyleBackColor = false;
            RecieptBtn.Click += RecieptBtn_Click;
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
            exitPopUpBtn.TabIndex = 6;
            exitPopUpBtn.UseVisualStyleBackColor = false;
            exitPopUpBtn.Click += exitPopUpBtn_Click;
            // 
            // PopUpOccupiedTable
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
            ClientSize = new System.Drawing.Size(432, 210);
            Controls.Add(exitPopUpBtn);
            Controls.Add(RecieptBtn);
            Controls.Add(OrderBtn);
            Controls.Add(tableLbl);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "PopUpOccupiedTable";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "PupUpOccupiedTable";
            Deactivate += PopUpOccupiedTable_Deactivate;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label tableLbl;
        private PillButton OrderBtn;
        private PillButton RecieptBtn;
        private BottomLeftRoundedButton exitPopUpBtn;
    }
}