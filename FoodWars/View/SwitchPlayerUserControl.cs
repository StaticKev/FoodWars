using FoodWars.Repository;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FoodWars.View
{
    public partial class SwitchPlayerUserControl : UserControl
    {
        #region Data Members
        private BaseForm baseForm;
        private BindingList<Players> players; // jangan lupa kasi property 
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

            // Update combo box
            players = new BindingList<Players>(BaseForm.Game.GetPlayers());
            comboBox_Players.DataSource = players;
            comboBox_Players.DisplayMember = "Name";

            DisplayData();
            UpdateCurrentPlayer((Players)comboBox_Players.SelectedItem);
        }

        private void Button_backToMainMenu_Click(object sender, EventArgs e)
        {
            MainMenuUserControl mainMenu = new MainMenuUserControl(BaseForm);

            BaseForm.mainPanel.Controls.Remove(this);
            BaseForm.mainPanel.Controls.Add(mainMenu);
            mainMenu.Dock = DockStyle.Fill;
        }

        private void Button_newPlayer_Click(object sender, EventArgs e)
        {
            NewPlayerUserControl newPlayerUc = new NewPlayerUserControl(BaseForm);

            BaseForm.mainPanel.Controls.Remove(this);
            BaseForm.mainPanel.Controls.Add(newPlayerUc);
            newPlayerUc.Dock = DockStyle.Fill;
        }

        private void ComboBox_Player_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayData();
            UpdateCurrentPlayer((Players)comboBox_Players.SelectedItem);
        }
        #endregion

        #region Methods
        private void DisplayData()
        {
            if (players.Count > 0)
            {
                Players player = (Players)comboBox_Players.SelectedItem;
                label_level.Text = player.Level.ToString();
                label_totalIncome.Text = player.TotalIncome.ToString();
                label_bestIncome.Text = player.BestIncome.ToString();
                label_bestTime.Text = player.BestTime.DurationToString();
                pictBox_Profile.BackgroundImage = player.Picture;
            }
        }

        private void UpdateCurrentPlayer(Players player)
        {
            try
            {
                BaseForm.Game.Player = player;
            } catch (Exception ex) { }
           
        }
        #endregion
    }
}
