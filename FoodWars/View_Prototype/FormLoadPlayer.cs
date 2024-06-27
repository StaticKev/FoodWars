using FoodWars.Repository;
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
    public partial class FormLoadPlayer : Form
    {
        Players selectedPlayers;
        MainMenuForm formMenu;
        PlayerRepo playerRepo;
        public FormLoadPlayer()
        {
            InitializeComponent();
        }

        private void FormLoadPlayer_Load(object sender, EventArgs e)
        {
            formMenu = (MainMenuForm)this.Owner;
            this.Size = new Size(1920, 1080);
            //Tambahkan fitur kalau ga ada file yang diinginkan berati disabled groupbox

            Display();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {

/*            if (checkBoxSelectPlayer1.Checked == true)
            {
                selectedPlayers = playerRepo.ArrayPlayers[0];
            }
            else if (checkBoxSelectPlayer2.Checked == true)
            {
                selectedPlayers = playerRepo.ArrayPlayers[1];
            }
            else
            {
                selectedPlayers = playerRepo.ArrayPlayers[2];
            }*/
            FormLevelDescription form = new FormLevelDescription();
            form.Owner = this;
            form.ShowDialog();
        }

        #region METHOD

        private void Display()
        {
            
                if (playerRepo != null)
                {
/*                    labelPlayerName1.Text += " " + playerRepo.ArrayPlayers[0].Name;
                    labelBestIncome1.Text += " " + playerRepo.ArrayPlayers[0].BestIncome;
                    labelBestLevel1.Text += " " + playerRepo.ArrayPlayers[0].BestLevel;
                    labelTotalIncome1.Text += " " + playerRepo.ArrayPlayers[0].TotalIncome;

                    labelPlayerName2.Text += " " + playerRepo.ArrayPlayers[1].Name;
                    labelBestIncome2.Text += " " + playerRepo.ArrayPlayers[1].BestIncome;
                    labelBestLevel2.Text += " " + playerRepo.ArrayPlayers[1].BestLevel;
                    labelTotalIncome2.Text += " " + playerRepo.ArrayPlayers[1].TotalIncome;

                    labelPlayerName3.Text += " " + playerRepo.ArrayPlayers[2].Name;
                    labelBestIncome3.Text += " " + playerRepo.ArrayPlayers[2].BestIncome;
                    labelBestLevel3.Text += " " + playerRepo.ArrayPlayers[2].BestLevel;
                    labelTotalIncome3.Text += " " + playerRepo.ArrayPlayers[2].TotalIncome;*/

                }
            
        }



        #endregion
    }
}
