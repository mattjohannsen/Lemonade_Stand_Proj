using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Weather
    {
        //member variables
        public string condition;
        public string temperature;
        private List<string> weatherConditions;



        //constructor
        public Weather()
        {
            weatherConditions = new List<string>() { "sunny", "hazy", "overcast", "cloudy", "rainy" };
            int result;
            Random rnd = new Random();
            result = rnd.Next(0,5);
            //This is where I want to start working.
            //EXAMPLE Console.WriteLine($"the temperature today is going to be{temperature} and it will be {condition} outside.");
            //switch (result)
            //{
            //    case "0":
            //        condition = weatherConditions[0];
            //        Console.WriteLine($"The weather will be: {condition}.");
            //    case "1":
            //        condition = weatherConditions[1];
            //        Console.WriteLine($"The weather will be: {condition}.");
            //    case "2":
            //        condition = weatherConditions[2];
            //        Console.WriteLine($"The weather will be: {condition}.");
            //    case "3":
            //        condition = weatherConditions[3];
            //        Console.WriteLine($"The weather will be: {condition}.");
            //    case "4":
            //        condition = weatherConditions[4];
            //        Console.WriteLine($"The weather will be: {condition}.");
            //    default:
            //        Console.WriteLine("Not a valid movie to watch");
            //        break;
            //}


                //Console.WriteLine($"the temperature today is going to be{temperature} and it will be {condition} outside.");
        }
        

        //member methods


    }
}
