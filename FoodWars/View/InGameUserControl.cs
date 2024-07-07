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
    public partial class InGameUserControl : UserControl
    {
        #region Data Members
        private BaseForm baseForm;
        #endregion

        #region Constructors
        public InGameUserControl(BaseForm baseForm)
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
        private void InGameUserControl_Load(object sender, EventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Mengupdate open duration
            
        }
        #endregion
    }
}
