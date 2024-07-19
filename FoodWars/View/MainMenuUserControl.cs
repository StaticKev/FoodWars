using FoodWars.Properties;
using FoodWars.Service;
using System;
using System.Media;
using System.Windows.Forms;

namespace FoodWars.View
{
    public partial class MainMenuUserControl : UserControl
    {
        #region Data Members
        private BaseForm baseForm;
        private GameService game;
        #endregion

        #region Constructors
        public MainMenuUserControl(BaseForm baseForm)
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
        private void MainMenuUserControl_Load(object sender, EventArgs e)
        {
            if (BaseForm.Game.Player == null)
            {
                pictBox_ButtonStart.Image = Resources.button_start_disabled;
            }
            else
            {
                label_Name.Text = "Name: " + BaseForm.Game.Player.Name;
                label_Level.Text = "Level: " + BaseForm.Game.Player.Level.ToString();
                pictBox_Profile.BackgroundImage = BaseForm.Game.Player.Picture;
                pictBox_ButtonStart.Image = Resources.button_start;
            }
        }
        #region START
        private void Button_Start_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.Player != null)
            {
                BaseForm.PlaySfx(new SoundPlayer(Resources.sfx_buttonClick1));

                InGameUserControl inGameUc = new InGameUserControl(BaseForm);
                BaseForm.mainPanel.Controls.Add(inGameUc);
                BaseForm.mainPanel.Controls.Remove(this);
                inGameUc.Dock = DockStyle.Fill;
            }
        }

        private void Button_Start_MouseEnter(object sender, EventArgs e)
        {
            if (BaseForm.Game.Player == null)
            {
                pictBox_ButtonStart.Image = Properties.Resources.button_start_disabled;
            }
            else
            {
                BaseForm.PlaySfx(new SoundPlayer(Resources.sfx_buttonHover1));
                pictBox_ButtonStart.Image = Resources.button_start_stroke;
            }
        }

        private void Button_Start_MouseLeave(object sender, EventArgs e)
        {
            if (BaseForm.Game.Player == null)
            {
                pictBox_ButtonStart.Image = Properties.Resources.button_start_disabled;
            }
            else
            {
                pictBox_ButtonStart.Image = Resources.button_start;
            }
        }
        #endregion
        #region SWITCH PLAYER
        private void Button_SwitchPlayer_Click(object sender, EventArgs e)
        {
            BaseForm.PlaySfx(new SoundPlayer(Resources.sfx_buttonClick1));

            SwitchPlayerUserControl switchPlayerUc = new SwitchPlayerUserControl(BaseForm);
            BaseForm.mainPanel.Controls.Remove(this);
            BaseForm.mainPanel.Controls.Add(switchPlayerUc);
            switchPlayerUc.Dock = DockStyle.Fill;

        }

        private void Button_SwitchPlayer_MouseEnter(object sender, EventArgs e)
        {
            BaseForm.PlaySfx(new SoundPlayer(Resources.sfx_buttonHover1));
            pictBox_ButtonSwitchPlayer.Image = Resources.button_switchPlayer_stroke;
        }

        private void Button_SwitchPlayer_MouseLeave(object sender, EventArgs e)
        {
            pictBox_ButtonSwitchPlayer.Image = Resources.button_switchPlayer;
        }
        #endregion
        #region LEADERBOARD
        private void Button_Leaderboard_Click(object sender, EventArgs e)
        {
            BaseForm.PlaySfx(new SoundPlayer(Resources.sfx_buttonClick1));

            LeaderboardUserControl leaderboardUc = new LeaderboardUserControl(BaseForm);
            BaseForm.mainPanel.Controls.Remove(this);
            BaseForm.mainPanel.Controls.Add(leaderboardUc);
            leaderboardUc.Dock = DockStyle.Fill;
        }

        private void Button_Leaderboard_MouseEnter(object sender, EventArgs e)
        {
            BaseForm.PlaySfx(new SoundPlayer(Resources.sfx_buttonHover1));
            pictBox_Leaderboard.Image = Resources.button_leaderboard_stroke;
        }

        private void Button_Leaderboard_MouseLeave(object sender, EventArgs e)
        {
            pictBox_Leaderboard.Image = Resources.button_leaderboard;
        }
        #endregion
        #region SETTINGS
        private void Button_Settings_MouseClick(object sender, EventArgs e)
        {
            BaseForm.PlaySfx(new SoundPlayer(Resources.sfx_buttonClick1));

            SettingsUserControl settingsUc = new SettingsUserControl(BaseForm);

            BaseForm.mainPanel.Controls.Remove(this);
            BaseForm.mainPanel.Controls.Add(settingsUc);
            settingsUc.Dock = DockStyle.Fill;
        }

        private void Button_Settings_MouseEnter(object sender, EventArgs e)
        {
            BaseForm.PlaySfx(new SoundPlayer(Resources.sfx_buttonHover1));
            pictBox_ButtonSettings.Image = Resources.button_settings_stroke;
        }

        private void Button_Settings_MouseLeave(object sender, EventArgs e)
        {
            pictBox_ButtonSettings.Image = Resources.button_settings;
        }
        #endregion
        #region EXIT BUTTON
        private void Button_Exit_MouseClick(object sender, EventArgs e)
        {
            BaseForm.PlaySfx(new SoundPlayer(Resources.sfx_buttonClick1));
            Application.Exit();
        }

        private void Button_Exit_MouseEnter(object sender, EventArgs e)
        {
            BaseForm.PlaySfx(new SoundPlayer(Resources.sfx_buttonHover1));
            pictBox_ButtonExit.Image = Resources.button_exit_stroke;
        }

        private void Button_Exit_MouseLeave(object sender, EventArgs e)
        {
            pictBox_ButtonExit.Image = Resources.button_exit;
        }
        #endregion
        #endregion
    }
}
