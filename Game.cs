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
        private Store store;
        Random rnd;
        bool goSellLemonade = false;
        bool continueGame = true;

        //constructor
        public Game()
        {
            rnd = new Random();
            days = new List<Day>();
            store = new Store();

        }
        public void RunGame()
        {
            ShowRules();
            int daysToCreate = int.Parse(SetNumberOfDays());
            CreateTheDays(daysToCreate);
            player = new Player();
            //This is where the loop will go adding 1 to previous day
            do
            {
                while (goSellLemonade == false)
                {
                    ShowPlayerStandStatus();
                }
                Console.WriteLine($"{continueGame}");
                //SellLemonade();
            }
            while (continueGame == true);
            //My next step is buying from my store, and editing my recipe.
            //This is where the loop will end adding 1 to previous day and ending when game is over.



        }


        //member methods
        private void SellLemonade()
        {
            Console.WriteLine("       You are selling lemondade!");
        }
        private void ShowPlayerStandStatus()
        {
            ShowForecast();
            ShowWallet();
            ShowInventory();
            ShowRecipe();
            GameMenu(SelectGameOptions());
        }
        private void GameMenu(string menuOption)
        {
            if (menuOption == "1")
            {
                //Console.WriteLine("Buy inventory");
                store.BuyInventory(player);
            }
            else if (menuOption == "2")
            {
                player.EditRecipe(player);
            }
        }
        private string SelectGameOptions()
        {
            Console.WriteLine();
            Console.WriteLine("       Select an option:");
            Console.WriteLine("       (1) Buy Inventory");
            Console.WriteLine("       (2) Edit Recipe");
            Console.Write("       (3) Sell Lemonade!" + "\n       ");
            string menuOption = Console.ReadLine();
            switch (menuOption)
            {
                case "1":
                case "2":
                    return menuOption;
                case "3":
                    goSellLemonade = true;
                    return menuOption;
                default:
                    Console.WriteLine("That is not a valid selection. Please try again.");
                    return SelectGameOptions();
            }

        }
        private void ShowForecast()
        {
            Console.WriteLine();
            Console.WriteLine($"       Day: {(currentDay + 1)} | {days[currentDay].weather.temperature} degrees and {days[currentDay].weather.condition}");
        }
        public void ShowRecipe()
        {
            Console.WriteLine();
            Console.WriteLine("       Your Current Recipe");
            Console.WriteLine($"            # of Lemons: {player.recipe.amountOfLemons}");
            Console.WriteLine($"       # of Sugar Cubes: {player.recipe.amountOfSugarCubes}");
            Console.WriteLine($"       # of Ice per Cup: {player.recipe.amountOfIceCubes}");
            Console.WriteLine($"          Price per Cup: {player.recipe.pricePerCup}");
        }
        
        public void ShowInventory()
        {
            Console.WriteLine();
            Console.WriteLine($"       {player.name}'s Inventory");
            Console.WriteLine($"       You have: {player.inventory.cups.Count} cups");
            Console.WriteLine($"       You have: {player.inventory.lemons.Count} lemons");
            Console.WriteLine($"       You have: {player.inventory.sugarCubes.Count} sugar cubes");
            Console.WriteLine($"       You have: {player.inventory.iceCubes.Count} ice cubes");
        }
        public void ShowWallet()
        {
            Console.WriteLine();
            Console.WriteLine($"       {player.name} has: ${player.wallet.Money}");
        }
        

        private string SetNumberOfDays()
        {
            Console.Write("       Are you playing for 7, 14 or 30 days?" + "\n       ");
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

        private void CreateTheDays(int daysToCreate)
        {
            Console.WriteLine($"Now we are going to create {daysToCreate} days...");
            //Here is where we create the Days.The number of Days we create is based on the number based to us above.
            for (int i = 0; i < daysToCreate; i++)
            {
                //Day newDay = new Day(rnd);
                days.Add(new Day(rnd));
            }
            currentDay = 0;
        }

        private void ShowRules()
        {
            Console.WriteLine();
            Console.WriteLine("       Lemonade Stand Game");
            //This is where the rules start
            //Console.WriteLine("You have 7, 14, or 30 days to make as much money as possible, and you’ve decided to open");
            //Console.WriteLine("a lemonade stand! You’ll have complete control over your business, including pricing, ");
            //Console.WriteLine("quality control, inventory control, and purchasing supplies. Buy your ingredients, set ");
            //Console.WriteLine("your recipe, and start selling!");
            //Console.WriteLine();
            //Console.WriteLine("The first thing you’ll have to worry about is your recipe. At first, go with the default");
            //Console.WriteLine("recipe, but try to experiment a little bit and see if you can find a better one. Make ");
            //Console.WriteLine("sure you buy enough of all your ingredients, or you won’t be able to sell!");
            //Console.WriteLine();
            //Console.WriteLine("You’ll also have to deal with the weather, which will play a big part when customers are");
            //Console.WriteLine("deciding whether or not to buy your lemonade. Read the weather report every day! When");
            //Console.WriteLine("the temperature drops, or the weather turns bad (overcast, cloudy, rain), don’t expect ");
            //Console.WriteLine("them to buy nearly as much as they would on a hot, hazy day, so buy accordingly. Feel");
            //Console.WriteLine("free to set your prices higher on those hot, muggy days too, as you’ll make more ");
            //Console.WriteLine("profit, even if you sell a bit less lemonade.");
            //Console.WriteLine();
            //Console.WriteLine("The other major factor which comes into play is your customer’s satisfaction. As you ");
            //Console.WriteLine("sell your lemonade, people will decide how much they like or dislike it.  This will make");
            //Console.WriteLine(" your business more or less popular. If your popularity is low, fewer people will want ");
            //Console.WriteLine("to buy your lemonade, even if the weather is hot and sunny. But if you’re popularity is ");
            //Console.WriteLine("high, you’ll do okay, even on a rainy day!");
            //This is the end of the rules


        }
    }
}
