using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Store
    {
        // member variables (HAS A)
        private double pricePerLemon;
        private double pricePerSugarCube;
        private double pricePerIceCube;
        private double pricePerCup;

        // constructor (SPAWNER)
        public Store()
        {
            pricePerLemon = .2;
            pricePerSugarCube = .1;
            pricePerIceCube = .01;
            pricePerCup = .25;
        }

        // member methods (CAN DO)
        public void BuyInventory(Player player)
        {
            Console.WriteLine();
            Console.WriteLine($"       What do you want to buy?");
            Console.WriteLine($"       (type cups, lemons, sugar or ice)?");
            Console.WriteLine($"       1)   'cups' | you have: {player.inventory.cups.Count}");
            Console.WriteLine($"       2) 'lemons' | you have: {player.inventory.lemons.Count}");
            Console.WriteLine($"       3)  'sugar' | you have: {player.inventory.sugarCubes.Count}");
            Console.Write($"       4)    'ice' | you have: {player.inventory.iceCubes.Count}" + "\n       ");

                string itemToBuy = Console.ReadLine();
                if(itemToBuy == "cups")
                    {
                        SellCups(player);
                    }
                else if (itemToBuy == "lemons")
                    {
                        SellLemons(player);
                    }
                else if (itemToBuy == "sugar")
                    {
                        SellSugarCubes(player);
                    }
                else if (itemToBuy == "ice")
                    {
                        SellIceCubes(player);
                    }
                else
                {
                Console.WriteLine("That is not a valid choice");
                BuyInventory(player);
                }
        }
        public void SellLemons(Player player)
        {
            int lemonsToPurchase = UserInterface.GetNumberOfItems("lemons");
            double transactionAmount = CalculateTransactionAmount(lemonsToPurchase, pricePerLemon);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddLemonsToInventory(lemonsToPurchase);
            }
        }

        public void SellSugarCubes(Player player)
        {
            int sugarToPurchase = UserInterface.GetNumberOfItems("sugar");
            double transactionAmount = CalculateTransactionAmount(sugarToPurchase, pricePerSugarCube);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddSugarCubesToInventory(sugarToPurchase);
            }
        }

        public void SellIceCubes(Player player)
        {
            int iceCubesToPurchase = UserInterface.GetNumberOfItems("ice cubes");
            double transactionAmount = CalculateTransactionAmount(iceCubesToPurchase, pricePerIceCube);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddIceCubesToInventory(iceCubesToPurchase);
            }
        }

        public void SellCups(Player player)
        {
            int cupsToPurchase = UserInterface.GetNumberOfItems("cups");
            double transactionAmount = CalculateTransactionAmount(cupsToPurchase, pricePerCup);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddCupsToInventory(cupsToPurchase);
            }
        }

        private double CalculateTransactionAmount(int itemCount, double itemPricePerUnit)
        {
            double transactionAmount = itemCount * itemPricePerUnit;
            return transactionAmount;
        }

        private void PerformTransaction(Wallet wallet, double transactionAmount)
        {
            wallet.PayMoneyForItems(transactionAmount);
        }
    }
}
