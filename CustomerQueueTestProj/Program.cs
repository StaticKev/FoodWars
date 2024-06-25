using FoodWars;
using FoodWars.Entity;
using FoodWars.Repository;
using FoodWars.Service;
using FoodWars.Utilities;
using FoodWars.Values;

namespace CustomerQueueTestProj
{

    public static class Program
    {
        public static string OrdersToString(List<Items> orders)
        {
            string value = "";

            for (int i = 0; i < orders.Count; i++)
            {
                value += orders[i].Name;
                if (!(i == orders.Count - 1)) value += ", ";
            }

            if (orders.Count == 0) return "###";
            else return value;
        }

        public static void Main(String[] args)
        {
            GameService service = new GameService(new PlayerRepo());

            service.StartGame(100);
            CustomerQueue customerQueue = service.customerQueue;

            int level = 100;
            int testCase = 1;

            // Single level test
            for (int t = 1; t <= testCase; t++)
            {
                Console.WriteLine("Level: " + level);
                Console.WriteLine("Test case: " + t);
                Console.WriteLine("==============================================================================================================");
                int counter = 1;
                while (customerQueue.HasNext())
                {
                    Customers customer = customerQueue.DeQueue();
                    Console.WriteLine(
                        "C" + counter.ToString().PadLeft(2, '0') + " | " +
                        customer.Type.ToString() + "\t | " +
                        customer.GetType().ToString() + "\t | " +
                        OrdersToString(customer.Orders)
                        );
                    counter++;
                }
                Console.WriteLine("==============================================================================================================");
                Console.WriteLine("");
            }
        }
    }

}
