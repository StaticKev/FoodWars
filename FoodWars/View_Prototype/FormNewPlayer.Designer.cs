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
            this.labelInputImage = new System.Windows.Forms.Label();
            this.buttonSavePlayer = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.panelPlayerPicture = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labelInputImage
            // 
            this.labelInputImage.AutoSize = true;
            this.labelInputImage.Font = new System.Drawing.Font("Times New Roman", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInputImage.Location = new System.Drawing.Point(273, 167);
            this.labelInputImage.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelInputImage.Name = "labelInputImage";
            this.labelInputImage.Size = new System.Drawing.Size(188, 17);
            this.labelInputImage.TabIndex = 10;
            this.labelInputImage.Text = "Input image by clicking the square above";
            this.labelInputImage.UseCompatibleTextRendering = true;
            this.labelInputImage.Click += new System.EventHandler(this.labelInputImage_Click);
            // 
            // buttonSavePlayer
            // 
            this.buttonSavePlayer.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSavePlayer.Location = new System.Drawing.Point(241, 341);
            this.buttonSavePlayer.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSavePlayer.Name = "buttonSavePlayer";
            this.buttonSavePlayer.Size = new System.Drawing.Size(225, 42);
            this.buttonSavePlayer.TabIndex = 9;
            this.buttonSavePlayer.Text = "Save Data";
            this.buttonSavePlayer.UseVisualStyleBackColor = true;
            this.buttonSavePlayer.Click += new System.EventHandler(this.buttonSavePlayer_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Times New Roman", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(325, 213);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(190, 29);
            this.textBoxName.TabIndex = 8;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Times New Roman", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(194, 216);
            this.labelName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(109, 21);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "Player name :";
            // 
            // panelPlayerPicture
            // 
            this.panelPlayerPicture.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelPlayerPicture.Font = new System.Drawing.Font("Times New Roman", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelPlayerPicture.Location = new System.Drawing.Point(297, 26);
            this.panelPlayerPicture.Margin = new System.Windows.Forms.Padding(1);
            this.panelPlayerPicture.Name = "panelPlayerPicture";
            this.panelPlayerPicture.Size = new System.Drawing.Size(112, 126);
            this.panelPlayerPicture.TabIndex = 6;
            this.panelPlayerPicture.Click += new System.EventHandler(this.panelPlayerPicture_Click);
            this.panelPlayerPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPlayerPicture_Paint);
            // 
            // FormNewPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 437);
            this.Controls.Add(this.labelInputImage);
            this.Controls.Add(this.buttonSavePlayer);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.panelPlayerPicture);
            this.MaximumSize = new System.Drawing.Size(730, 476);
            this.Name = "FormNewPlayer";
            this.Text = "FormSavePlayer";
            this.Load += new System.EventHandler(this.FormNewPlayer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInputImage;
        private System.Windows.Forms.Button buttonSavePlayer;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Panel panelPlayerPicture;
    }
}