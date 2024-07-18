using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWars.Entity
{
    public class Achievement
    {
        #region DATA MEMBER
        private int requirement;
        private string name;
        private int rank;
        #endregion
        #region CONSTRUCTORS
        public Achievement(int category, int input)
        {
            CreateAchievement(category, input);
        }
        #endregion
        #region

        public int Requirement
        {
            get => requirement;
            private set
            {
                if (value == 0)
                {
                    throw new Exception("Achievement must have a requirement and can't be zero");
                }
                else
                {
                    requirement = value;
                }
            }

        }
        public string Name
        {
            get => name;
            set
            {
                if (value == "")
                {

                    throw new Exception("Achievement must have a name and can't be empty");

                }
                else
                {

                    name = value;

                }


            }
        }

        public int Rank
        {
            get => rank;
            set
            {
                if (value >= 0)
                {

                    rank = value;

                }
                else
                {
                    value = 0;
                }
            }
        }
        #endregion
        #region METHOD
        //INT CATEGORY !!!!
        //Level = 0; Total Income = 1; Total Successs Customer = 2;
        //Mwmbuat Achievement
        public void CreateAchievement(int category, int input)
        {

            int rank = RankAchievement(ListRequirement(category), input);
            if (rank != 0)
            {
                this.Rank = rank;
                this.Name = GenerateName(category);
                this.Requirement = ListRequirement(category)[this.Rank - 1];
            }
            else
            {
                //Achievement Not Generated
                return;
            }
        }
        //Untuk menentukan rank berapa di achievement tersebut
        private int RankAchievement(List<int> requirement, int input)
        {
            int result = 0;

            for (int i = 0; i < requirement.Count(); i++)
            {
                if (requirement[i] <= input)
                {
                    result++;
                }
            }
            return result;
        }



        private List<int> ListRequirement(int category)
        {
            List<int> requirement;
            if (category == 0)
            {
                requirement = new List<int>() { 10, 50, 100, 200, 300, 500, 750, 1_000 };
            }
            else if (category == 1)
            {
                requirement = new List<int>() { 10_000, 50_000, 100_000, 200_000, 300_000, 500_000, 750_000, 1_000_000 };
            }
            else
            {
                requirement = new List<int>() { 10, 50, 100, 200, 300, 500, 750, 1_000 };
            }
            return requirement;
        }

        private string GenerateName(int category)
        {
            string name = "";

            List<string> rankName = new List<string>() { "Wooden", "Stone", "Iron", "Bronze", "Silver", "Gold", "Platinum", "Diamond" };
            //GANTI INDEX
            name += rankName[(this.Rank - 1)] + " Rank ";

            if (category == 0)
            {
                name += " in Level";
            }
            else if (category == 1)
            {
                name += " in Total Income";
            }
            else
            {
                name += " in Customer Served";
            }
            return name;
        }

        #endregion
    }
}
