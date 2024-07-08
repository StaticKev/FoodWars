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
    public partial class SettingsUserControl : UserControl
    {

        #region Data Members
        private BaseForm baseForm;
        private List<Players> listRankPlayers;
        private int pageIndex = 0;
        #endregion

        #region Constructors
        public SettingsUserControl(BaseForm baseform)
        {
            InitializeComponent();
            this.BaseForm = baseform;
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
            if(this.BaseForm.GameConfig.SfxOn ==true)
            {

                checkBox_SFX.Image = Properties.Resources.Checkbox_Check_True;

            }
            else
            {

                checkBox_SFX.Image = Properties.Resources.Chekcbox_Checked_False1;

            }
            if (this.BaseForm.GameConfig.BgmOn == true)
            {
                checkBox_BGM.Image = Properties.Resources.Checkbox_Check_True;

            }
            else
            {

                checkBox_BGM.Image = Properties.Resources.Chekcbox_Checked_False1;

            }
        }

        private void checkBox_BGM_Click(object sender, EventArgs e)
        {
            if (this.BaseForm.GameConfig.BgmOn == true)
            {
                checkBox_BGM.Image = Properties.Resources.Checkbox_Check_True;
                BaseForm.GameConfig.BgmOn = false;
            }
            else
            {

                checkBox_BGM.Image = Properties.Resources.Chekcbox_Checked_False1;
                BaseForm.GameConfig.BgmOn = true;
            }
        }

        private void checkBox_SFX_Click(object sender, EventArgs e)
        {
            if (this.BaseForm.GameConfig.BgmOn == true)
            {
                checkBox_SFX.Image = Properties.Resources.Checkbox_Check_True;
                BaseForm.GameConfig.SfxOn = false;
            }
            else
            {

                checkBox_SFX.Image = Properties.Resources.Chekcbox_Checked_False1;
                BaseForm.GameConfig.SfxOn = true;
            }
        }
        private void Button_Exit_MouseEnter(object sender, EventArgs e)
        {

            pictBox_ButtonExit.Image = Resources.button_exit_stroke;
        }

        private void Button_Exit_MouseLeave(object sender, EventArgs e)
        {
            pictBox_ButtonExit.Image = Resources.button_exit;
        }

        private void pictBox_ButtonExit_Click(object sender, EventArgs e)
        {
            MainMenuUserControl mainMenu = new MainMenuUserControl(BaseForm);

            BaseForm.mainPanel.Controls.Remove(this);
            BaseForm.mainPanel.Controls.Add(mainMenu);
            mainMenu.Dock = DockStyle.Fill;
        }
    }
}
