using System.Drawing;
using System.Windows.Forms;

namespace ChapeauUI
{
    partial class OrderForm
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
            drinksButton = new Button();
            lunchButton = new Button();
            dinerButton = new Button();
            pictureBox1 = new PictureBox();
            cancelButton = new Button();
            confirmButton = new Button();
            productLayoutPanel = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // drinksButton
            // 
            drinksButton.BackColor = SystemColors.ControlDark;
            drinksButton.Font = new Font("Yu Gothic", 30F, FontStyle.Regular, GraphicsUnit.Point);
            drinksButton.Location = new Point(26, 45);
            drinksButton.Name = "drinksButton";
            drinksButton.Size = new Size(230, 75);
            drinksButton.TabIndex = 0;
            drinksButton.Text = "Drinks";
            drinksButton.UseVisualStyleBackColor = false;
            drinksButton.Click += drinksButton_Click;
            // 
            // lunchButton
            // 
            lunchButton.BackColor = SystemColors.ControlDark;
            lunchButton.Font = new Font("Yu Gothic", 30F, FontStyle.Regular, GraphicsUnit.Point);
            lunchButton.Location = new Point(256, 45);
            lunchButton.Name = "lunchButton";
            lunchButton.Size = new Size(230, 75);
            lunchButton.TabIndex = 1;
            lunchButton.Text = "Lunch";
            lunchButton.UseVisualStyleBackColor = false;
            lunchButton.Click += lunchButton_Click;
            // 
            // dinerButton
            // 
            dinerButton.BackColor = SystemColors.ControlDark;
            dinerButton.Font = new Font("Yu Gothic", 30F, FontStyle.Regular, GraphicsUnit.Point);
            dinerButton.Location = new Point(486, 45);
            dinerButton.Name = "dinerButton";
            dinerButton.Size = new Size(230, 75);
            dinerButton.TabIndex = 2;
            dinerButton.Text = "Diner";
            dinerButton.UseVisualStyleBackColor = false;
            dinerButton.Click += dinerButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Chapeau_logo_outline_v2;
            pictureBox1.Location = new Point(855, 25);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(140, 70);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Red;
            cancelButton.Font = new Font("Yu Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point);
            cancelButton.Location = new Point(763, 670);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(165, 50);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "cancel";
            cancelButton.UseVisualStyleBackColor = false;
            // 
            // confirmButton
            // 
            confirmButton.BackColor = Color.Lime;
            confirmButton.Font = new Font("Yu Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point);
            confirmButton.Location = new Point(928, 670);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(165, 50);
            confirmButton.TabIndex = 4;
            confirmButton.Text = "confirm";
            confirmButton.UseVisualStyleBackColor = false;
            confirmButton.Click += confirmButton_Click;
            // 
            // flowLayoutPanel1
            // 
            productLayoutPanel.BackColor = Color.FromArgb(224, 224, 224);
            productLayoutPanel.Location = new Point(26, 120);
            productLayoutPanel.Name = "flowLayoutPanel1";
            productLayoutPanel.Size = new Size(690, 600);
            productLayoutPanel.TabIndex = 5;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 744);
            Controls.Add(productLayoutPanel);
            Controls.Add(confirmButton);
            Controls.Add(cancelButton);
            Controls.Add(pictureBox1);
            Controls.Add(dinerButton);
            Controls.Add(lunchButton);
            Controls.Add(drinksButton);
            Name = "OrderForm";
            Text = "OrderForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button drinksButton;
        private System.Windows.Forms.Button lunchButton;
        private System.Windows.Forms.Button dinerButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Button cancelButton;
        private Button confirmButton;
        private FlowLayoutPanel productLayoutPanel;
    }
}