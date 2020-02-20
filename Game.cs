﻿using System;
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
            foreach (Day day in days)
            {
                while (goSellLemonade == false)
                {
                    ShowPlayerStandStatus();
                }
                SellLemonade(rnd);
            }
            ShowWallet();
            Console.WriteLine("       GAME OVER");
            Console.ReadLine();
        }

        //member methods
        private void SellLemonade(Random rnd)
        {
            ShowForecast();
            player.CreatePitcher();
            int buyabilityFactor;
            buyabilityFactor = GetBuyabilityForCustomers(rnd);
            double chanceOfPurchase;
            chanceOfPurchase = GetCustomerChanceOfPurchase(buyabilityFactor);
            //This begins the loop that goes through the customers  
            foreach (Customer customer in days[currentDay].customers)
            {
                int buyrandom;
                CheckPitcherLevel();
                bool doWeHaveInventory;
                doWeHaveInventory = CheckInventoryLevels();
                buyrandom = rnd.Next(1, 100);
                if (buyrandom <= chanceOfPurchase) //This customer is on track to make a purchase
                {
                    if (doWeHaveInventory == true)
                    {
                        Console.WriteLine($"       SALE! {customer.name}: bought lemonade");
                        player.inventory.cups.RemoveRange(0, 1);
                        player.inventory.iceCubes.RemoveRange(0, player.recipe.amountOfIceCubes);
                        player.pitcher.cupsLeftInPitcher--;
                        player.wallet.Money += player.recipe.pricePerCup;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("        You do not have inventory to make sale!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine($"       {customer.name}: no sale");
                }
            }
            currentDay++;
            goSellLemonade = false;
        }
        private void CheckPitcherLevel()
        {
            if (player.pitcher.cupsLeftInPitcher == 0) //We need lemonade in the pitcher, let's go make it!
            {
                player.CreatePitcher();
            }
        }
        private bool CheckInventoryLevels()
        {
            int ourIce = player.inventory.iceCubes.Count;
            int cupIce = player.recipe.amountOfIceCubes;
            int ourCups = player.inventory.cups.Count;
            bool doWeHaveTheInventory;
            doWeHaveTheInventory = false;
            if (ourCups>=1)
            {
                if (ourIce >= cupIce)
                {
                    doWeHaveTheInventory = true;
                    return doWeHaveTheInventory;
                }
                else
                {
                    Console.WriteLine("       We do not have the ice to complete this sale.");
                    doWeHaveTheInventory = false;
                    return doWeHaveTheInventory;
                }
            }
            else
            {
                Console.WriteLine("       We do not have the cups to complete this sale.");
                doWeHaveTheInventory = false;
                return doWeHaveTheInventory;
            }
        }
        private double GetCustomerChanceOfPurchase(int buyabilityFactor)
        {
            double chanceOfPurchase;
            Console.WriteLine();
            Console.WriteLine($"       # of potential customers: {days[currentDay].customers.Count}");
            double recipeLikeability;
            recipeLikeability = player.recipe.recipeLikeability;
            return chanceOfPurchase = buyabilityFactor * recipeLikeability;
        }
        private int GetBuyabilityForCustomers(Random rnd)
        {
            int result;
            int buyabilityFactor;
            switch (days[currentDay].weather.condition)
            {
                case "sunny":
                    result = rnd.Next(90, 100);
                    return buyabilityFactor = ((result + int.Parse(days[currentDay].weather.temperature)) / 2);
                case "hazy":
                    result = rnd.Next(80, 90);
                    return buyabilityFactor = ((result + int.Parse(days[currentDay].weather.temperature)) / 2);
                case "overcast":
                    result = rnd.Next(70, 80);
                    return buyabilityFactor = ((result + int.Parse(days[currentDay].weather.temperature)) / 2);
                case "cloudy":
                    result = rnd.Next(60, 70);
                    return buyabilityFactor = ((result + int.Parse(days[currentDay].weather.temperature)) / 2);
                case "rainy":
                    result = rnd.Next(50, 80);
                    return buyabilityFactor = ((result + int.Parse(days[currentDay].weather.temperature)) / 2);
                default:
                    Console.WriteLine("Not a valid weather condition");
                    return buyabilityFactor = 1;
            }
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
                    Console.WriteLine("      That is not a valid selection. Please try again.");
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
            Console.WriteLine($"          Price per Cup: {player.recipe.pricePerCup}");
            Console.WriteLine($"            # of Lemons: {player.recipe.amountOfLemons}");
            Console.WriteLine($"       # of Sugar Cubes: {player.recipe.amountOfSugarCubes}");
            Console.WriteLine($"       # of Ice per Cup: {player.recipe.amountOfIceCubes}");
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
                    Console.WriteLine("       That is not a valid selection. Please try again.");
                    return SetNumberOfDays();
            }
        }

        private void CreateTheDays(int daysToCreate)
        {
            for (int i = 0; i < daysToCreate; i++)
            {
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
