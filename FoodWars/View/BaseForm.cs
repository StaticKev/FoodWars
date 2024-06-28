using FoodWars.Service;
using System;
using System.Windows.Forms;

namespace FoodWars.View
{
    public partial class BaseForm : Form
    {
        #region DataMembers
        GameService game;
        #endregion

        #region Constructors
        public BaseForm(GameService game)
        {
            InitializeComponent();
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
        #endregion

        private void BaseForm_Load(object sender, EventArgs e)
        {
            // Main Menu User Control goes here!
        }
    }
}
