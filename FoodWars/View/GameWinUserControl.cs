using System;
using System.Windows.Forms;

namespace FoodWars.View
{
    public partial class GameWinUserControl : UserControl
    {
        #region Data Members
        private BaseForm baseForm;
        #endregion

        #region Constructors
        public GameWinUserControl(BaseForm baseForm)
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

        private void GameWinUserControl_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseForm.Game.UpdatePlayerData();

            BaseForm.Game.ResetGameState();

            MainMenuUserControl mainMenuUc = new MainMenuUserControl(BaseForm);

            BaseForm.mainPanel.Controls.Add(mainMenuUc);
            BaseForm.mainPanel.Controls.Remove(this);
            mainMenuUc.Dock = DockStyle.Fill;
        }
    }
}
