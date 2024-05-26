namespace ChapeauUI
{
    partial class TableOverview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableOverview));
            bottomRightRoundedButton1 = new BottomRightRoundedButton();
            logOutBtn = new BottomLeftRoundedButton();
            bottomRoundedButton1 = new BottomRoundedButton();
            IndicateEntranceLeftPnl = new System.Windows.Forms.Panel();
            IndicateEntranceRightPnl = new System.Windows.Forms.Panel();
            SuspendLayout();
            // 
            // bottomRightRoundedButton1
            // 
            bottomRightRoundedButton1.BackColor = System.Drawing.Color.FromArgb(201, 126, 13);
            bottomRightRoundedButton1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bottomRightRoundedButton1.BackgroundImage");
            bottomRightRoundedButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            bottomRightRoundedButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            bottomRightRoundedButton1.FlatAppearance.BorderSize = 0;
            bottomRightRoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bottomRightRoundedButton1.ForeColor = System.Drawing.Color.Transparent;
            bottomRightRoundedButton1.Location = new System.Drawing.Point(0, 0);
            bottomRightRoundedButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            bottomRightRoundedButton1.Name = "bottomRightRoundedButton1";
            bottomRightRoundedButton1.Size = new System.Drawing.Size(48, 48);
            bottomRightRoundedButton1.TabIndex = 0;
            bottomRightRoundedButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            bottomRightRoundedButton1.UseVisualStyleBackColor = false;
            // 
            // logOutBtn
            // 
            logOutBtn.BackColor = System.Drawing.Color.FromArgb(255, 20, 20);
            logOutBtn.BackgroundImage = (System.Drawing.Image)resources.GetObject("logOutBtn.BackgroundImage");
            logOutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            logOutBtn.FlatAppearance.BorderSize = 0;
            logOutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            logOutBtn.Location = new System.Drawing.Point(1085, 0);
            logOutBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            logOutBtn.Name = "logOutBtn";
            logOutBtn.Size = new System.Drawing.Size(48, 48);
            logOutBtn.TabIndex = 1;
            logOutBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            logOutBtn.UseVisualStyleBackColor = false;
            logOutBtn.Click += logOutBtn_Click;
            // 
            // bottomRoundedButton1
            // 
            bottomRoundedButton1.BackColor = System.Drawing.Color.FromArgb(12, 18, 150);
            bottomRoundedButton1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bottomRoundedButton1.BackgroundImage");
            bottomRoundedButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            bottomRoundedButton1.FlatAppearance.BorderSize = 0;
            bottomRoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bottomRoundedButton1.Location = new System.Drawing.Point(50, 0);
            bottomRoundedButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            bottomRoundedButton1.Name = "bottomRoundedButton1";
            bottomRoundedButton1.Size = new System.Drawing.Size(48, 48);
            bottomRoundedButton1.TabIndex = 2;
            bottomRoundedButton1.Text = "bottomRoundedButton1";
            bottomRoundedButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            bottomRoundedButton1.UseVisualStyleBackColor = false;
            // 
            // IndicateEntranceLeftPnl
            // 
            IndicateEntranceLeftPnl.BackColor = System.Drawing.Color.Black;
            IndicateEntranceLeftPnl.Location = new System.Drawing.Point(864, 714);
            IndicateEntranceLeftPnl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            IndicateEntranceLeftPnl.Name = "IndicateEntranceLeftPnl";
            IndicateEntranceLeftPnl.Size = new System.Drawing.Size(15, 30);
            IndicateEntranceLeftPnl.TabIndex = 4;
            // 
            // IndicateEntranceRightPnl
            // 
            IndicateEntranceRightPnl.BackColor = System.Drawing.Color.Black;
            IndicateEntranceRightPnl.Location = new System.Drawing.Point(999, 714);
            IndicateEntranceRightPnl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            IndicateEntranceRightPnl.Name = "IndicateEntranceRightPnl";
            IndicateEntranceRightPnl.Size = new System.Drawing.Size(15, 30);
            IndicateEntranceRightPnl.TabIndex = 5;
            // 
            // TableOverview
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1133, 744);
            Controls.Add(IndicateEntranceRightPnl);
            Controls.Add(IndicateEntranceLeftPnl);
            Controls.Add(bottomRoundedButton1);
            Controls.Add(logOutBtn);
            Controls.Add(bottomRightRoundedButton1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "TableOverview";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "TableOverview";
            ResumeLayout(false);
        }

        #endregion

        private BottomRightRoundedButton bottomRightRoundedButton1;
        private BottomLeftRoundedButton logOutBtn;
        private BottomRoundedButton bottomRoundedButton1;
        private System.Windows.Forms.Panel IndicateEntranceLeftPnl;
        private System.Windows.Forms.Panel IndicateEntranceRightPnl;
    }
}