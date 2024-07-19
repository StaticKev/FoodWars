using System;
using System.Windows.Forms;

namespace FoodWars.View
{
    public partial class GameLoseUserControl : UserControl
    {
        #region Data Members
        private BaseForm baseForm;
        #endregion

        #region Constructors
        public GameLoseUserControl(BaseForm baseForm)
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

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenuUserControl mainMenuUc = new MainMenuUserControl(BaseForm);

            BaseForm.Game.ResetGameState();

            BaseForm.mainPanel.Controls.Add(mainMenuUc);
            BaseForm.mainPanel.Controls.Remove(this);
            mainMenuUc.Dock = DockStyle.Fill;
        }

        private void GameLoseUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
