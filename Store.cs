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
            pricePerCup = .05;
        }

        // member methods (CAN DO)
        public void BuyInventory(Player player)
        {
            Console.WriteLine();
            Console.WriteLine($"       What do you want to buy?");
            Console.WriteLine($"       (type 1, 2, 3, 4)?");
            Console.WriteLine($"       1)   cups | you have: {player.inventory.cups.Count} | cost: {pricePerCup}");
            Console.WriteLine($"       2) lemons | you have: {player.inventory.lemons.Count} | cost: {pricePerLemon}");
            Console.WriteLine($"       3)  sugar | you have: {player.inventory.sugarCubes.Count} | cost: {pricePerSugarCube}");
            Console.Write($"       4)    ice | you have: {player.inventory.iceCubes.Count} | cost: {pricePerIceCube}" + "\n       ");

                string itemToBuy = Console.ReadLine();
                if(itemToBuy == "1")
                    {
                        SellCups(player);
                    }
                else if (itemToBuy == "2")
                    {
                        SellLemons(player);
                    }
                else if (itemToBuy == "3")
                    {
                        SellSugarCubes(player);
                    }
                else if (itemToBuy == "4")
                    {
                        SellIceCubes(player);
                    }
                else
                {
                Console.WriteLine("That is not a valid choice!");
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
