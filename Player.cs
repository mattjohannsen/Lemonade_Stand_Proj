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
        public void GetPlayerName()
        {
            Console.WriteLine();
            Console.Write("       What is the player's name?" + "\n       ");
            name = Console.ReadLine();
            //name = Console.Readline();
        }
    }
}
