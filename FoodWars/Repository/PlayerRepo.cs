using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FoodWars.Repository
{
    [Serializable]
    public class PlayerRepo
    {
        #region Data Members
        private string fileName = "Players.dat";
        private List<Players> listPlayers;
        #endregion

        #region Constructors
        public PlayerRepo(string fileName)
        {
            this.FileName = fileName;
            listPlayers = new List<Players>();
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
            get => listPlayers;
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
            FileStream file = new FileStream(this.FileName, FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, this.ListPlayers);
            file.Close();
        }
        private void ReadFromFile()
        {
            if (File.Exists(this.FileName))
            {
                FileStream file = new FileStream(this.FileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                object result = formatter.Deserialize(file);
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
            else
            {
                SaveToFile();
            }
        }
        public void UpdatePlayer(Players player)
        {
            if (!ListPlayers.Contains(player)) throw new ArgumentException("Player doesn't exist!");
            else
            {
                for (int i = 0; i < ListPlayers.Count; i++)
                {
                    if (player.Name == ListPlayers[i].Name)
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
            bool isPresent = false;

            foreach(Players p in ListPlayers)
            {
                if (player.Name == p.Name) isPresent = true;
            }

            if (isPresent) throw new ArgumentException("Player already exist. Use a different name!");
            else
            {
                this.ListPlayers.Add(player);
                this.SaveToFile();
            }
        }
        #endregion
    }
}
