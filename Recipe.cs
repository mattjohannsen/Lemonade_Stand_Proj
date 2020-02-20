using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Recipe
    {
        //member variables
        public int amountOfLemons;
        public int amountOfSugarCubes;
        public int amountOfIceCubes;
        public double pricePerCup;
        public double recipeLikeability;

        //constructor
        public Recipe()
        {
            amountOfLemons = 1;
            amountOfSugarCubes = 1;
            amountOfIceCubes = 1;
            pricePerCup = .25;
        }

        //member methods
        public double CalculateLikeability(Player player)
        {
            double likeabilityFactor;
            double priceLikeability = CalculatePriceLikeability(player);
            double lemonLikeability = CalculateLemonLikeability(player);
            double sugarLikeability = CalculateSugarLikeability(player);
            double iceLikeability = CalculateIceLikeability(player);
            return likeabilityFactor = (priceLikeability + lemonLikeability + sugarLikeability + iceLikeability);
        }
        private double CalculateIceLikeability(Player player)
        {
            double iceLikeability;
            if ((player.recipe.amountOfIceCubes >= 3) && (player.recipe.amountOfIceCubes <= 9))
            {
                iceLikeability = (player.recipe.amountOfIceCubes / 9);
                return iceLikeability = (iceLikeability * .25);
            }
            else
            {
                return iceLikeability = .05;
            }
        }
        private double CalculateSugarLikeability(Player player)
        {
            double sugarLikeability;
            if ((player.recipe.amountOfSugarCubes >= 3) && (player.recipe.amountOfSugarCubes <= 10))
            {
                sugarLikeability = (player.recipe.amountOfSugarCubes / 10);
                return sugarLikeability = (sugarLikeability * .25);
            }
            else
            {
                return sugarLikeability = .05;
            }
        }
        private double CalculateLemonLikeability(Player player)
        {
            double lemonLikeability;
            if ((player.recipe.amountOfLemons >= 2) && (player.recipe.amountOfLemons <= 7))
            {
                lemonLikeability = (player.recipe.amountOfLemons / 7);
                return lemonLikeability = (lemonLikeability * .25);
            }
            else
            {
                return lemonLikeability = .05;
            }
        }
        private double CalculatePriceLikeability(Player player)
        {
            double priceLikeability;
            if (player.recipe.pricePerCup <= .8)
            {
                priceLikeability = (1 - player.recipe.pricePerCup);
                return priceLikeability = (priceLikeability * .25);
            }
            else
            {
                return priceLikeability = .05;
            }
        }
        public void EditPricePerCup(Player player)
        {
            Console.WriteLine();
            Console.WriteLine("       You are editing the price/Cup");
            Console.WriteLine($"       The current price is {player.recipe.pricePerCup}");
            Console.Write("       What is the new price/Cup?" + "\n       ");
            string newPricePerCup;
            newPricePerCup = Console.ReadLine();
            player.recipe.pricePerCup = double.Parse(newPricePerCup);
            player.recipe.recipeLikeability = CalculateLikeability(player);
        }
        public void EditLemonsPerPitcher(Player player)
        {
            Console.WriteLine();
            Console.WriteLine("       You are editing the lemons/Pitcher");
            Console.WriteLine($"       Currently there are {player.recipe.amountOfLemons}/Pitcher");
            Console.Write("       How many lemons/Pitcher?" + "\n       ");
            string newLemonsPerPitcher;
            newLemonsPerPitcher = Console.ReadLine();
            player.recipe.amountOfLemons = int.Parse(newLemonsPerPitcher);
            player.recipe.recipeLikeability = CalculateLikeability(player);
        }
        public void EditSugarPerPitcher(Player player)
        {
            Console.WriteLine();
            Console.WriteLine("       You are editing the sugar/Pitcher");
            Console.WriteLine($"       Currently there are {player.recipe.amountOfSugarCubes}/Pitcher");
            Console.Write("       How much sugar/Pitcher?" + "\n       ");
            string newSugarPerPitcher;
            newSugarPerPitcher = Console.ReadLine();
            player.recipe.amountOfSugarCubes = int.Parse(newSugarPerPitcher);
            player.recipe.recipeLikeability = CalculateLikeability(player);
        }
        public void EditIcePerCup(Player player)
        {
            Console.WriteLine();
            Console.WriteLine("       You are editing the ice/Cup");
            Console.WriteLine($"       There are currently {player.recipe.amountOfIceCubes} ice cubes/Cup");
            Console.Write("       How many ice cubes per cup?" + "\n       ");
            string newIcePerCup;
            newIcePerCup = Console.ReadLine();
            player.recipe.amountOfIceCubes = int.Parse(newIcePerCup);
            player.recipe.recipeLikeability = CalculateLikeability(player);
        }
    }
}
