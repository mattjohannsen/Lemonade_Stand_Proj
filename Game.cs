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
            Console.WriteLine("Lemonade Stand Game");
            SetNumberOfDays();
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
    }
}
