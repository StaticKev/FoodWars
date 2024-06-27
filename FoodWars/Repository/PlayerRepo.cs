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
        #region Data Members
        private string fileName = "Players.dat";
        List<Players> listPlayers = new List<Players>();
        #endregion

        #region Constructors
        public PlayerRepo(string fileName)
        {
            this.FileName = fileName;
            ReadFromFile();
        }
        #endregion

        #region Properties
        private string FileName
        {
            get => this.fileName;
            set
            {
                if (value == null || value == "") throw new ArgumentException("File name can't be empty!");
                else this.fileName = value;
            }
        }
        public List<Players> ListPlayers 
        {
            get
            {
                List<Players> getListPlayers = new List <Players>();
                foreach (Players p in this.ListPlayers)
                {
                    getListPlayers.Add(p);
                }
                return getListPlayers;
            }
            private set
            {
                if (value == null)throw new Exception("List can't be null");
                else listPlayers = value;
            }
        }
        #endregion

        #region Methods
        private void SaveToFile()
        {
            FileStream file = new FileStream(this.fileName, FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, this.ListPlayers);
            file.Close();
        }
        private void ReadFromFile()
        {
            if(File.Exists(this.fileName))
            {
                FileStream file = new FileStream(this.fileName, FileMode.Open, FileAccess.Read);
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

        public void UpdatePlayer(Players player)
        {
            if (!ListPlayers.Contains(player)) throw new ArgumentException("Player doesn't exist!");
            else
            {
                for (int i = 0; i < ListPlayers.Count; i++)
                {
                    if (player.Equals(ListPlayers[i]))
                    {
                        ListPlayers[i] = player;
                        this.SaveToFile();
                        break;
                    }
                }
            }
        }

        public void AddPlayer(Players player)
        {
            this.ListPlayers.Add(player);
            this.SaveToFile();
        }



        #endregion
    }
}
