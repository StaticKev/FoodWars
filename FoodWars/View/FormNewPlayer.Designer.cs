namespace FoodWars.View
{
    partial class FormNewPlayer
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
            this.panelPlayerPicture = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonSavePlayer = new System.Windows.Forms.Button();
            this.labelInputImage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelPlayerPicture
            // 
            this.panelPlayerPicture.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelPlayerPicture.Font = new System.Drawing.Font("Times New Roman", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelPlayerPicture.Location = new System.Drawing.Point(810, 50);
            this.panelPlayerPicture.Name = "panelPlayerPicture";
            this.panelPlayerPicture.Size = new System.Drawing.Size(300, 300);
            this.panelPlayerPicture.TabIndex = 1;
            this.panelPlayerPicture.Click += new System.EventHandler(this.panelPlayerPicture_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Times New Roman", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(535, 500);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(278, 53);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Player name :";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Times New Roman", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(885, 497);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(500, 62);
            this.textBoxName.TabIndex = 3;
            // 
            // buttonSavePlayer
            // 
            this.buttonSavePlayer.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSavePlayer.Location = new System.Drawing.Point(660, 800);
            this.buttonSavePlayer.Name = "buttonSavePlayer";
            this.buttonSavePlayer.Size = new System.Drawing.Size(600, 100);
            this.buttonSavePlayer.TabIndex = 4;
            this.buttonSavePlayer.Text = "Save Data";
            this.buttonSavePlayer.UseVisualStyleBackColor = true;
            // 
            // labelInputImage
            // 
            this.labelInputImage.AutoSize = true;
            this.labelInputImage.Font = new System.Drawing.Font("Times New Roman", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInputImage.Location = new System.Drawing.Point(727, 375);
            this.labelInputImage.Name = "labelInputImage";
            this.labelInputImage.Size = new System.Drawing.Size(468, 37);
            this.labelInputImage.TabIndex = 5;
            this.labelInputImage.Text = "Input image by clicking the square above";
            this.labelInputImage.UseCompatibleTextRendering = true;
            this.labelInputImage.Click += new System.EventHandler(this.labelInputImage_Click);
            // 
            // FormNewPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1888, 992);
            this.Controls.Add(this.labelInputImage);
            this.Controls.Add(this.buttonSavePlayer);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.panelPlayerPicture);
            this.Name = "FormNewPlayer";
            this.Text = "FormNewPlayer";
            this.Load += new System.EventHandler(this.FormNewPlayer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPlayerPicture;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonSavePlayer;
        private System.Windows.Forms.Label labelInputImage;
    }
}