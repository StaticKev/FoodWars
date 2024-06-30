using FoodWars.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodWars.View;
using FoodWars.Service;
using FoodWars.Utilities;

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
            Application.SetCompatibleTextRenderingDefault(false);

            PlayerRepo playerRepository = new PlayerRepo("Players.dat");
            GameService gameService = new GameService(playerRepository);
            BaseForm baseForm = new BaseForm(gameService, GameConfig.GetGameConfig());
            Application.Run(baseForm);

        }

    }
}
