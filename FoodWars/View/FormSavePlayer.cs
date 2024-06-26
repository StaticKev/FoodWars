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
    public partial class FormSavePlayer : Form
    {
        FormNewPlayer formNewPlayer;
        public FormSavePlayer()
        {
            InitializeComponent();
        }

        private void FormSavePlayer_Load(object sender, EventArgs e)
        {
            formNewPlayer = (FormNewPlayer)this.Owner;
            this.Size = new Size(1920, 1080);
        }
    }
}
