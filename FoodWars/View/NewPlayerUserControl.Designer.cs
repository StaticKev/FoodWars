namespace FoodWars.View
{
    partial class NewPlayerUserControl
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
            this.button_Cancel = new System.Windows.Forms.Button();
            this.labelInputImage = new System.Windows.Forms.Label();
            this.button_SavePlayer = new System.Windows.Forms.Button();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.pictBox_Image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("Samurai Blast", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cancel.Location = new System.Drawing.Point(303, 374);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(159, 38);
            this.button_Cancel.TabIndex = 0;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // labelInputImage
            // 
            this.labelInputImage.AutoSize = true;
            this.labelInputImage.BackColor = System.Drawing.Color.Transparent;
            this.labelInputImage.Font = new System.Drawing.Font("Times New Roman", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInputImage.Location = new System.Drawing.Point(380, 281);
            this.labelInputImage.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelInputImage.Name = "labelInputImage";
            this.labelInputImage.Size = new System.Drawing.Size(191, 17);
            this.labelInputImage.TabIndex = 15;
            this.labelInputImage.Text = "Input image by clicking the square above!";
            this.labelInputImage.UseCompatibleTextRendering = true;
            // 
            // button_SavePlayer
            // 
            this.button_SavePlayer.Font = new System.Drawing.Font("Samurai Blast", 12F);
            this.button_SavePlayer.Location = new System.Drawing.Point(486, 374);
            this.button_SavePlayer.Margin = new System.Windows.Forms.Padding(1);
            this.button_SavePlayer.Name = "button_SavePlayer";
            this.button_SavePlayer.Size = new System.Drawing.Size(159, 38);
            this.button_SavePlayer.TabIndex = 14;
            this.button_SavePlayer.Text = "Save Data";
            this.button_SavePlayer.UseVisualStyleBackColor = true;
            this.button_SavePlayer.Click += new System.EventHandler(this.button_SavePlayer_Click);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Font = new System.Drawing.Font("Times New Roman", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Name.Location = new System.Drawing.Point(454, 322);
            this.textBox_Name.Margin = new System.Windows.Forms.Padding(1);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(190, 29);
            this.textBox_Name.TabIndex = 13;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("Samurai Blast", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(306, 328);
            this.labelName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(139, 16);
            this.labelName.TabIndex = 12;
            this.labelName.Text = "Player name :";
            // 
            // pictBox_Image
            // 
            this.pictBox_Image.BackColor = System.Drawing.Color.Transparent;
            this.pictBox_Image.BackgroundImage = global::FoodWars.Properties.Resources.Symbol_Plus;
            this.pictBox_Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictBox_Image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictBox_Image.Location = new System.Drawing.Point(416, 141);
            this.pictBox_Image.Name = "pictBox_Image";
            this.pictBox_Image.Size = new System.Drawing.Size(124, 124);
            this.pictBox_Image.TabIndex = 0;
            this.pictBox_Image.TabStop = false;
            this.pictBox_Image.Click += new System.EventHandler(this.PictureBox_Image_Click);
            this.pictBox_Image.MouseEnter += new System.EventHandler(this.PictureBox_Image_MouseEnter);
            this.pictBox_Image.MouseLeave += new System.EventHandler(this.PictureBox_Image_MouseLeave);
            // 
            // NewPlayerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FoodWars.Properties.Resources.NewPlayerUserControl;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pictBox_Image);
            this.Controls.Add(this.button_SavePlayer);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.labelInputImage);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.labelName);
            this.DoubleBuffered = true;
            this.Name = "NewPlayerUserControl";
            this.Size = new System.Drawing.Size(944, 501);
            this.Load += new System.EventHandler(this.NewPlayerUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictBox_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label labelInputImage;
        private System.Windows.Forms.Button button_SavePlayer;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.PictureBox pictBox_Image;
    }
}
