using FoodWars.Service;
using FoodWars.Utilities;
using System;
using System.Windows.Forms;

namespace FoodWars.View
{
    public partial class BaseForm : Form
    {
        #region DataMembers
        private GameService game;
        private GameConfig gameConfig;
        // Tambahkan BGM
        #endregion

        #region Constructors
        public BaseForm(GameService game, GameConfig gameConfig)
        {
            InitializeComponent();
            this.Game = game;
            this.GameConfig = gameConfig;

            // Nyalakan BGM
        }
        #endregion

        #region Properties
        private GameService Game
        {
            get => this.game;
            set
            {
                if (value == null) throw new NullReferenceException("No service specified!");
                else this.game = value;
            }
        }
        private GameConfig GameConfig
        {
            get => this.gameConfig;
            set
            {
                if (value == null) throw new NullReferenceException("No config found!");
                else this.gameConfig = value;
            }
        }
        #endregion

        private void BaseForm_Load(object sender, EventArgs e)
        {
            MainMenuUserControl mainMenuUserControl = new MainMenuUserControl(this);

            mainPanel.Controls.Add(mainMenuUserControl);
            mainPanel.Dock = DockStyle.Fill;
        }
    }
}
