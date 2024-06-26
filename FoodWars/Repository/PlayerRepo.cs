using FoodWars.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FoodWars.Repository
{
    [Serializable]
    public class PlayerRepo
    {
        List <Players> listPlayers = new List<Players> ();
        
        public PlayerRepo(string fileName)
        {
            ReadFromFile(fileName);
        }
        public PlayerRepo(PlayerRepo copyRepo)
        {
            this.ListPlayers = copyRepo.ListPlayers;
        }

        public List<Players> ListPlayers 
        {
            get
            {
                List <Players > getListPlayers = new List <Players> ();
                foreach (Players p in this.ListPlayers)
                {
                    getListPlayers.Add(p);
                }
                return getListPlayers;
            }
            private set
            {

                if (value == null)
                {

                    throw new Exception("List can't be null");

                }
                else
                {

                    listPlayers = value;

                }


            }
        }

        


        #region METHOD


        private void SaveToFile(string fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, this.ListPlayers);
            file.Close();
        }
        private void ReadFromFile(string fileName)
        {
            if(File.Exists(fileName))
            {
                FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                object result = (List<Players>)formatter.Deserialize(file);
                if (this.ListPlayers.GetType() == result.GetType())
                {

                    ListPlayers = (List<Players>)result;   

                }
                else
                {

                    throw new IOException("Incovertible read result");

                }
                file.Close();
            }
        }

        public void UpdatePlayer(Players updatePlayer)
        {
            

        }

        public void AddPlayer(Players addPlayer)
        {



        }



        #endregion
    }
}
