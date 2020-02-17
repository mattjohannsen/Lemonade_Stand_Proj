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
        }

        //member methods


    }
}
