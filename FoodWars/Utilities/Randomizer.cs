using System;

namespace FoodWars.Utilities
{
    public class Randomizer
    {
        static Random random;

        private Randomizer() { }

        static Randomizer()
        {
            random = new Random();
        }

        public static int Generate()
        {
            return random.Next();
        }

        public static int Generate(int amount)
        {
            if (amount <= 0) throw new ArgumentException("Parameter \'amount\' must be greater than 0!");

            return random.Next() % amount;
        }

        public static int Generate(int minValue, int maxValue)
        {
            if (minValue <= 0 || maxValue <= 0) throw new ArgumentException("Parameter \'minValue\' or \'maxValue\' must be greater than 0!");
            else if (minValue > maxValue) throw new ArgumentException("Parameter \'minValue\' can't exceed \'maxValue\'");

            int result = 0;

            while (result < minValue)
            {
                result = random.Next() % (maxValue + 1);
            }

            return result;
        }

    }
}
