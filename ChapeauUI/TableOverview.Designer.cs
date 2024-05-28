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
            OpenLegendBtn = new BottomRightRoundedButton();
            logOutBtn = new BottomLeftRoundedButton();
            bottomRoundedButton1 = new BottomRoundedButton();
            IndicateEntranceLeftPnl = new System.Windows.Forms.Panel();
            IndicateEntranceRightPnl = new System.Windows.Forms.Panel();
            SuspendLayout();
            // 
            // OpenLegendBtn
            // 
            OpenLegendBtn.BackColor = System.Drawing.Color.FromArgb(201, 126, 13);
            OpenLegendBtn.BackgroundImage = (System.Drawing.Image)resources.GetObject("OpenLegendBtn.BackgroundImage");
            OpenLegendBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            OpenLegendBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            OpenLegendBtn.FlatAppearance.BorderSize = 0;
            OpenLegendBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            OpenLegendBtn.ForeColor = System.Drawing.Color.Transparent;
            OpenLegendBtn.Location = new System.Drawing.Point(0, 0);
            OpenLegendBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            OpenLegendBtn.Name = "OpenLegendBtn";
            OpenLegendBtn.Size = new System.Drawing.Size(48, 48);
            OpenLegendBtn.TabIndex = 0;
            OpenLegendBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            OpenLegendBtn.UseVisualStyleBackColor = false;
            OpenLegendBtn.Click += OpenLegendBtn_Click;
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
            BackColor = System.Drawing.Color.FromArgb(252, 246, 245);
            ClientSize = new System.Drawing.Size(1133, 744);
            Controls.Add(IndicateEntranceRightPnl);
            Controls.Add(IndicateEntranceLeftPnl);
            Controls.Add(bottomRoundedButton1);
            Controls.Add(logOutBtn);
            Controls.Add(OpenLegendBtn);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "TableOverview";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "TableOverview";
            ResumeLayout(false);
        }

        #endregion

        private BottomRightRoundedButton OpenLegendBtn;
        private BottomLeftRoundedButton logOutBtn;
        private BottomRoundedButton bottomRoundedButton1;
        private System.Windows.Forms.Panel IndicateEntranceLeftPnl;
        private System.Windows.Forms.Panel IndicateEntranceRightPnl;
    }
}