namespace FoodWars.View
{
    partial class SwitchPlayerUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SwitchPlayerUserControl));
            this.comboBox_Players = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_newPlayer = new System.Windows.Forms.Button();
            this.button_backToMainMenu = new System.Windows.Forms.Button();
            this.button_achievements = new System.Windows.Forms.Button();
            this.label_bestTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_bestIncome = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_totalIncome = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_level = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictBox_Profile = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_Profile)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_Players
            // 
            this.comboBox_Players.BackColor = System.Drawing.Color.White;
            this.comboBox_Players.FormattingEnabled = true;
            this.comboBox_Players.Location = new System.Drawing.Point(95, 40);
            this.comboBox_Players.Name = "comboBox_Players";
            this.comboBox_Players.Size = new System.Drawing.Size(229, 29);
            this.comboBox_Players.TabIndex = 0;
            this.comboBox_Players.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Player_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button_newPlayer);
            this.groupBox1.Controls.Add(this.button_backToMainMenu);
            this.groupBox1.Controls.Add(this.button_achievements);
            this.groupBox1.Controls.Add(this.label_bestTime);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label_bestIncome);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label_totalIncome);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label_level);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox_Players);
            this.groupBox1.Font = new System.Drawing.Font("Samurai Blast", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(472, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 300);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Players";
            // 
            // button_newPlayer
            // 
            this.button_newPlayer.Font = new System.Drawing.Font("Samurai Blast", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_newPlayer.Location = new System.Drawing.Point(181, 251);
            this.button_newPlayer.Name = "button_newPlayer";
            this.button_newPlayer.Size = new System.Drawing.Size(143, 30);
            this.button_newPlayer.TabIndex = 10;
            this.button_newPlayer.Text = "New Player";
            this.button_newPlayer.UseVisualStyleBackColor = true;
            this.button_newPlayer.Click += new System.EventHandler(this.Button_newPlayer_Click);
            // 
            // button_backToMainMenu
            // 
            this.button_backToMainMenu.Font = new System.Drawing.Font("Samurai Blast", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_backToMainMenu.Location = new System.Drawing.Point(29, 251);
            this.button_backToMainMenu.Name = "button_backToMainMenu";
            this.button_backToMainMenu.Size = new System.Drawing.Size(146, 30);
            this.button_backToMainMenu.TabIndex = 9;
            this.button_backToMainMenu.Text = "Back";
            this.button_backToMainMenu.UseVisualStyleBackColor = true;
            this.button_backToMainMenu.Click += new System.EventHandler(this.Button_backToMainMenu_Click);
            // 
            // button_achievements
            // 
            this.button_achievements.Location = new System.Drawing.Point(29, 202);
            this.button_achievements.Name = "button_achievements";
            this.button_achievements.Size = new System.Drawing.Size(295, 43);
            this.button_achievements.TabIndex = 4;
            this.button_achievements.Text = "Achievements";
            this.button_achievements.UseVisualStyleBackColor = true;
            // 
            // label_bestTime
            // 
            this.label_bestTime.AutoSize = true;
            this.label_bestTime.Font = new System.Drawing.Font("Samurai Blast", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bestTime.Location = new System.Drawing.Point(138, 171);
            this.label_bestTime.Name = "label_bestTime";
            this.label_bestTime.Size = new System.Drawing.Size(16, 16);
            this.label_bestTime.TabIndex = 8;
            this.label_bestTime.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Samurai Blast", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Best Time: ";
            // 
            // label_bestIncome
            // 
            this.label_bestIncome.AutoSize = true;
            this.label_bestIncome.Font = new System.Drawing.Font("Samurai Blast", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bestIncome.Location = new System.Drawing.Point(163, 140);
            this.label_bestIncome.Name = "label_bestIncome";
            this.label_bestIncome.Size = new System.Drawing.Size(16, 16);
            this.label_bestIncome.TabIndex = 6;
            this.label_bestIncome.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Samurai Blast", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Best Income: ";
            // 
            // label_totalIncome
            // 
            this.label_totalIncome.AutoSize = true;
            this.label_totalIncome.Font = new System.Drawing.Font("Samurai Blast", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_totalIncome.Location = new System.Drawing.Point(178, 109);
            this.label_totalIncome.Name = "label_totalIncome";
            this.label_totalIncome.Size = new System.Drawing.Size(16, 16);
            this.label_totalIncome.TabIndex = 5;
            this.label_totalIncome.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Samurai Blast", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total Income: ";
            // 
            // label_level
            // 
            this.label_level.AutoSize = true;
            this.label_level.Font = new System.Drawing.Font("Samurai Blast", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_level.Location = new System.Drawing.Point(188, 81);
            this.label_level.Name = "label_level";
            this.label_level.Size = new System.Drawing.Size(16, 16);
            this.label_level.TabIndex = 3;
            this.label_level.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Samurai Blast", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current Level:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Samurai Blast", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name: ";
            // 
            // pictBox_Profile
            // 
            this.pictBox_Profile.BackColor = System.Drawing.Color.White;
            this.pictBox_Profile.BackgroundImage = global::FoodWars.Properties.Resources.DefaultIcon;
            this.pictBox_Profile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictBox_Profile.Location = new System.Drawing.Point(5, 5);
            this.pictBox_Profile.Name = "pictBox_Profile";
            this.pictBox_Profile.Size = new System.Drawing.Size(290, 290);
            this.pictBox_Profile.TabIndex = 1;
            this.pictBox_Profile.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictBox_Profile);
            this.panel1.Location = new System.Drawing.Point(136, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 300);
            this.panel1.TabIndex = 4;
            // 
            // SwitchPlayerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "SwitchPlayerUserControl";
            this.Size = new System.Drawing.Size(944, 501);
            this.Load += new System.EventHandler(this.SwitchPlayerUserControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_Profile)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Players;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictBox_Profile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_level;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_totalIncome;
        private System.Windows.Forms.Label label_bestIncome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_backToMainMenu;
        private System.Windows.Forms.Button button_achievements;
        private System.Windows.Forms.Label label_bestTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_newPlayer;
        private System.Windows.Forms.Panel panel1;
    }
}
