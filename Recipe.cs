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

        //constructor
        public Recipe()
        {
            amountOfLemons = 1;
            amountOfSugarCubes = 1;
            amountOfIceCubes = 1;
            pricePerCup = .25;
        }

        //member methods
        public void EditPricePerCup(Player player)
        {
            Console.WriteLine();
            Console.WriteLine("       You are editing the price/Cup");
            Console.WriteLine($"       The current price is {player.recipe.pricePerCup}");
            Console.Write("       What is the new price/Cup?" + "\n       ");
            string newPricePerCup;
            newPricePerCup = Console.ReadLine();
            player.recipe.pricePerCup = double.Parse(newPricePerCup);
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
        }


    }
}
