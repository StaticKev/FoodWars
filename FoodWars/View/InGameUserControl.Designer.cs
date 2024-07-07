using System;

namespace FoodWars.View
{
    partial class InGameUserControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InGameUserControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_income = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_timeLeft = new System.Windows.Forms.Label();
            this.pictBox_buttonPause = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_buttonPause)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.label_income);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 196);
            this.panel1.TabIndex = 2;
            // 
            // label_income
            // 
            this.label_income.BackColor = System.Drawing.Color.Transparent;
            this.label_income.Font = new System.Drawing.Font("Samurai Blast", 14F);
            this.label_income.Location = new System.Drawing.Point(18, 57);
            this.label_income.Name = "label_income";
            this.label_income.Size = new System.Drawing.Size(90, 16);
            this.label_income.TabIndex = 5;
            this.label_income.Text = "0";
            this.label_income.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(0, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(125, 95);
            this.panel2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Samurai Blast", 8F);
            this.label4.Location = new System.Drawing.Point(23, 59);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(80, 9);
            this.label4.TabIndex = 5;
            this.label4.Text = "-";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Samurai Blast", 8F);
            this.label3.Location = new System.Drawing.Point(16, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 9);
            this.label3.TabIndex = 5;
            this.label3.Text = "Next Customer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Samurai Blast", 8F);
            this.label2.Location = new System.Drawing.Point(41, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 9);
            this.label2.TabIndex = 5;
            this.label2.Text = "Income";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Samurai Blast", 8F);
            this.label1.Location = new System.Drawing.Point(33, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 9);
            this.label1.TabIndex = 4;
            this.label1.Text = "Time Left";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel3.Controls.Add(this.label_timeLeft);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(20, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(134, 294);
            this.panel3.TabIndex = 4;
            // 
            // label_timeLeft
            // 
            this.label_timeLeft.BackColor = System.Drawing.Color.Transparent;
            this.label_timeLeft.Font = new System.Drawing.Font("Samurai Blast", 14F);
            this.label_timeLeft.Location = new System.Drawing.Point(25, 54);
            this.label_timeLeft.Name = "label_timeLeft";
            this.label_timeLeft.Size = new System.Drawing.Size(78, 16);
            this.label_timeLeft.TabIndex = 6;
            this.label_timeLeft.Text = "00 : 00";
            this.label_timeLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictBox_buttonPause
            // 
            this.pictBox_buttonPause.BackColor = System.Drawing.Color.Transparent;
            this.pictBox_buttonPause.BackgroundImage = global::FoodWars.Properties.Resources.button_pause;
            this.pictBox_buttonPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictBox_buttonPause.Location = new System.Drawing.Point(879, 15);
            this.pictBox_buttonPause.Name = "pictBox_buttonPause";
            this.pictBox_buttonPause.Size = new System.Drawing.Size(50, 50);
            this.pictBox_buttonPause.TabIndex = 5;
            this.pictBox_buttonPause.TabStop = false;
            this.pictBox_buttonPause.Click += new System.EventHandler(this.Button_Pause_Click);
            this.pictBox_buttonPause.MouseEnter += new System.EventHandler(this.Button_Pause_MouseEnter);
            this.pictBox_buttonPause.MouseLeave += new System.EventHandler(this.Button_Pause_MouseLeave);
            // 
            // InGameUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pictBox_buttonPause);
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.Name = "InGameUserControl";
            this.Size = new System.Drawing.Size(944, 501);
            this.Load += new System.EventHandler(this.InGameUserControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_buttonPause)).EndInit();
            this.ResumeLayout(false);
            //
            // timer
            // 
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new EventHandler(this.Timer_Tick);

        }

        #endregion
        public System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_income;
        private System.Windows.Forms.Label label_timeLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictBox_buttonPause;
    }
}
