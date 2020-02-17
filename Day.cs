using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        //member variables
        public Weather weather;
        public List<Customer> customers;
        Random rnd;

        //constructor
        public Day(Random rnd)
        {
            this.rnd = rnd;
            weather = new Weather(rnd);
            customers = new List<Customer>();
            //This is where I want to call the method to generate the correct number of customers
            GenerateCustomersForDay();
        }

        //member methods
        public void GenerateCustomersForDay()
        {
            Console.WriteLine($"Temperature: {weather.temperature} Condition: {weather.condition}");
            int result;
            int customerMultiplier;
            int totalCustomersToMake;
            switch (weather.condition)
            {
                case "sunny":
                    result = rnd.Next(80, 100);
                    customerMultiplier = 90;
                    totalCustomersToMake = ((result*customerMultiplier)/ 100);
                    Console.WriteLine($"Customers:{totalCustomersToMake}");
                    break;
                case "hazy":
                    result = rnd.Next(70, 90);
                    customerMultiplier = 98;
                    totalCustomersToMake = ((result * customerMultiplier) / 100);
                    Console.WriteLine($"Customers:{totalCustomersToMake}");
                    break;
                case "overcast":
                    result = rnd.Next(60, 80);
                    customerMultiplier = 80;
                    totalCustomersToMake = ((result * customerMultiplier) / 100);
                    Console.WriteLine($"Customers:{totalCustomersToMake}");
                    break;
                case "cloudy":
                    result = rnd.Next(50, 70);
                    customerMultiplier = 70;
                    totalCustomersToMake = ((result * customerMultiplier) / 100);
                    Console.WriteLine($"Customers:{totalCustomersToMake}");
                    break;
                case "rainy":
                    result = rnd.Next(50, 80);
                    customerMultiplier = 60;
                    totalCustomersToMake = ((result * customerMultiplier) / 100);
                    Console.WriteLine($"Customers:{totalCustomersToMake}");
                    break;
                default:
                    Console.WriteLine("Not a valid weather condition");
                    break;
            }
        }


    }
}
