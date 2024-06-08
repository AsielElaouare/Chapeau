namespace ChapeauUI
{
    partial class ReservationForm
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
            ReturnToTableOverviewBtn = new BottomLeftRoundedButton();
            SupriseBtn = new PillButton();
            SuspendLayout();
            // 
            // ReturnToTableOverviewBtn
            // 
            ReturnToTableOverviewBtn.BackgroundImage = Properties.Resources.rick_astley50x50TheBestOne;
            ReturnToTableOverviewBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            ReturnToTableOverviewBtn.FlatAppearance.BorderSize = 0;
            ReturnToTableOverviewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ReturnToTableOverviewBtn.Image = Properties.Resources.rick_astley50x50TheBestOne;
            ReturnToTableOverviewBtn.Location = new System.Drawing.Point(382, 0);
            ReturnToTableOverviewBtn.Name = "ReturnToTableOverviewBtn";
            ReturnToTableOverviewBtn.Size = new System.Drawing.Size(50, 50);
            ReturnToTableOverviewBtn.TabIndex = 0;
            ReturnToTableOverviewBtn.UseVisualStyleBackColor = true;
            ReturnToTableOverviewBtn.Click += ReturnToTableOverviewBtn_Click;
            // 
            // SupriseBtn
            // 
            SupriseBtn.BackColor = System.Drawing.Color.Black;
            SupriseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            SupriseBtn.FlatAppearance.BorderSize = 0;
            SupriseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SupriseBtn.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            SupriseBtn.ForeColor = System.Drawing.Color.White;
            SupriseBtn.Location = new System.Drawing.Point(79, 121);
            SupriseBtn.Name = "SupriseBtn";
            SupriseBtn.Size = new System.Drawing.Size(272, 38);
            SupriseBtn.TabIndex = 1;
            SupriseBtn.Text = "Click me!";
            SupriseBtn.UseVisualStyleBackColor = false;
            SupriseBtn.Click += SupriseBtn_Click;
            // 
            // ReservationForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(255, 190, 152);
            ClientSize = new System.Drawing.Size(432, 226);
            Controls.Add(SupriseBtn);
            Controls.Add(ReturnToTableOverviewBtn);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ReservationForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ReservationForm";
            Deactivate += ReservationForm_Deactivate;
            ResumeLayout(false);
        }

        #endregion

        private BottomLeftRoundedButton ReturnToTableOverviewBtn;
        private PillButton SupriseBtn;
    }
}