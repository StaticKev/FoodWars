using System;
using System.Windows.Forms;

namespace FoodWars.View
{
    public partial class SwitchPlayerUserControl : UserControl
    {
        #region Data Members
        private BaseForm baseForm;
        #endregion

        #region Constructors
        public SwitchPlayerUserControl(BaseForm baseForm)
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
        private void SwitchPlayerUserControl_Load(object sender, EventArgs e)
        {
            comboBox_Players.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button_backToMainMenu_Click(object sender, EventArgs e)
        {
            MainMenuUserControl mainMenu = new MainMenuUserControl(BaseForm);

            BaseForm.mainPanel.Controls.Remove(this);
            BaseForm.mainPanel.Controls.Add(mainMenu);
            mainMenu.Dock = DockStyle.Fill;

        }
        #endregion
    }
}
