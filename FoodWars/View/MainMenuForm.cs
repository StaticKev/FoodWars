using FoodWars.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodWars
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }
        #region Form Load
        private void MainMenuForm_Load(object sender, EventArgs e)
        {

            this.Size = new Size(1920, 1080);
        }
        #endregion

        #region Form Button
        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            FormNewPlayer form = new FormNewPlayer();
            form.Owner = this;
            form.ShowDialog();
        }

        private void buttonLoadGame_Click(object sender, EventArgs e)
        {
            FormLoadPlayer form = new FormLoadPlayer();
            form.Owner = this;
            form.ShowDialog();
        }

        private void buttonExitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
