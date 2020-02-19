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
            pitcher = new Pitcher();
            GetPlayerName();
        }

        // member methods (CAN DO)
        public void CreatePitcher()
        {
            Console.WriteLine("\n        We are making a pitcher");
            int ourLemons = inventory.lemons.Count;
            int recipeLemons = recipe.amountOfLemons;
            int ourSugar = inventory.sugarCubes.Count;
            int recipeSugar = recipe.amountOfSugarCubes;
            if ((recipeLemons <= ourLemons) && (recipeSugar <= ourSugar))
            {

                inventory.lemons.RemoveRange(0, recipeLemons);
                inventory.sugarCubes.RemoveRange(0, recipeSugar);
                pitcher.cupsLeftInPitcher = 11;
                //player.pitcher.cupsLeftInPitcher
                //player.inventory.iceCubes.RemoveRange(0, pitcherIce);
            }
            else
            {
                Console.WriteLine("You do not have enough supplies to create a pitcher");
                Console.WriteLine("SOLD OUT!");
                //Supplies are out end of day
            }

            
        }

        //SOLID Single Responsibility example. I isolated the single act of getting a player’s name in its own function..
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
