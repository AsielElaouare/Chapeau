namespace ChapeauUI
{
    partial class BarDisplayOrder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            OrderPanel = new System.Windows.Forms.FlowLayoutPanel();
            timeLabel = new System.Windows.Forms.Label();
            flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            orderInfLabel = new System.Windows.Forms.Label();
            drinksHeaderLabel = new System.Windows.Forms.Label();
            drinksFlowLayoutPnl = new System.Windows.Forms.FlowLayoutPanel();
            StartBtn = new System.Windows.Forms.Button();
            CompleteBtn = new System.Windows.Forms.Button();
            remakeOrderBtn = new System.Windows.Forms.Button();
            OrderPanel.SuspendLayout();
            flowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // OrderPanel
            // 
            OrderPanel.BackColor = System.Drawing.Color.Gray;
            OrderPanel.Controls.Add(timeLabel);
            OrderPanel.Controls.Add(flowLayoutPanel);
            OrderPanel.Controls.Add(StartBtn);
            OrderPanel.Controls.Add(CompleteBtn);
            OrderPanel.Controls.Add(remakeOrderBtn);
            OrderPanel.Location = new System.Drawing.Point(0, 0);
            OrderPanel.Name = "OrderPanel";
            OrderPanel.Size = new System.Drawing.Size(200, 427);
            OrderPanel.TabIndex = 0;
            // 
            // timeLabel
            // 
            timeLabel.BackColor = System.Drawing.Color.FromArgb(0, 132, 255);
            timeLabel.Location = new System.Drawing.Point(0, 0);
            timeLabel.Margin = new System.Windows.Forms.Padding(0);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new System.Drawing.Size(200, 23);
            timeLabel.TabIndex = 1;
            timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.BackColor = System.Drawing.Color.Gray;
            flowLayoutPanel.Controls.Add(orderInfLabel);
            flowLayoutPanel.Controls.Add(drinksHeaderLabel);
            flowLayoutPanel.Controls.Add(drinksFlowLayoutPnl);
            flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel.Location = new System.Drawing.Point(0, 23);
            flowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new System.Drawing.Size(200, 372);
            flowLayoutPanel.TabIndex = 4;
            // 
            // orderInfLabel
            // 
            orderInfLabel.Location = new System.Drawing.Point(0, 5);
            orderInfLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            orderInfLabel.Name = "orderInfLabel";
            orderInfLabel.Size = new System.Drawing.Size(200, 23);
            orderInfLabel.TabIndex = 9;
            // 
            // drinksHeaderLabel
            // 
            drinksHeaderLabel.BackColor = System.Drawing.Color.FromArgb(255, 143, 143);
            drinksHeaderLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            drinksHeaderLabel.Location = new System.Drawing.Point(0, 38);
            drinksHeaderLabel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            drinksHeaderLabel.Name = "drinksHeaderLabel";
            drinksHeaderLabel.Size = new System.Drawing.Size(200, 16);
            drinksHeaderLabel.TabIndex = 8;
            drinksHeaderLabel.Text = "Dranken";
            // 
            // drinksFlowLayoutPnl
            // 
            drinksFlowLayoutPnl.AutoSize = true;
            drinksFlowLayoutPnl.Location = new System.Drawing.Point(0, 54);
            drinksFlowLayoutPnl.Margin = new System.Windows.Forms.Padding(0);
            drinksFlowLayoutPnl.Name = "drinksFlowLayoutPnl";
            drinksFlowLayoutPnl.Size = new System.Drawing.Size(0, 0);
            drinksFlowLayoutPnl.TabIndex = 10;
            // 
            // StartBtn
            // 
            StartBtn.BackColor = System.Drawing.Color.FromArgb(0, 132, 255);
            StartBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            StartBtn.ForeColor = System.Drawing.Color.MintCream;
            StartBtn.Location = new System.Drawing.Point(0, 395);
            StartBtn.Margin = new System.Windows.Forms.Padding(0);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new System.Drawing.Size(75, 27);
            StartBtn.TabIndex = 6;
            StartBtn.Text = "Start";
            StartBtn.UseVisualStyleBackColor = false;
            StartBtn.Click += StartBtn_Click;
            // 
            // CompleteBtn
            // 
            CompleteBtn.BackColor = System.Drawing.Color.FromArgb(23, 185, 8);
            CompleteBtn.Enabled = false;
            CompleteBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            CompleteBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            CompleteBtn.Location = new System.Drawing.Point(125, 395);
            CompleteBtn.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            CompleteBtn.Name = "CompleteBtn";
            CompleteBtn.Size = new System.Drawing.Size(75, 27);
            CompleteBtn.TabIndex = 5;
            CompleteBtn.Text = "Compleet";
            CompleteBtn.UseVisualStyleBackColor = false;
            CompleteBtn.Click += CompleteBtn_Click;
            // 
            // remakeOrderBtn
            // 
            remakeOrderBtn.BackColor = System.Drawing.Color.FromArgb(0, 132, 255);
            remakeOrderBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            remakeOrderBtn.ForeColor = System.Drawing.Color.MintCream;
            remakeOrderBtn.Location = new System.Drawing.Point(0, 422);
            remakeOrderBtn.Margin = new System.Windows.Forms.Padding(0);
            remakeOrderBtn.Name = "remakeOrderBtn";
            remakeOrderBtn.Size = new System.Drawing.Size(200, 27);
            remakeOrderBtn.TabIndex = 7;
            remakeOrderBtn.Text = "Maak Opnieuw";
            remakeOrderBtn.UseVisualStyleBackColor = false;
            remakeOrderBtn.Visible = false;
            remakeOrderBtn.Click += remakeOrderBtn_Click;
            // 
            // BarDisplayOrder
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(OrderPanel);
            Name = "BarDisplayOrder";
            Size = new System.Drawing.Size(200, 427);
            OrderPanel.ResumeLayout(false);
            flowLayoutPanel.ResumeLayout(false);
            flowLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel OrderPanel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button CompleteBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label drinksHeaderLabel;
        private System.Windows.Forms.Label orderInfLabel;
        private System.Windows.Forms.FlowLayoutPanel drinksFlowLayoutPnl;
        private System.Windows.Forms.Button remakeOrderBtn;
    }
}
