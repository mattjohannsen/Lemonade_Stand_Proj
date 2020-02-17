using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Customer
    {
        //member variables
        private List<string> names;
        public string name;
        Random rnd;

        //constructor
        public Customer(Random rnd)
        {
            this.rnd = rnd;
            names = new List<string>() { "Matt", "Chris", "Joe", "Mary", "Christine", "Jennifer", "Jeff", "Julie", "Mark", "Mike", "Bob", "Bill", "Paul", "Rachel", "Monica", "Chandler", "Ross", "Courtney", "Cory", "Brandon", "Casey", "Lindsay", "Melissa", "Tiffany", "Renae", "Jason", "Scott", "Reggie", "Creed", "Jim", "John", "Carol", "Pat", "Jordan", "Sue", "Don", "Linda", "Corbin", "Sarah", "Sam", "Marcus", "Violet", "Alex", "Jarrett", "Jared", "Heather", "Brianna", "Megan", "Jamie" };
            int result;
            result = rnd.Next(0, names.Count);
            //Console.WriteLine(names.Count + " " + rnd);
            //string name = "matt";
            string name = names[result];
            Console.WriteLine(name);
        }

        //member methods

}
}
