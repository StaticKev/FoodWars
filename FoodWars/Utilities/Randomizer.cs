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

        public static int Generate(int maxValue)
        {
            return random.Next() % maxValue + 1;
        }

        public static int Generate(int minValue, int maxValue)
        {
            int result = 0;

            while (result < minValue)
            {
                result = random.Next() % maxValue + 1;
            }

            return result;
        }

    }
}
