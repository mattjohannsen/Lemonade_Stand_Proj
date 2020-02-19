using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Player
    {
        // member variables (HAS A)
        public string name;
        public Inventory inventory;
        public Wallet wallet;
        public Recipe recipe;
        public Pitcher pitcher;

        // constructor (SPAWNER)
        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();
            recipe = new Recipe();
            GetPlayerName();
        }

        // member methods (CAN DO)
        public void CreatePitcher(Player player)
        {
            Console.WriteLine("\n        We are making a pitcher");
            int ourLemons = player.inventory.lemons.Count;
            int pitcherLemons = player.recipe.amountOfLemons;
            int ourSugar = player.inventory.sugarCubes.Count;
            int pitcherSugar = player.recipe.amountOfSugarCubes;
            int ourIce = player.inventory.iceCubes.Count;
            int pitcherIce = player.recipe.amountOfIceCubes;
            if ((pitcherLemons <= ourLemons) && (pitcherSugar <= ourSugar) && (pitcherIce <= ourIce))
            {
                Pitcher newPitcher = new Pitcher();
                player.inventory.lemons.RemoveRange(0, pitcherLemons);
                player.inventory.sugarCubes.RemoveRange(0, pitcherSugar);
                //player.pitcher.cupsLeftInPitcher
                //player.inventory.iceCubes.RemoveRange(0, pitcherIce);
            }
            else
            {
                Console.WriteLine("You do not have enough supplies to create a pitcher");
                //Supplies are out end of day
            }

            
        }

        private void GetPlayerName()
        {
            Console.WriteLine();
            Console.Write("       What is the player's name?" + "\n       ");
            name = Console.ReadLine();
        }

        public void EditRecipe(Player player)
        {
            Console.WriteLine();
            Console.WriteLine("       Which part of the recipe would you like to change?");
            Console.WriteLine($"       (1)     Price per Cup: {player.recipe.pricePerCup}");
            Console.WriteLine($"       (2)  Amount of lemons: {player.recipe.amountOfLemons}");
            Console.WriteLine($"       (3)   Amount of sugar: {player.recipe.amountOfSugarCubes}");
            Console.Write($"       (4) Ice cubes per cup: {player.recipe.amountOfIceCubes}" + "\n       ");
            string recipeItemToEdit = Console.ReadLine();
            if (recipeItemToEdit == "1")
            {
                player.recipe.EditPricePerCup(player);
            }
            else if (recipeItemToEdit == "2")
            {
                player.recipe.EditLemonsPerPitcher(player);
            }
            else if (recipeItemToEdit == "3")
            {
                player.recipe.EditSugarPerPitcher(player);
            }
            else if (recipeItemToEdit == "4")
            {
                player.recipe.EditIcePerCup(player);
            }
            else
            {
                Console.WriteLine("That is not a valid choice!");
                EditRecipe(player);
                //Need to ask about not putting return in front of this recursion.
            }
        }
    }
}
