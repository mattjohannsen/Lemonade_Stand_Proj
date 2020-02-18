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
            GenerateCustomersForDay(GetNumberOfCustomers());
        }

        //member methods
        public void GenerateCustomersForDay(int totalCustomersToMake)
        {
            for (int i = 0; i < totalCustomersToMake; i++)
            {
                Customer newCustomer = new Customer(rnd);
                customers.Add(newCustomer);
            }
        }
        
        public int GetNumberOfCustomers()
        {
            Console.WriteLine($"Temperature: {weather.temperature} Condition: {weather.condition}");
            int result;
            int totalCustomersToMake;
            switch (weather.condition)
            {
                case "sunny":
                    result = rnd.Next(80, 100);
                    totalCustomersToMake = ((result*int.Parse(weather.temperature))/ 100);
                    return totalCustomersToMake;
                case "hazy":
                    result = rnd.Next(70, 90);
                    totalCustomersToMake = ((result * int.Parse(weather.temperature)) / 100);
                    return totalCustomersToMake;
                case "overcast":
                    result = rnd.Next(60, 80);
                    totalCustomersToMake = ((result * int.Parse(weather.temperature)) / 100);
                    return totalCustomersToMake;
                case "cloudy":
                    result = rnd.Next(50, 70);
                    totalCustomersToMake = ((result * int.Parse(weather.temperature)) / 100);
                    return totalCustomersToMake;
                case "rainy":
                    result = rnd.Next(50, 80);
                    totalCustomersToMake = ((result*int.Parse(weather.temperature))/ 100);
                    return totalCustomersToMake;
                default:
                    Console.WriteLine("Not a valid weather condition");
                    //I need help here to make a proper default case
                    totalCustomersToMake = 1;
                    return totalCustomersToMake;
            }
            //Console.WriteLine($"{totalCustomersToMake}");
        }


    }
}
