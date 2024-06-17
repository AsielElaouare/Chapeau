namespace ChapeauUI
{
    partial class BarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarForm));
            barFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            previousOrdersBar = new System.Windows.Forms.Button();
            OpenOrdersBarLabel = new System.Windows.Forms.Label();
            logOutBtn = new BottomLeftRoundedButton();
            SuspendLayout();
            // 
            // barFlowLayoutPanel
            // 
            barFlowLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            barFlowLayoutPanel.AutoScroll = true;
            barFlowLayoutPanel.Location = new System.Drawing.Point(12, 71);
            barFlowLayoutPanel.Name = "barFlowLayoutPanel";
            barFlowLayoutPanel.Size = new System.Drawing.Size(1360, 552);
            barFlowLayoutPanel.TabIndex = 0;
            barFlowLayoutPanel.WrapContents = false;
            // 
            // previousOrdersBar
            // 
            previousOrdersBar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            previousOrdersBar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            previousOrdersBar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            previousOrdersBar.Location = new System.Drawing.Point(12, 16);
            previousOrdersBar.Name = "previousOrdersBar";
            previousOrdersBar.Size = new System.Drawing.Size(136, 34);
            previousOrdersBar.TabIndex = 3;
            previousOrdersBar.Text = "Geschiedenis";
            previousOrdersBar.UseVisualStyleBackColor = false;
            previousOrdersBar.Click += previousOrdersBar_Click;
            // 
            // OpenOrdersBarLabel
            // 
            OpenOrdersBarLabel.AutoSize = true;
            OpenOrdersBarLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            OpenOrdersBarLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            OpenOrdersBarLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            OpenOrdersBarLabel.Location = new System.Drawing.Point(611, 23);
            OpenOrdersBarLabel.Name = "OpenOrdersBarLabel";
            OpenOrdersBarLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 2);
            OpenOrdersBarLabel.Size = new System.Drawing.Size(77, 27);
            OpenOrdersBarLabel.TabIndex = 4;
            OpenOrdersBarLabel.Text = "Open: ";
            OpenOrdersBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logOutBtn
            // 
            logOutBtn.BackColor = System.Drawing.Color.FromArgb(255, 20, 20);
            logOutBtn.BackgroundImage = (System.Drawing.Image)resources.GetObject("logOutBtn.BackgroundImage");
            logOutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            logOutBtn.FlatAppearance.BorderSize = 0;
            logOutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            logOutBtn.Location = new System.Drawing.Point(1350, 0);
            logOutBtn.Name = "logOutBtn";
            logOutBtn.Size = new System.Drawing.Size(48, 48);
            logOutBtn.TabIndex = 5;
            logOutBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            logOutBtn.UseVisualStyleBackColor = false;
            logOutBtn.Click += logOutBtn_Click;
            // 
            // BarForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1398, 643);
            ControlBox = false;
            Controls.Add(logOutBtn);
            Controls.Add(OpenOrdersBarLabel);
            Controls.Add(previousOrdersBar);
            Controls.Add(barFlowLayoutPanel);
            Name = "BarForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel barFlowLayoutPanel;
        private System.Windows.Forms.Button previousOrdersBar;
        private System.Windows.Forms.Button historyOrders;
        private System.Windows.Forms.Label OpenOrdersBarLabel;
        private BottomLeftRoundedButton logOutBtn;
    }
}