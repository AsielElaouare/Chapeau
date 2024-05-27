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
            barFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            previousOrdersBar = new System.Windows.Forms.Button();
            OpenOrdersBarLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // barFlowLayoutPanel
            // 
            barFlowLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            barFlowLayoutPanel.Location = new System.Drawing.Point(1, 65);
            barFlowLayoutPanel.Name = "barFlowLayoutPanel";
            barFlowLayoutPanel.Size = new System.Drawing.Size(1396, 577);
            barFlowLayoutPanel.TabIndex = 0;
            // 
            // previousOrdersBar
            // 
            previousOrdersBar.Location = new System.Drawing.Point(12, 22);
            previousOrdersBar.Name = "previousOrdersBar";
            previousOrdersBar.Size = new System.Drawing.Size(108, 29);
            previousOrdersBar.TabIndex = 1;
            previousOrdersBar.Text = "Geschiedenis ";
            previousOrdersBar.UseVisualStyleBackColor = true;
            // 
            // OpenOrdersBarLabel
            // 
            OpenOrdersBarLabel.AutoSize = true;
            OpenOrdersBarLabel.Location = new System.Drawing.Point(595, 29);
            OpenOrdersBarLabel.Name = "OpenOrdersBarLabel";
            OpenOrdersBarLabel.Size = new System.Drawing.Size(42, 15);
            OpenOrdersBarLabel.TabIndex = 2;
            OpenOrdersBarLabel.Text = "Open: ";
            // 
            // BarForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1398, 643);
            Controls.Add(OpenOrdersBarLabel);
            Controls.Add(previousOrdersBar);
            Controls.Add(barFlowLayoutPanel);
            Name = "BarForm";
            Text = "Bar View";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel barFlowLayoutPanel;
        private System.Windows.Forms.Button previousOrdersBar;
        private System.Windows.Forms.Label OpenOrdersBarLabel;
    }
}