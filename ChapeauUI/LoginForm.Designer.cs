namespace ChapeauUI
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            CloseApplicationBtn = new BottomLeftRoundedButton();
            UsernameLbl = new System.Windows.Forms.Label();
            PasswordLbl = new System.Windows.Forms.Label();
            UsernameTextBox = new System.Windows.Forms.TextBox();
            PasswordTextBox = new System.Windows.Forms.TextBox();
            ConfirmBtn = new RoundButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(341, 73);
            pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(450, 253);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // CloseApplicationBtn
            // 
            CloseApplicationBtn.BackColor = System.Drawing.Color.FromArgb(255, 20, 20);
            CloseApplicationBtn.BackgroundImage = (System.Drawing.Image)resources.GetObject("CloseApplicationBtn.BackgroundImage");
            CloseApplicationBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            CloseApplicationBtn.FlatAppearance.BorderSize = 0;
            CloseApplicationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CloseApplicationBtn.Location = new System.Drawing.Point(1085, 0);
            CloseApplicationBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            CloseApplicationBtn.Name = "CloseApplicationBtn";
            CloseApplicationBtn.Size = new System.Drawing.Size(48, 48);
            CloseApplicationBtn.TabIndex = 17;
            CloseApplicationBtn.UseVisualStyleBackColor = false;
            CloseApplicationBtn.Click += CloseApplicationBtn_Click;
            // 
            // UsernameLbl
            // 
            UsernameLbl.AutoSize = true;
            UsernameLbl.Font = new System.Drawing.Font("Century Gothic", 23.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            UsernameLbl.Location = new System.Drawing.Point(383, 368);
            UsernameLbl.Margin = new System.Windows.Forms.Padding(0);
            UsernameLbl.Name = "UsernameLbl";
            UsernameLbl.Size = new System.Drawing.Size(406, 57);
            UsernameLbl.TabIndex = 18;
            UsernameLbl.Text = "Gebruikersnaam";
            // 
            // PasswordLbl
            // 
            PasswordLbl.AutoSize = true;
            PasswordLbl.Font = new System.Drawing.Font("Century Gothic", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PasswordLbl.Location = new System.Drawing.Point(383, 527);
            PasswordLbl.Name = "PasswordLbl";
            PasswordLbl.Size = new System.Drawing.Size(315, 56);
            PasswordLbl.TabIndex = 19;
            PasswordLbl.Text = "Wachtwoord";
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            UsernameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            UsernameTextBox.Font = new System.Drawing.Font("Century Gothic", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            UsernameTextBox.Location = new System.Drawing.Point(383, 421);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new System.Drawing.Size(367, 64);
            UsernameTextBox.TabIndex = 20;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            PasswordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            PasswordTextBox.Font = new System.Drawing.Font("Century Gothic", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PasswordTextBox.Location = new System.Drawing.Point(383, 567);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.Size = new System.Drawing.Size(367, 64);
            PasswordTextBox.TabIndex = 22;
            // 
            // ConfirmBtn
            // 
            ConfirmBtn.BackColor = System.Drawing.Color.White;
            ConfirmBtn.BackgroundImage = (System.Drawing.Image)resources.GetObject("ConfirmBtn.BackgroundImage");
            ConfirmBtn.FlatAppearance.BorderSize = 0;
            ConfirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ConfirmBtn.Location = new System.Drawing.Point(792, 565);
            ConfirmBtn.Name = "ConfirmBtn";
            ConfirmBtn.Size = new System.Drawing.Size(50, 50);
            ConfirmBtn.TabIndex = 23;
            ConfirmBtn.UseVisualStyleBackColor = false;
            ConfirmBtn.Click += ConfirmBtn_Click;
            // 
            // LoginForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1133, 744);
            Controls.Add(ConfirmBtn);
            Controls.Add(PasswordTextBox);
            Controls.Add(UsernameTextBox);
            Controls.Add(PasswordLbl);
            Controls.Add(UsernameLbl);
            Controls.Add(CloseApplicationBtn);
            Controls.Add(pictureBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "LoginScreen";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private BottomLeftRoundedButton CloseApplicationBtn;
        private System.Windows.Forms.Label UsernameLbl;
        private System.Windows.Forms.Label PasswordLbl;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private RoundButton ConfirmBtn;
    }
}