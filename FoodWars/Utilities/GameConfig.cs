using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace FoodWars.Utilities
{
    [Serializable]
    public class GameConfig
    {
        #region Data Members 
        private bool bgmOn;
        private bool sfxOn;
        private string fileName;
        #endregion

        #region Constructors 
        public GameConfig(bool isComparator)
        {
            if (!isComparator)
            {
                this.BgmOn = true;
                this.SfxOn = true;
                this.fileName = "GameConfig.dat";
                this.UpdateGameConfig();
            }
        }
        #endregion

        #region Properties
        public bool BgmOn { get => bgmOn; set => bgmOn = value; }
        public bool SfxOn { get => sfxOn; set => sfxOn = value; }
        #endregion

        #region Methods
        public void UpdateBgmStatus(bool status)
        {
            this.BgmOn = status;
            this.UpdateGameConfig();
        }

        public void UpdateSfxStatus(bool status)
        {
            this.SfxOn = status;
            this.UpdateGameConfig();
        }

        private void UpdateGameConfig()
        {
            FileStream fileStream = new FileStream(this.fileName, FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, this);
            fileStream.Close();
        }

        public static GameConfig GetGameConfig()
        {
            string fileName = "GameConfig.dat";
            GameConfig config;

            Console.WriteLine("File is exist: " + File.Exists(fileName));

            if (File.Exists(fileName))
            {
                FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                object result = formatter.Deserialize(file);
                GameConfig comparator = new GameConfig(true);

                Console.WriteLine("Result is equal: " + (result.GetType() == comparator.GetType()));

                if (result.GetType() == comparator.GetType())
                {
                    config = (GameConfig)result;
                    Console.WriteLine("========== Found a GameConfig file! ==========");
                }
                else
                {
                    Console.WriteLine("========== File type doesn't match GameConfig ==========");
                    throw new IOException("Incovertible read result");
                }
                file.Close();
            }
            else
            {
                config = new GameConfig(false);
            }

            return config;
        }
        #endregion 
    }
}
