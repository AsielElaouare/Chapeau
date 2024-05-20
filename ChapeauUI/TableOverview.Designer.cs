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
            bottomLeftRoundedButton1 = new BottomLeftRoundedButton();
            bottomRoundedButton1 = new BottomRoundedButton();
            SuspendLayout();
            // 
            // bottomRightRoundedButton1
            // 
            bottomRightRoundedButton1.BackColor = System.Drawing.Color.FromArgb(201, 126, 13);
            bottomRightRoundedButton1.FlatAppearance.BorderSize = 0;
            bottomRightRoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bottomRightRoundedButton1.Image = (System.Drawing.Image)resources.GetObject("bottomRightRoundedButton1.Image");
            bottomRightRoundedButton1.Location = new System.Drawing.Point(0, 0);
            bottomRightRoundedButton1.Name = "bottomRightRoundedButton1";
            bottomRightRoundedButton1.Size = new System.Drawing.Size(48, 48);
            bottomRightRoundedButton1.TabIndex = 0;
            bottomRightRoundedButton1.UseVisualStyleBackColor = false;
            // 
            // bottomLeftRoundedButton1
            // 
            bottomLeftRoundedButton1.BackColor = System.Drawing.Color.FromArgb(255, 20, 20);
            bottomLeftRoundedButton1.FlatAppearance.BorderSize = 0;
            bottomLeftRoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bottomLeftRoundedButton1.Location = new System.Drawing.Point(1085, 0);
            bottomLeftRoundedButton1.Name = "bottomLeftRoundedButton1";
            bottomLeftRoundedButton1.Size = new System.Drawing.Size(48, 48);
            bottomLeftRoundedButton1.TabIndex = 1;
            bottomLeftRoundedButton1.UseVisualStyleBackColor = false;
            // 
            // bottomRoundedButton1
            // 
            bottomRoundedButton1.BackColor = System.Drawing.Color.FromArgb(12, 18, 150);
            bottomRoundedButton1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bottomRoundedButton1.BackgroundImage");
            bottomRoundedButton1.FlatAppearance.BorderSize = 0;
            bottomRoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bottomRoundedButton1.Location = new System.Drawing.Point(50, 0);
            bottomRoundedButton1.Name = "bottomRoundedButton1";
            bottomRoundedButton1.Size = new System.Drawing.Size(48, 48);
            bottomRoundedButton1.TabIndex = 2;
            bottomRoundedButton1.Text = "bottomRoundedButton1";
            bottomRoundedButton1.UseVisualStyleBackColor = false;
            // 
            // TableOverview
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1133, 744);
            Controls.Add(bottomRoundedButton1);
            Controls.Add(bottomLeftRoundedButton1);
            Controls.Add(bottomRightRoundedButton1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "TableOverview";
            Text = "TableOverview";
            ResumeLayout(false);
        }

        #endregion

        private BottomRightRoundedButton bottomRightRoundedButton1;
        private BottomLeftRoundedButton bottomLeftRoundedButton1;
        private BottomRoundedButton bottomRoundedButton1;
    }
}