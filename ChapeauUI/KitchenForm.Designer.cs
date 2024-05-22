namespace ChapeauUI
{
    partial class KitchenForm
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
            historyOrders = new System.Windows.Forms.Button();
            openOrdersLabel = new System.Windows.Forms.Label();
            flowLayoutKitchenPnl = new System.Windows.Forms.FlowLayoutPanel();
            SuspendLayout();
            // 
            // historyOrders
            // 
            historyOrders.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            historyOrders.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            historyOrders.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            historyOrders.Location = new System.Drawing.Point(22, 26);
            historyOrders.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            historyOrders.Name = "historyOrders";
            historyOrders.Size = new System.Drawing.Size(253, 73);
            historyOrders.TabIndex = 0;
            historyOrders.Text = "Geschidenis";
            historyOrders.UseVisualStyleBackColor = false;
            // 
            // openOrdersLabel
            // 
            openOrdersLabel.AutoSize = true;
            openOrdersLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            openOrdersLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            openOrdersLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            openOrdersLabel.Location = new System.Drawing.Point(737, 45);
            openOrdersLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            openOrdersLabel.Name = "openOrdersLabel";
            openOrdersLabel.Padding = new System.Windows.Forms.Padding(9, 0, 9, 4);
            openOrdersLabel.Size = new System.Drawing.Size(151, 55);
            openOrdersLabel.TabIndex = 1;
            openOrdersLabel.Text = "Open: ";
            // 
            // flowLayoutKitchenPnl
            // 
            flowLayoutKitchenPnl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutKitchenPnl.Location = new System.Drawing.Point(22, 138);
            flowLayoutKitchenPnl.Name = "flowLayoutKitchenPnl";
            flowLayoutKitchenPnl.Size = new System.Drawing.Size(1744, 794);
            flowLayoutKitchenPnl.TabIndex = 2;
            // 
            // KitchenForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1813, 960);
            Controls.Add(flowLayoutKitchenPnl);
            Controls.Add(openOrdersLabel);
            Controls.Add(historyOrders);
            Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            Name = "KitchenForm";
            Text = "Kitchen View";
            Load += KitchenForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button historyOrders;
        private System.Windows.Forms.Label openOrdersLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutKitchenPnl;
    }
}