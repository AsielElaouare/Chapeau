using System;
using System.Drawing;
using System.Windows.Forms;
using ChapeauModel;

namespace ChapeauUI
{
    partial class KitchenDisplayOrder
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer holdTimer;

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
            this.holdTimer = new System.Windows.Forms.Timer();

            // Timer settings
            this.holdTimer.Interval = 5000;



            // Add the buttons to the form (adjust location and size as needed)


            components = new System.ComponentModel.Container();
            timer = new Timer(components);
            timeLabel = new Label();
            orderInfLabel = new Label();
            mainDishesLabel = new Label();
            sideDishesLabel = new Label();
            dessertsLabel = new Label();
            orderPanel = new FlowLayoutPanel();
            mainDishesLayoutPanel = new FlowLayoutPanel();
            sideDishesLayoutPanel = new FlowLayoutPanel();
            dessetsDishesLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanelOrder = new FlowLayoutPanel();
            StartBtn = new Button();
            CompleteBtn = new Button();
            orderPanel.SuspendLayout();
            flowLayoutPanelOrder.SuspendLayout();
            SuspendLayout();
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += TimerTick;


            // 
            // timeLabel
            // 
            timeLabel.BackColor = Color.FromArgb(0, 132, 255);
            timeLabel.Location = new Point(0, 0);
            timeLabel.Margin = new Padding(0);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(200, 23);
            timeLabel.TabIndex = 0;
            timeLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // orderInfLabel
            // 
            orderInfLabel.Location = new Point(0, 28);
            orderInfLabel.Margin = new Padding(0, 5, 0, 0);
            orderInfLabel.Name = "orderInfLabel";
            orderInfLabel.Size = new Size(200, 23);
            orderInfLabel.TabIndex = 1;
            // 
            // mainDishesLabel
            // 
            mainDishesLabel.BackColor = Color.FromArgb(255, 143, 143);
            mainDishesLabel.Location = new Point(0, 61);
            mainDishesLabel.Margin = new Padding(0, 10, 0, 0);
            mainDishesLabel.Name = "mainDishesLabel";
            mainDishesLabel.Size = new Size(200, 16);
            mainDishesLabel.TabIndex = 2;
            mainDishesLabel.Text = "Hoofdgerechten";
            // 
            // sideDishesLabel
            // 
            sideDishesLabel.BackColor = Color.FromArgb(119, 234, 109);
            sideDishesLabel.Location = new Point(0, 137);
            sideDishesLabel.Margin = new Padding(0, 60, 0, 0);
            sideDishesLabel.Name = "sideDishesLabel";
            sideDishesLabel.Size = new Size(200, 16);
            sideDishesLabel.TabIndex = 3;
            sideDishesLabel.Text = "Voorgerechten";
            // 
            // dessertsLabel
            // 
            dessertsLabel.BackColor = Color.FromArgb(234, 199, 109);
            dessertsLabel.Location = new Point(0, 213);
            dessertsLabel.Margin = new Padding(0, 60, 0, 0);
            dessertsLabel.Name = "dessertsLabel";
            dessertsLabel.Size = new Size(200, 16);
            dessertsLabel.TabIndex = 4;
            dessertsLabel.Text = "Nagerechten";
            // 
            // orderPanel
            // 
            orderPanel.Controls.Add(timeLabel);
            orderPanel.Controls.Add(orderInfLabel);
            orderPanel.Controls.Add(mainDishesLabel);
            orderPanel.Controls.Add(mainDishesLayoutPanel);
            orderPanel.Controls.Add(sideDishesLabel);
            orderPanel.Controls.Add(sideDishesLayoutPanel);
            orderPanel.Controls.Add(dessertsLabel);
            orderPanel.Controls.Add(dessetsDishesLayoutPanel);
            orderPanel.FlowDirection = FlowDirection.TopDown;
            orderPanel.Location = new Point(0, 0);
            orderPanel.Margin = new Padding(0);
            orderPanel.Name = "orderPanel";
            orderPanel.Size = new Size(200, 398);
            orderPanel.TabIndex = 0;
            // 
            // mainDishesLayoutPanel
            // 
            mainDishesLayoutPanel.AutoSize = true;
            mainDishesLayoutPanel.Location = new Point(0, 77);
            mainDishesLayoutPanel.Margin = new Padding(0);
            mainDishesLayoutPanel.Name = "mainDishesLayoutPanel";
            mainDishesLayoutPanel.Size = new Size(0, 0);
            mainDishesLayoutPanel.TabIndex = 5;
            // 
            // sideDishesLayoutPanel
            // 
            sideDishesLayoutPanel.AutoSize = true;
            sideDishesLayoutPanel.Location = new Point(0, 153);
            sideDishesLayoutPanel.Margin = new Padding(0);
            sideDishesLayoutPanel.Name = "sideDishesLayoutPanel";
            sideDishesLayoutPanel.Size = new Size(0, 0);
            sideDishesLayoutPanel.TabIndex = 6;
            // 
            // dessetsDishesLayoutPanel
            // 
            dessetsDishesLayoutPanel.AutoSize = true;
            dessetsDishesLayoutPanel.Location = new Point(0, 229);
            dessetsDishesLayoutPanel.Margin = new Padding(0);
            dessetsDishesLayoutPanel.Name = "dessetsDishesLayoutPanel";
            dessetsDishesLayoutPanel.Size = new Size(0, 0);
            dessetsDishesLayoutPanel.TabIndex = 7;
            // 
            // flowLayoutPanelOrder
            // 
            flowLayoutPanelOrder.BackColor = Color.Gray;
            flowLayoutPanelOrder.Controls.Add(orderPanel);
            flowLayoutPanelOrder.Controls.Add(StartBtn);
            flowLayoutPanelOrder.Controls.Add(CompleteBtn);
            flowLayoutPanelOrder.Location = new Point(0, 0);
            flowLayoutPanelOrder.Margin = new Padding(0);
            flowLayoutPanelOrder.Name = "flowLayoutPanelOrder";
            flowLayoutPanelOrder.Size = new Size(200, 427);
            flowLayoutPanelOrder.TabIndex = 0;
            // 
            // StartBtn
            // 
            StartBtn.BackColor = Color.FromArgb(0, 132, 255);
            StartBtn.ForeColor = Color.MintCream;
            StartBtn.Location = new Point(0, 398);
            StartBtn.Margin = new Padding(0);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(75, 27);
            StartBtn.TabIndex = 1;
            StartBtn.Text = "Start";
            StartBtn.UseVisualStyleBackColor = false;
            StartBtn.Click += StartBtn_Click;
            // 
            // CompleteBtn
            // 
            CompleteBtn.BackColor = Color.FromArgb(23, 185, 8);
            CompleteBtn.Enabled = false;
            CompleteBtn.ForeColor = SystemColors.ButtonHighlight;
            CompleteBtn.Location = new Point(125, 398);
            CompleteBtn.Margin = new Padding(50, 0, 0, 0);
            CompleteBtn.Name = "CompleteBtn";
            CompleteBtn.Size = new Size(75, 27);
            CompleteBtn.TabIndex = 2;
            CompleteBtn.Text = "Compleet";
            CompleteBtn.UseVisualStyleBackColor = false;
            CompleteBtn.Click += CompleteBtn_Click;
            // 
            // KitchenDisplayOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanelOrder);
            Name = "KitchenDisplayOrder";
            Size = new Size(200, 427);
            orderPanel.ResumeLayout(false);
            orderPanel.PerformLayout();
            flowLayoutPanelOrder.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("mm:ss");
        }



        #endregion

        private Label timeLabel;
        private Label orderInfLabel;
        private Label mainDishesLabel;
        private Label sideDishesLabel;
        private Label dessertsLabel;
        private FlowLayoutPanel orderPanel;
        private FlowLayoutPanel flowLayoutPanelOrder;
        private Timer timer;
        private Button StartBtn;
        private Button CompleteBtn;
        private FlowLayoutPanel mainDishesLayoutPanel;
        private FlowLayoutPanel sideDishesLayoutPanel;
        private FlowLayoutPanel dessetsDishesLayoutPanel;
    }
}
