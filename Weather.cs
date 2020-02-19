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
        Random rnd;



        //constructor
        public Weather(Random rnd)
        {
            this.rnd = rnd;
            weatherConditions = new List<string>() { "sunny", "hazy", "overcast", "cloudy", "rainy" };
            GenerateWeatherCondition();
            GenerateRandomTemperature();
        }
        

        //member methods

        public void GenerateWeatherCondition()
        {
            int result;
            //Below is an example of one of the SOLID principles. Instead of hardcoding the number 5 in the rnd.Next(0, 5) I used weatherConditions.Count so that in the future I can change the number of weather conditions without having to change the code.
            result = rnd.Next(0, weatherConditions.Count);
            switch (result)
            {
                case 0:
                    condition = "sunny";
                    //Console.WriteLine($"The weather will be: {condition}.");
                    break;
                case 1:
                    condition = "hazy";
                    //Console.WriteLine($"The weather will be: {condition}.");
                    break;
                case 2:
                    condition = "overcast";
                    //Console.WriteLine($"The weather will be: {condition}.");
                    break;
                case 3:
                    condition = "cloudy";
                    //Console.WriteLine($"The weather will be: {condition}.");
                    break;
                case 4:
                    condition = "rainy";
                    //Console.WriteLine($"The weather will be: {condition}.");
                    break;
                default:
                    Console.WriteLine("Not a valid weather condition");
                    break;
            }

        }
        public void GenerateRandomTemperature()
        {
            int result;
            switch (condition)
            {
                case "sunny":
                    result = rnd.Next(80, 100);
                    temperature = Convert.ToString(result);
                    Console.WriteLine($"       The temperature will be {temperature}:{condition}");
                    break;
                case "hazy":
                    result = rnd.Next(70, 90);
                    temperature = Convert.ToString(result);
                    Console.WriteLine($"       The temperature will be {temperature}:{condition}");
                    break;
                case "overcast":
                    result = rnd.Next(60, 80);
                    temperature = Convert.ToString(result);
                    Console.WriteLine($"       The temperature will be {temperature}:{condition}");
                    break;
                case "cloudy":
                    result = rnd.Next(50, 70);
                    temperature = Convert.ToString(result);
                    Console.WriteLine($"       The temperature will be {temperature}:{condition}");
                    break;
                case "rainy":
                    result = rnd.Next(50, 80);
                    temperature = Convert.ToString(result);
                    Console.WriteLine($"       The temperature will be {temperature}:{condition}");
                    break;
                default:
                    Console.WriteLine("       Not a valid weather condition");
                    break;
            }
        }


    }
}
