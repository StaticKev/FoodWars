namespace FoodWars.View
{
    partial class MainMenuUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuUserControl));
            this.pictBox_ButtonExit = new System.Windows.Forms.PictureBox();
            this.pictBox_ButtonSettings = new System.Windows.Forms.PictureBox();
            this.pictBox_Leaderboard = new System.Windows.Forms.PictureBox();
            this.pictBox_ButtonSwitchPlayer = new System.Windows.Forms.PictureBox();
            this.pictBox_ButtonStart = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictBox_Profile = new System.Windows.Forms.PictureBox();
            this.label_Level = new System.Windows.Forms.Label();
            this.label_Name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_ButtonExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_ButtonSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_Leaderboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_ButtonSwitchPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_ButtonStart)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_Profile)).BeginInit();
            this.SuspendLayout();
            // 
            // pictBox_ButtonExit
            // 
            this.pictBox_ButtonExit.BackColor = System.Drawing.Color.Transparent;
            this.pictBox_ButtonExit.Image = global::FoodWars.Properties.Resources.button_exit;
            this.pictBox_ButtonExit.Location = new System.Drawing.Point(360, 425);
            this.pictBox_ButtonExit.Name = "pictBox_ButtonExit";
            this.pictBox_ButtonExit.Size = new System.Drawing.Size(225, 45);
            this.pictBox_ButtonExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictBox_ButtonExit.TabIndex = 4;
            this.pictBox_ButtonExit.TabStop = false;
            this.pictBox_ButtonExit.Click += new System.EventHandler(this.Button_Exit_MouseClick);
            this.pictBox_ButtonExit.MouseEnter += new System.EventHandler(this.Button_Exit_MouseEnter);
            this.pictBox_ButtonExit.MouseLeave += new System.EventHandler(this.Button_Exit_MouseLeave);
            // 
            // pictBox_ButtonSettings
            // 
            this.pictBox_ButtonSettings.BackColor = System.Drawing.Color.Transparent;
            this.pictBox_ButtonSettings.Image = ((System.Drawing.Image)(resources.GetObject("pictBox_ButtonSettings.Image")));
            this.pictBox_ButtonSettings.Location = new System.Drawing.Point(360, 371);
            this.pictBox_ButtonSettings.Name = "pictBox_ButtonSettings";
            this.pictBox_ButtonSettings.Size = new System.Drawing.Size(225, 45);
            this.pictBox_ButtonSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictBox_ButtonSettings.TabIndex = 3;
            this.pictBox_ButtonSettings.TabStop = false;
            this.pictBox_ButtonSettings.Click += new System.EventHandler(this.Button_Settings_MouseClick);
            this.pictBox_ButtonSettings.MouseEnter += new System.EventHandler(this.Button_Settings_MouseEnter);
            this.pictBox_ButtonSettings.MouseLeave += new System.EventHandler(this.Button_Settings_MouseLeave);
            // 
            // pictBox_Leaderboard
            // 
            this.pictBox_Leaderboard.BackColor = System.Drawing.Color.Transparent;
            this.pictBox_Leaderboard.Image = ((System.Drawing.Image)(resources.GetObject("pictBox_Leaderboard.Image")));
            this.pictBox_Leaderboard.Location = new System.Drawing.Point(360, 317);
            this.pictBox_Leaderboard.Name = "pictBox_Leaderboard";
            this.pictBox_Leaderboard.Size = new System.Drawing.Size(225, 45);
            this.pictBox_Leaderboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictBox_Leaderboard.TabIndex = 2;
            this.pictBox_Leaderboard.TabStop = false;
            this.pictBox_Leaderboard.Click += new System.EventHandler(this.Button_Leaderboard_Click);
            this.pictBox_Leaderboard.MouseEnter += new System.EventHandler(this.Button_Leaderboard_MouseEnter);
            this.pictBox_Leaderboard.MouseLeave += new System.EventHandler(this.Button_Leaderboard_MouseLeave);
            // 
            // pictBox_ButtonSwitchPlayer
            // 
            this.pictBox_ButtonSwitchPlayer.BackColor = System.Drawing.Color.Transparent;
            this.pictBox_ButtonSwitchPlayer.Image = ((System.Drawing.Image)(resources.GetObject("pictBox_ButtonSwitchPlayer.Image")));
            this.pictBox_ButtonSwitchPlayer.Location = new System.Drawing.Point(360, 263);
            this.pictBox_ButtonSwitchPlayer.Name = "pictBox_ButtonSwitchPlayer";
            this.pictBox_ButtonSwitchPlayer.Size = new System.Drawing.Size(225, 45);
            this.pictBox_ButtonSwitchPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictBox_ButtonSwitchPlayer.TabIndex = 1;
            this.pictBox_ButtonSwitchPlayer.TabStop = false;
            this.pictBox_ButtonSwitchPlayer.Click += new System.EventHandler(this.Button_SwitchPlayer_Click);
            this.pictBox_ButtonSwitchPlayer.MouseEnter += new System.EventHandler(this.Button_SwitchPlayer_MouseEnter);
            this.pictBox_ButtonSwitchPlayer.MouseLeave += new System.EventHandler(this.Button_SwitchPlayer_MouseLeave);
            // 
            // pictBox_ButtonStart
            // 
            this.pictBox_ButtonStart.BackColor = System.Drawing.Color.Transparent;
            this.pictBox_ButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("pictBox_ButtonStart.Image")));
            this.pictBox_ButtonStart.Location = new System.Drawing.Point(360, 209);
            this.pictBox_ButtonStart.Name = "pictBox_ButtonStart";
            this.pictBox_ButtonStart.Size = new System.Drawing.Size(225, 45);
            this.pictBox_ButtonStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictBox_ButtonStart.TabIndex = 0;
            this.pictBox_ButtonStart.TabStop = false;
            this.pictBox_ButtonStart.Click += new System.EventHandler(this.Button_Start_Click);
            this.pictBox_ButtonStart.MouseEnter += new System.EventHandler(this.Button_Start_MouseEnter);
            this.pictBox_ButtonStart.MouseLeave += new System.EventHandler(this.Button_Start_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.pictBox_Profile);
            this.panel1.Controls.Add(this.label_Level);
            this.panel1.Controls.Add(this.label_Name);
            this.panel1.Location = new System.Drawing.Point(661, 376);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 125);
            this.panel1.TabIndex = 6;
            // 
            // pictBox_Profile
            // 
            this.pictBox_Profile.BackgroundImage = global::FoodWars.Properties.Resources.icon_default;
            this.pictBox_Profile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictBox_Profile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictBox_Profile.Location = new System.Drawing.Point(31, 37);
            this.pictBox_Profile.Name = "pictBox_Profile";
            this.pictBox_Profile.Size = new System.Drawing.Size(62, 62);
            this.pictBox_Profile.TabIndex = 2;
            this.pictBox_Profile.TabStop = false;
            // 
            // label_Level
            // 
            this.label_Level.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Level.Location = new System.Drawing.Point(104, 76);
            this.label_Level.Name = "label_Level";
            this.label_Level.Size = new System.Drawing.Size(104, 23);
            this.label_Level.TabIndex = 1;
            this.label_Level.Text = "Level: -";
            // 
            // label_Name
            // 
            this.label_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Name.Location = new System.Drawing.Point(104, 49);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(104, 37);
            this.label_Name.TabIndex = 0;
            this.label_Name.Text = "Name: -";
            // 
            // MainMenuUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FoodWars.Properties.Resources.bg_mainMenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictBox_ButtonExit);
            this.Controls.Add(this.pictBox_ButtonSettings);
            this.Controls.Add(this.pictBox_Leaderboard);
            this.Controls.Add(this.pictBox_ButtonSwitchPlayer);
            this.Controls.Add(this.pictBox_ButtonStart);
            this.DoubleBuffered = true;
            this.Name = "MainMenuUserControl";
            this.Size = new System.Drawing.Size(944, 501);
            this.Load += new System.EventHandler(this.MainMenuUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_ButtonExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_ButtonSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_Leaderboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_ButtonSwitchPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_ButtonStart)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_Profile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictBox_ButtonStart;
        private System.Windows.Forms.PictureBox pictBox_ButtonSwitchPlayer;
        private System.Windows.Forms.PictureBox pictBox_Leaderboard;
        private System.Windows.Forms.PictureBox pictBox_ButtonSettings;
        private System.Windows.Forms.PictureBox pictBox_ButtonExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_Level;
        private System.Windows.Forms.PictureBox pictBox_Profile;
    }
}
