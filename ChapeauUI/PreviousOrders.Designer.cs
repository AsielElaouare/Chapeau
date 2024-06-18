namespace ChapeauUI
{
    partial class PreviousOrders
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
            flowLayoutPreviousOrdersPanel = new System.Windows.Forms.FlowLayoutPanel();
            goBackBtn = new System.Windows.Forms.Button();
            PreviousOrdersLabel = new System.Windows.Forms.Label();
            madeOrdersLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // flowLayoutPreviousOrdersPanel
            // 
            flowLayoutPreviousOrdersPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPreviousOrdersPanel.AutoScroll = true;
            flowLayoutPreviousOrdersPanel.Location = new System.Drawing.Point(6, 117);
            flowLayoutPreviousOrdersPanel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            flowLayoutPreviousOrdersPanel.Name = "flowLayoutPreviousOrdersPanel";
            flowLayoutPreviousOrdersPanel.Size = new System.Drawing.Size(2698, 1167);
            flowLayoutPreviousOrdersPanel.TabIndex = 0;
            flowLayoutPreviousOrdersPanel.WrapContents = false;
            // 
            // goBackBtn
            // 
            goBackBtn.BackColor = System.Drawing.Color.IndianRed;
            goBackBtn.ForeColor = System.Drawing.Color.Transparent;
            goBackBtn.Location = new System.Drawing.Point(22, 26);
            goBackBtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            goBackBtn.Name = "goBackBtn";
            goBackBtn.Size = new System.Drawing.Size(217, 60);
            goBackBtn.TabIndex = 1;
            goBackBtn.Text = "Huidige Orders";
            goBackBtn.UseVisualStyleBackColor = false;
            goBackBtn.Click += goBackBtn_Click;
            // 
            // PreviousOrdersLabel
            // 
            PreviousOrdersLabel.AutoSize = true;
            PreviousOrdersLabel.Location = new System.Drawing.Point(1192, 41);
            PreviousOrdersLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            PreviousOrdersLabel.Name = "PreviousOrdersLabel";
            PreviousOrdersLabel.Size = new System.Drawing.Size(0, 32);
            PreviousOrdersLabel.TabIndex = 2;
            // 
            // madeOrdersLabel
            // 
            madeOrdersLabel.AutoSize = true;
            madeOrdersLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            madeOrdersLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            madeOrdersLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            madeOrdersLabel.Location = new System.Drawing.Point(1192, 28);
            madeOrdersLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            madeOrdersLabel.Name = "madeOrdersLabel";
            madeOrdersLabel.Padding = new System.Windows.Forms.Padding(9, 0, 9, 4);
            madeOrdersLabel.Size = new System.Drawing.Size(433, 55);
            madeOrdersLabel.TabIndex = 3;
            madeOrdersLabel.Text = "Voltooide bestellingen: ";
            madeOrdersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PreviousOrders
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(2711, 1310);
            ControlBox = false;
            Controls.Add(madeOrdersLabel);
            Controls.Add(PreviousOrdersLabel);
            Controls.Add(goBackBtn);
            Controls.Add(flowLayoutPreviousOrdersPanel);
            Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            Name = "PreviousOrders";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPreviousOrdersPanel;
        private System.Windows.Forms.Button goBackBtn;
        private System.Windows.Forms.Label PreviousOrdersLabel;
        private System.Windows.Forms.Label madeOrdersLabel;
    }
}