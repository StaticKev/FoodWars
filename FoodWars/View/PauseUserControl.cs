using System;
using System.Windows.Forms;

namespace FoodWars.View
{
    public partial class PauseUserControl : UserControl
    {
        #region Data Members
        private BaseForm baseForm;
        private InGameUserControl inGameUc;
        #endregion

        #region Constructors
        public PauseUserControl(BaseForm baseForm, InGameUserControl inGameUc)
        {
            InitializeComponent();
            this.BaseForm = baseForm;
            this.InGameUc = inGameUc;
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
        private InGameUserControl InGameUc
        {
            get => inGameUc;
            set
            {
                if (value == null) throw new Exception("No InGameUserControl specified!");
                else this.inGameUc = value;
            }
        }
        #endregion

        private void PauseUserControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Navigate back to InGameView
            // Remove yang ini, start timer, tampilkan yang sebelumnya. 
            InGameUc.timer.Start();
            BaseForm.mainPanel.Controls.Add(InGameUc);
            BaseForm.mainPanel.Controls.Remove(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenuUserControl mainMenuUc = new MainMenuUserControl(BaseForm);

            BaseForm.Game.ResetGameState();
            InGameUc.timer.Stop();
            BaseForm.mainPanel.Controls.Add(mainMenuUc);
            BaseForm.mainPanel.Controls.Remove(this);
            BaseForm.mainPanel.Controls.Remove(inGameUc);
            mainMenuUc.Dock = DockStyle.Fill;
        }
    }
}
