using FoodWars.Properties;
using FoodWars.Utilities;
using System;
using System.Windows.Forms;

namespace FoodWars.View
{
    public partial class SettingsUserControl : UserControl
    {
        #region Data Members
        private BaseForm baseForm;
        #endregion

        #region Constructors
        public SettingsUserControl(BaseForm baseForm)
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

        private void SettingsUserControl_Load(object sender, EventArgs e)
        {
            if (this.BaseForm.GameConfig.BgmOn == true)
            {
                checkBox_BGM.Image = Properties.Resources.Checkbox_Check_True;

            }
            else
            {

                checkBox_BGM.Image = Resources.Chekcbox_Checked_False;

            }
        }

        private void checkBox_BGM_Click(object sender, EventArgs e)
        {
            BaseForm.GameConfig.UpdateBgmStatus(!BaseForm.GameConfig.BgmOn);
            if (BaseForm.GameConfig.BgmOn)
            {
                checkBox_BGM.Image = Resources.Checkbox_Check_True;
                BaseForm.Bgm.Play();
            }
            else
            {
                checkBox_BGM.Image = Resources.Chekcbox_Checked_False;
                BaseForm.Bgm.Stop();
            }
        }

        private void pictBox_ButtonExit_Click(object sender, EventArgs e)
        {
            MainMenuUserControl mainMenuUc = new MainMenuUserControl(BaseForm);

            BaseForm.mainPanel.Controls.Add(mainMenuUc);
            BaseForm.mainPanel.Controls.Remove(this);
            mainMenuUc.Dock = DockStyle.Fill;
        }
    }
}
