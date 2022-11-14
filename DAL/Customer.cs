using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Customer
    {
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public byte Age { get; set; }

        Hotel booked_hotel;

        public Customer(string First_name, string Last_name, byte Age) 
        {
            this.First_name = First_name;
            this.Last_name = Last_name;
            this.Age = Age;
        }



    }
}
