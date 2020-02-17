using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Game
    {
        //member variables
        private Player player;
        private List<Day> days;
        private int currentDay;

        //constructor
        public void RunGame()
        {
            ShowRules();
            int daysToCreate = int.Parse(SetNumberOfDays());
            Console.WriteLine(daysToCreate);
            //for (int i = 0; i < daysToCreate; i++)
            //{
            //    Day[i] = new Day(Weather);
            //}

        }


        //member methods
        private string SetNumberOfDays()
        {
            Console.WriteLine("Are you playing for 7, 14 or 30 days?");
            string numberOfDays = Console.ReadLine();
            switch (numberOfDays)
            {
                case "7":
                case "14":
                case "30":
                    return numberOfDays;
                default:
                    Console.WriteLine("That is not a valid selection. Please try again.");
                    return SetNumberOfDays();
            }

        }
        private void ShowRules()
        {
            Console.WriteLine("Lemonade Stand Game"); 
            Console.WriteLine("You have 7, 14, or 30 days to make as much money as possible, and you’ve decided to open");
            Console.WriteLine("a lemonade stand! You’ll have complete control over your business, including pricing, ");
            Console.WriteLine("quality control, inventory control, and purchasing supplies. Buy your ingredients, set ");
            Console.WriteLine("your recipe, and start selling!");
            Console.WriteLine();
            Console.WriteLine("The first thing you’ll have to worry about is your recipe. At first, go with the default");
            Console.WriteLine("recipe, but try to experiment a little bit and see if you can find a better one. Make ");
            Console.WriteLine("sure you buy enough of all your ingredients, or you won’t be able to sell!");
            Console.WriteLine();
            Console.WriteLine("You’ll also have to deal with the weather, which will play a big part when customers are");
            Console.WriteLine("deciding whether or not to buy your lemonade. Read the weather report every day! When");
            Console.WriteLine("the temperature drops, or the weather turns bad (overcast, cloudy, rain), don’t expect ");
            Console.WriteLine("them to buy nearly as much as they would on a hot, hazy day, so buy accordingly. Feel");
            Console.WriteLine("free to set your prices higher on those hot, muggy days too, as you’ll make more ");
            Console.WriteLine("profit, even if you sell a bit less lemonade.");
            Console.WriteLine();
            Console.WriteLine("The other major factor which comes into play is your customer’s satisfaction. As you ");
            Console.WriteLine("sell your lemonade, people will decide how much they like or dislike it.  This will make");
            Console.WriteLine(" your business more or less popular. If your popularity is low, fewer people will want ");
            Console.WriteLine("to buy your lemonade, even if the weather is hot and sunny. But if you’re popularity is ");
            Console.WriteLine("high, you’ll do okay, even on a rainy day!");
            //Console.WriteLine("At the end of 7, 14, or 21 days you’ll see how much money you made. Play again, and try ");
            //Console.WriteLine("to beat your high score!");


        }
    }
}
