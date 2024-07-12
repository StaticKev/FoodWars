namespace FoodWars.View
{
    partial class SettingsUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsUserControl));
            this.checkBox_BGM = new System.Windows.Forms.PictureBox();
            this.pictBox_ButtonExit = new System.Windows.Forms.PictureBox();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelBGM = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.checkBox_BGM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_ButtonExit)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_BGM
            // 
            this.checkBox_BGM.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_BGM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkBox_BGM.Image = global::FoodWars.Properties.Resources.Checkbox_Check_True;
            this.checkBox_BGM.Location = new System.Drawing.Point(624, 198);
            this.checkBox_BGM.Name = "checkBox_BGM";
            this.checkBox_BGM.Size = new System.Drawing.Size(50, 50);
            this.checkBox_BGM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.checkBox_BGM.TabIndex = 36;
            this.checkBox_BGM.TabStop = false;
            this.checkBox_BGM.Click += new System.EventHandler(this.checkBox_BGM_Click);
            // 
            // pictBox_ButtonExit
            // 
            this.pictBox_ButtonExit.BackColor = System.Drawing.Color.Transparent;
            this.pictBox_ButtonExit.Image = global::FoodWars.Properties.Resources.button_exit;
            this.pictBox_ButtonExit.Location = new System.Drawing.Point(406, 319);
            this.pictBox_ButtonExit.Name = "pictBox_ButtonExit";
            this.pictBox_ButtonExit.Size = new System.Drawing.Size(134, 36);
            this.pictBox_ButtonExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictBox_ButtonExit.TabIndex = 35;
            this.pictBox_ButtonExit.TabStop = false;
            this.pictBox_ButtonExit.Click += new System.EventHandler(this.pictBox_ButtonExit_Click);
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.BackColor = System.Drawing.Color.Transparent;
            this.labelCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F);
            this.labelCopyright.Location = new System.Drawing.Point(196, 379);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(553, 28);
            this.labelCopyright.TabIndex = 34;
            this.labelCopyright.Text = resources.GetString("labelCopyright.Text");
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBGM
            // 
            this.labelBGM.AutoSize = true;
            this.labelBGM.BackColor = System.Drawing.Color.Transparent;
            this.labelBGM.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.labelBGM.Location = new System.Drawing.Point(224, 182);
            this.labelBGM.Name = "labelBGM";
            this.labelBGM.Size = new System.Drawing.Size(185, 76);
            this.labelBGM.TabIndex = 32;
            this.labelBGM.Text = "BGM";
            this.labelBGM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FoodWars.Properties.Resources.Settings;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.checkBox_BGM);
            this.Controls.Add(this.pictBox_ButtonExit);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelBGM);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "SettingsUserControl";
            this.Size = new System.Drawing.Size(944, 501);
            this.Load += new System.EventHandler(this.SettingsUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checkBox_BGM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_ButtonExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox checkBox_BGM;
        private System.Windows.Forms.PictureBox pictBox_ButtonExit;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelBGM;
    }
}
