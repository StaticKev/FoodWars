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
    public partial class FormSavePlayer : Form
    {
        BaseForm formMenu;
        FormNewPlayer formNewPlayer;
        Players savePlayer;
        PlayerRepo playerRepo;
        public FormSavePlayer(PlayerRepo playerRepo)
        {
            InitializeComponent();
            this.playerRepo = playerRepo;
        }
        private void FormSavePlayer_Load(object sender, EventArgs e)
        {
            formNewPlayer = (FormNewPlayer)this.Owner;
            this.Size = new Size(1920, 1080);
            DisplayReset();
        }

        private void checkBoxSelectPlayer1_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxSelectPlayer2.Checked = false;
            checkBoxSelectPlayer3.Checked = false;
            DisplayReset();
            if (checkBoxSelectPlayer1.Checked == true)
            {
                if (confirmationMessageBox() == DialogResult.Yes)
                {

                    labelPlayerName1.Text += " " + savePlayer.Name;
                    labelBestIncome1.Text += " " + savePlayer.BestIncome;
                    labelBestLevel1.Text += " " + savePlayer.BestLevel;
                    labelTotalIncome1.Text += " " + savePlayer.TotalIncome;
                }
            }
        }

        private void checkBoxSelectPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxSelectPlayer1.Checked = false;
            checkBoxSelectPlayer3.Checked = false;
            DisplayReset();
            if (checkBoxSelectPlayer2.Checked == true && confirmationMessageBox() == DialogResult.Yes)
            {
                if (confirmationMessageBox() == DialogResult.Yes)
                {
                    labelPlayerName2.Text += " " + savePlayer.Name;
                    labelBestIncome2.Text += " " + savePlayer.BestIncome;
                    labelBestLevel2.Text += " " + savePlayer.BestLevel;
                    labelTotalIncome2.Text += " " + savePlayer.TotalIncome;
                }

            }
        }

        private void checkBoxSelectPlayer3_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxSelectPlayer1.Checked = false;
            checkBoxSelectPlayer2.Checked = false;

            DisplayReset();
            if (checkBoxSelectPlayer3.Checked == true)
            {
                if(confirmationMessageBox() == DialogResult.Yes)
                {
                    labelPlayerName3.Text += " " + savePlayer.Name;
                    labelBestIncome3.Text += " " + savePlayer.BestIncome;
                    labelBestLevel3.Text += " " + savePlayer.BestLevel;
                    labelTotalIncome3.Text += " " + savePlayer.TotalIncome;
                }

            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
/*            playerRepo = new PlayerRepo();
*/
            if (confirmationMessageBox() == DialogResult.Yes)
            {
/*                if (checkBoxSelectPlayer1.Checked == true)
                {
                    playerRepo.ArrayPlayers[0] = savePlayer;
                }
                else if (checkBoxSelectPlayer2.Checked == true)
                {
                    playerRepo.ArrayPlayers[1] = savePlayer;
                }
                else
                {
                    playerRepo.ArrayPlayers[2] = savePlayer;
                }*/

            }
            else
            {

            }
/*            formMenu = new BaseForm();*/
/*            formMenu.playerRepo = playerRepo;*/
            formMenu.ShowDialog();
            
        }

        #region METHOD

        public void TransitPlayers(Players transitPlayers)
        {

            savePlayer = new Players(transitPlayers.Name, transitPlayers.Picture);
        }

        private DialogResult confirmationMessageBox()
        {
           return MessageBox.Show("Are you sure to rewrite and delete the following data?","Are you sure?",MessageBoxButtons.YesNo);

        }

        private void DisplayReset()
        {
                if (playerRepo!= null)
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
