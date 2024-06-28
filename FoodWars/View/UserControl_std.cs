using System;
using System.Windows.Forms;

namespace FoodWars.View
{
    /// <summary>
    /// Standard user control for this application.
    /// NDAK BOLEH DIPAKE!
    /// </summary>

    public partial class UserControl_Sample : UserControl
    {
        #region Data Members
        private BaseForm baseForm;
        #endregion

        #region Constructors
        public UserControl_Sample(BaseForm baseForm)
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
        private void UserControl_Sample_Load(object sender, EventArgs e)
        {
            // Must be left empty!
        }
        #endregion
    }
}
