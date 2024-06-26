using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodWars.View
{
    public partial class FormNewPlayer : Form
    {
        MainMenuForm formMenu;
        public FormNewPlayer()
        {
            InitializeComponent();
        }

        private void FormNewPlayer_Load(object sender, EventArgs e)
        {
            formMenu = (MainMenuForm)this.Owner;
            this.Size = new Size(1920, 1080);
        }

        private void buttonSavePlayer_Click(object sender, EventArgs e)
        {
            //Membuat object player baru
            Players newPlayer = new Players(textBoxName.Text, panelPlayerPicture.BackgroundImage);
            FormSavePlayer form = new FormSavePlayer();
            //Method untuk memindahkan data object
            form.TransitPlayers(newPlayer);
            form.Owner = this;
            this.Close();
            form.ShowDialog();
        }

        private void panelPlayerPicture_Click(object sender, EventArgs e)
        {
            ChoosingImageFromFile();
        }

        private void labelInputImage_Click(object sender, EventArgs e)
        {
            ChoosingImageFromFile();
        }

        #region METHOD

        private void ChoosingImageFromFile()
        {


            try
            {
                //Membuka file dialog untuk memasukan gambar player
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
                dialog.ShowDialog();
                //Menampilkan gambar yang dipilih dari file melalui panel.
                panelPlayerPicture.BackgroundImage = Image.FromFile(dialog.FileName);
                panelPlayerPicture.BackgroundImageLayout = ImageLayout.Stretch;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        #endregion
    }
}
