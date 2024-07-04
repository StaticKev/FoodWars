using System;
using System.Windows.Forms;

namespace FoodWars.View
{
    /// <summary>
    /// ===================================================================
    /// Contoh user control standar untuk aplikasi ini.
    /// DISCLAIMER: Form ini hanya contoh, tidak boleh digunakan. 
    /// ===================================================================
    /// Data member, constructor, property dan event handler harus sama.
    /// Nanti bisa ada banyak event handler. Setiap event handler akan 
    /// menangani navigasi pada tampilan tertentu. Objek yang hanya 
    /// boleh dibuat untuk event handler adalah UserControl. Untuk event
    /// 'form_load' tidak boleh diisi!
    /// ===================================================================
    /// Note: Parameter dari class ini bisa GameService atau GameConfig.
    ///       Kalau tampilannya itu setting, maka GameConfig. Tapi, kalau 
    ///       game atau high score maka GameConfig.
    /// </summary>

    public partial class UserControl_std : UserControl
    {
        #region Data Members
        private BaseForm baseForm;
        #endregion

        #region Constructors
        public UserControl_std(BaseForm baseForm)
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
