using FoodWars.Properties;
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
    public partial class LeaderboardUserControl : UserControl
    {
        #region Data Members
        private BaseForm baseForm;
        private List<Players> listRankPlayers;
        private int pageIndex;
        #endregion

        #region Constructors
        public LeaderboardUserControl(BaseForm baseForm)
        {
            InitializeComponent();
            this.baseForm = baseForm;
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

        #region EVENT HANDLER
        private void LeaderboardUserControl_Load(object sender, EventArgs e)
        {
            pageIndex = 0;
            CopyList();
            RankList();
            DisplayRank();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if ((pageIndex + 1) <= ((listRankPlayers.Count + 1) / 5))
            {
                pageIndex++;
                DisplayRank();
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if ((pageIndex - 1) >= 0)
            {
                pageIndex--;
                DisplayRank();
            }
        }

        #region EXIT
        private void Button_Exit_MouseEnter(object sender, EventArgs e)
        {
        }

        private void Button_Exit_MouseLeave(object sender, EventArgs e)
        {
        }

        private void pictBox_ButtonExit_Click(object sender, EventArgs e)
        {
            MainMenuUserControl mainMenu = new MainMenuUserControl(BaseForm);

            BaseForm.mainPanel.Controls.Remove(this);
            BaseForm.mainPanel.Controls.Add(mainMenu);
            mainMenu.Dock = DockStyle.Fill;
        }
        #endregion
        #endregion

        #region METHOD
        private void CopyList()
        {
            listRankPlayers = new List<Players>();
            //Mengcopy list players dari service menuju list di user control
            foreach (Players p in baseForm.Game.GetPlayers())
            {
                this.listRankPlayers.Add(p);
            }
        }

        //Mengurutkan players
        private void RankList()
        {
            Players buffer;
            int mismatch = 1;
            while (mismatch != 0)
            {
                mismatch = 0;
                for (int i = 1; i < this.listRankPlayers.Count; i++)
                {
                    //Mengurutkan players berdasarkan income
                    if (listRankPlayers[i].TotalIncome > listRankPlayers[i - 1].TotalIncome)
                    {
                        buffer = listRankPlayers[i - 1];
                        listRankPlayers[i - 1] = listRankPlayers[i];
                        listRankPlayers[i] = buffer;
                        mismatch++;
                    }
                    //Mengurutkan players berdasarkan level
                    else if (listRankPlayers[i].TotalIncome == listRankPlayers[i - 1].TotalIncome)
                    {
                        if (listRankPlayers[i].Level > listRankPlayers[i - 1].Level)
                        {
                            buffer = listRankPlayers[i - 1];
                            listRankPlayers[i - 1] = listRankPlayers[i];
                            listRankPlayers[i] = buffer;
                        }
                        mismatch++;
                    }
                }
            }

        }


        private void DisplayRank()
        {
            int i = pageIndex * 5;

            //Label 1
            if (i < listRankPlayers.Count)
            {
                labelRank1.Text = (i + 1).ToString();
                labelName1.Text = listRankPlayers[i].Name;
                labelLevel1.Text = listRankPlayers[i].Level.ToString();
                labelIncome1.Text = listRankPlayers[i].TotalIncome.ToString();
            }
            //Label 2
            if ((i + 1) < listRankPlayers.Count)
            {
                labelRank2.Text = (i + 2).ToString();
                labelName2.Text = listRankPlayers[i + 1].Name;
                labelLevel2.Text = listRankPlayers[i + 1].Level.ToString();
                labelIncome2.Text = listRankPlayers[i + 1].TotalIncome.ToString();
            }
            //Label 3
            if ((i + 2) < listRankPlayers.Count)
            {
                labelRank3.Text = (i + 3).ToString();
                labelName3.Text = listRankPlayers[i + 2].Name;
                labelLevel3.Text = listRankPlayers[i + 2].Level.ToString();
                labelIncome3.Text = listRankPlayers[i + 2].TotalIncome.ToString();
            }
            //Label 4
            if ((i + 3) < listRankPlayers.Count)
            {
                labelRank4.Text = (i + 4).ToString();
                labelName4.Text = listRankPlayers[i + 3].Name;
                labelLevel4.Text = listRankPlayers[i + 3].Level.ToString();
                labelIncome4.Text = listRankPlayers[i + 3].TotalIncome.ToString();
            }
            //Label 5
            if ((i + 4) < listRankPlayers.Count)
            {
                labelRank5.Text = (i + 5).ToString();
                labelName5.Text = listRankPlayers[i + 4].Name;
                labelLevel5.Text = listRankPlayers[i + 4].Level.ToString();
                labelIncome5.Text = listRankPlayers[i + 4].TotalIncome.ToString();
            }
            if (pageIndex == 0)
            {

                pageIndex = 1;
            }
            labelIndex.Text = pageIndex + " / " + Math.Ceiling((double)listRankPlayers.Count / 5);

        }
        #endregion
    }
}
