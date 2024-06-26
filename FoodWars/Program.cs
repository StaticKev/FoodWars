using FoodWars.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodWars
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            MainMenuForm formMenu = new MainMenuForm();
            PlayerRepo playerRepo = new PlayerRepo();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(formMenu);

        }


    }
}
