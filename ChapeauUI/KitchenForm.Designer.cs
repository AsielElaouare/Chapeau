﻿namespace ChapeauUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitchenForm));
            historyOrders = new System.Windows.Forms.Button();
            openOrdersLabel = new System.Windows.Forms.Label();
            flowLayoutKitchenPnl = new System.Windows.Forms.FlowLayoutPanel();
            logOutBtn = new BottomLeftRoundedButton();
            SuspendLayout();
            // 
            // historyOrders
            // 
            historyOrders.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            historyOrders.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            historyOrders.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            historyOrders.Location = new System.Drawing.Point(12, 12);
            historyOrders.Name = "historyOrders";
            historyOrders.Size = new System.Drawing.Size(136, 34);
            historyOrders.TabIndex = 0;
            historyOrders.Text = "Geschiedenis";
            historyOrders.UseVisualStyleBackColor = false;
            historyOrders.Click += historyOrders_Click;
            // 
            // openOrdersLabel
            // 
            openOrdersLabel.AutoSize = true;
            openOrdersLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            openOrdersLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            openOrdersLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            openOrdersLabel.Location = new System.Drawing.Point(670, 19);
            openOrdersLabel.Name = "openOrdersLabel";
            openOrdersLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 2);
            openOrdersLabel.Size = new System.Drawing.Size(77, 27);
            openOrdersLabel.TabIndex = 1;
            openOrdersLabel.Text = "Open: ";
            openOrdersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutKitchenPnl
            // 
            flowLayoutKitchenPnl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutKitchenPnl.AutoScroll = true;
            flowLayoutKitchenPnl.Location = new System.Drawing.Point(12, 65);
            flowLayoutKitchenPnl.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            flowLayoutKitchenPnl.MinimumSize = new System.Drawing.Size(100, 0);
            flowLayoutKitchenPnl.Name = "flowLayoutKitchenPnl";
            flowLayoutKitchenPnl.Size = new System.Drawing.Size(1436, 532);
            flowLayoutKitchenPnl.TabIndex = 2;
            flowLayoutKitchenPnl.WrapContents = false;
            // 
            // logOutBtn
            // 
            logOutBtn.BackColor = System.Drawing.Color.FromArgb(255, 20, 20);
            logOutBtn.BackgroundImage = (System.Drawing.Image)resources.GetObject("logOutBtn.BackgroundImage");
            logOutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            logOutBtn.FlatAppearance.BorderSize = 0;
            logOutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            logOutBtn.Location = new System.Drawing.Point(1425, -2);
            logOutBtn.Name = "logOutBtn";
            logOutBtn.Size = new System.Drawing.Size(48, 48);
            logOutBtn.TabIndex = 3;
            logOutBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            logOutBtn.UseVisualStyleBackColor = false;
            logOutBtn.Click += logOutBtn_Click;
            // 
            // KitchenForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1473, 610);
            ControlBox = false;
            Controls.Add(logOutBtn);
            Controls.Add(flowLayoutKitchenPnl);
            Controls.Add(openOrdersLabel);
            Controls.Add(historyOrders);
            Name = "KitchenForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button historyOrders;
        private System.Windows.Forms.Label openOrdersLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutKitchenPnl;
        private BottomLeftRoundedButton logOutBtn;
    }
}