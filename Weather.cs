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
            result = rnd.Next(0, weatherConditions.Count);
            switch (result)
            {
                case 0:
                    condition = weatherConditions[0];
                    Console.WriteLine($"The weather will be: {condition}.");
                    break;
                case 1:
                    condition = weatherConditions[1];
                    Console.WriteLine($"The weather will be: {condition}.");
                    break;
                case 2:
                    condition = weatherConditions[2];
                    Console.WriteLine($"The weather will be: {condition}.");
                    break;
                case 3:
                    condition = weatherConditions[3];
                    Console.WriteLine($"The weather will be: {condition}.");
                    break;
                case 4:
                    condition = weatherConditions[4];
                    Console.WriteLine($"The weather will be: {condition}.");
                    break;
                default:
                    Console.WriteLine("Not a valid weather condition");
                    break;
            }

        }
        public void GenerateRandomTemperature()
        {
            int result;
            result = rnd.Next(50, 100);
            temperature = Convert.ToString(result);
            Console.WriteLine($"The temperature will be {temperature}");
        }


    }
}
