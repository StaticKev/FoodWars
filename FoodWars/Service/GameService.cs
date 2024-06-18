using FoodWars.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FoodWars.Service
{
    internal class GameService
    {

        private PlayerRepo repo;

        public GameService(PlayerRepo repo)
        {
            this.repo = repo;
        }

        public void StartGame(int level)
        {
            
        }

    }
}
