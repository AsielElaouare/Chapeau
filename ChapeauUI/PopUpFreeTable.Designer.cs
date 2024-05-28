namespace ChapeauUI
{
    partial class PopUpFreeTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopUpFreeTable));
            StartOrderBtn = new PillButton();
            MarkTableOccupiedBtn = new PillButton();
            tableLbl = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // StartOrderBtn
            // 
            StartOrderBtn.BackColor = System.Drawing.Color.Black;
            StartOrderBtn.FlatAppearance.BorderSize = 0;
            StartOrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            StartOrderBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            StartOrderBtn.ForeColor = System.Drawing.Color.White;
            StartOrderBtn.Image = (System.Drawing.Image)resources.GetObject("StartOrderBtn.Image");
            StartOrderBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            StartOrderBtn.Location = new System.Drawing.Point(80, 78);
            StartOrderBtn.Name = "StartOrderBtn";
            StartOrderBtn.Size = new System.Drawing.Size(272, 38);
            StartOrderBtn.TabIndex = 0;
            StartOrderBtn.Text = "Start bestelling";
            StartOrderBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            StartOrderBtn.UseVisualStyleBackColor = false;
            StartOrderBtn.Click += StartOrderBtn_Click;
            // 
            // MarkTableOccupiedBtn
            // 
            MarkTableOccupiedBtn.BackColor = System.Drawing.Color.Black;
            MarkTableOccupiedBtn.FlatAppearance.BorderSize = 0;
            MarkTableOccupiedBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            MarkTableOccupiedBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MarkTableOccupiedBtn.ForeColor = System.Drawing.Color.White;
            MarkTableOccupiedBtn.Image = (System.Drawing.Image)resources.GetObject("MarkTableOccupiedBtn.Image");
            MarkTableOccupiedBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            MarkTableOccupiedBtn.Location = new System.Drawing.Point(80, 153);
            MarkTableOccupiedBtn.Name = "MarkTableOccupiedBtn";
            MarkTableOccupiedBtn.Size = new System.Drawing.Size(272, 38);
            MarkTableOccupiedBtn.TabIndex = 1;
            MarkTableOccupiedBtn.Text = "Bezet markeren";
            MarkTableOccupiedBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            MarkTableOccupiedBtn.UseVisualStyleBackColor = false;
            MarkTableOccupiedBtn.Click += MarkTableOccupiedBtn_Click;
            // 
            // tableLbl
            // 
            tableLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tableLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            tableLbl.Location = new System.Drawing.Point(80, 26);
            tableLbl.Name = "tableLbl";
            tableLbl.Size = new System.Drawing.Size(272, 30);
            tableLbl.TabIndex = 2;
            tableLbl.Text = "Tafel";
            tableLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PopUpFreeTable
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
            ClientSize = new System.Drawing.Size(432, 210);
            Controls.Add(tableLbl);
            Controls.Add(MarkTableOccupiedBtn);
            Controls.Add(StartOrderBtn);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "PopUpFreeTable";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "PopUpFreeTable";
            Deactivate += PopUpFreeTable_Deactivate;
            ResumeLayout(false);
        }

        #endregion

        private PillButton StartOrderBtn;
        private PillButton MarkTableOccupiedBtn;
        private System.Windows.Forms.Label tableLbl;
    }
}