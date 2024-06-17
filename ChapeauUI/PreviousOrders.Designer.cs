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
            flowLayoutPreviousOrdersPanel.Location = new System.Drawing.Point(3, 55);
            flowLayoutPreviousOrdersPanel.Name = "flowLayoutPreviousOrdersPanel";
            flowLayoutPreviousOrdersPanel.Size = new System.Drawing.Size(1453, 547);
            flowLayoutPreviousOrdersPanel.TabIndex = 0;
            flowLayoutPreviousOrdersPanel.WrapContents = false;
            // 
            // goBackBtn
            // 
            goBackBtn.BackColor = System.Drawing.Color.IndianRed;
            goBackBtn.ForeColor = System.Drawing.Color.Transparent;
            goBackBtn.Location = new System.Drawing.Point(12, 12);
            goBackBtn.Name = "goBackBtn";
            goBackBtn.Size = new System.Drawing.Size(117, 28);
            goBackBtn.TabIndex = 1;
            goBackBtn.Text = "Huidige Orders";
            goBackBtn.UseVisualStyleBackColor = false;
            goBackBtn.Click += goBackBtn_Click;
            // 
            // PreviousOrdersLabel
            // 
            PreviousOrdersLabel.AutoSize = true;
            PreviousOrdersLabel.Location = new System.Drawing.Point(642, 19);
            PreviousOrdersLabel.Name = "PreviousOrdersLabel";
            PreviousOrdersLabel.Size = new System.Drawing.Size(0, 15);
            PreviousOrdersLabel.TabIndex = 2;
            // 
            // madeOrdersLabel
            // 
            madeOrdersLabel.AutoSize = true;
            madeOrdersLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            madeOrdersLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            madeOrdersLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            madeOrdersLabel.Location = new System.Drawing.Point(642, 13);
            madeOrdersLabel.Name = "madeOrdersLabel";
            madeOrdersLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 2);
            madeOrdersLabel.Size = new System.Drawing.Size(231, 27);
            madeOrdersLabel.TabIndex = 3;
            madeOrdersLabel.Text = "Vooltooide bestellingen: ";
            madeOrdersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PreviousOrders
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1460, 614);
            ControlBox = false;
            Controls.Add(madeOrdersLabel);
            Controls.Add(PreviousOrdersLabel);
            Controls.Add(goBackBtn);
            Controls.Add(flowLayoutPreviousOrdersPanel);
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