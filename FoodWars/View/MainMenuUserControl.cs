﻿using FoodWars.Properties;
using FoodWars.Service;
using System;
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
                pictBox_ButtonStart.Image = Resources.button_start;
            }

        }
        #region START
        private void Button_Start_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.Player != null)
            {
                // Navigate to GameView
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
            SwitchPlayerUserControl switchPlayerUc = new SwitchPlayerUserControl(BaseForm);

            BaseForm.mainPanel.Controls.Remove(this);
            BaseForm.mainPanel.Controls.Add(switchPlayerUc);
            switchPlayerUc.Dock = DockStyle.Fill;

        }

        private void Button_SwitchPlayer_MouseEnter(object sender, EventArgs e)
        {
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
            // Navigate to view
        }

        private void Button_Leaderboard_MouseEnter(object sender, EventArgs e)
        {
            pictBox_Leaderboard.Image = Resources.button_lederboard_stroke;
        }

        private void Button_Leaderboard_MouseLeave(object sender, EventArgs e)
        {
            pictBox_Leaderboard.Image = Resources.button_leaderboard;
        }
        #endregion
        #region SETTINGS
        private void Button_Settings_MouseClick(object sender, EventArgs e)
        {
            // Navigate to view
        }

        private void Button_Settings_MouseEnter(object sender, EventArgs e)
        {
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
            Application.Exit();
        }

        private void Button_Exit_MouseEnter(object sender, EventArgs e)
        {
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
