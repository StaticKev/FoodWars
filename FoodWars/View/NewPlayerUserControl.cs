using FoodWars.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FoodWars.View
{
    public partial class NewPlayerUserControl : UserControl
    {
        #region Data Members
        private BaseForm baseForm;
        #endregion

        #region Constructors
        public NewPlayerUserControl(BaseForm baseForm)
        {
            InitializeComponent();
            this.BaseForm = baseForm;
        }
        #endregion

        #region Properties
        private BaseForm BaseForm
        {
            get => baseForm;
            set
            {
                if (value == null) throw new Exception("No base form specified!");
                else this.baseForm = value;
            }
        }
        #endregion

        #region Event Handlers
        private void NewPlayerUserControl_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox_Image_Click(object sender, EventArgs e)
        {
            try
            {
                // Membuka file dialog untuk memasukan gambar player
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
                dialog.ShowDialog();
                // Menampilkan gambar yang dipilih dari file melalui panel.
                pictBox_Image.BackgroundImage = Image.FromFile(dialog.FileName);
            }
            catch (Exception ex) 
            {
                pictBox_Image.BackgroundImage = Resources.DefaultIcon;
            }
        }

        private void PictureBox_Image_MouseEnter(object sender, EventArgs e)
        {
            if (pictBox_Image.BackgroundImage.Flags == Resources.Symbol_Plus.Flags)
            {
                pictBox_Image.BackgroundImage = Resources.Symbol_Plus_Stroke;
            } 
        }

        private void PictureBox_Image_MouseLeave(object sender, EventArgs e)
        {
            if (pictBox_Image.BackgroundImage.Flags == Resources.Symbol_Plus_Stroke.Flags)
            {
                pictBox_Image.BackgroundImage = Resources.Symbol_Plus;
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            SwitchPlayerUserControl switchPlayerUc = new SwitchPlayerUserControl(BaseForm);

            BaseForm.mainPanel.Controls.Remove(this);
            BaseForm.mainPanel.Controls.Add(switchPlayerUc);
            switchPlayerUc.Dock = DockStyle.Fill;
        }

        private void button_SavePlayer_Click(object sender, EventArgs e)
        {
            if (pictBox_Image.BackgroundImage.Flags == Resources.Symbol_Plus.Flags)
            {
                MessageBox.Show("No image specified!");
            }
            else if (textBox_Name.Text == "")
            {
                MessageBox.Show("Please insert a name!");
            }
            else
            {
                // Buat player baru
                Players newPlayer = new Players(textBox_Name.Text, pictBox_Image.BackgroundImage);
                // Panggil method AddPlayer di service
                BaseForm.Game.AddPlayer(newPlayer);
                MessageBox.Show("Successfully added a new player!");

                textBox_Name.Text = "";
                pictBox_Image.BackgroundImage = Resources.Symbol_Plus;
            }
        }
        #endregion
    }
}
