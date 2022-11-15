using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class Customer : ISerializable/*, IComparable, IComparable<Customer>*/
    {
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public int Age { get; set; }
        public bool Have_Booked_the_Room { get; set; } = false;

        //to delete:
        //public Room Booked_Room;


        public Customer(){}

        public Customer(string First_name, string Last_name, int Age) 
        {
            this.First_name = First_name;
            this.Last_name = Last_name;
            this.Age = Age;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("First_name", First_name);
            info.AddValue("Last_name", Last_name);
            info.AddValue("Age", Age);
            //info.AddValue("Booked_Room", Booked_Room);

        }

        public Customer(SerializationInfo info, StreamingContext context)
        {
            First_name = info.GetString("First_name");
            Last_name = info.GetString("Last_name");
            Age = info.GetInt16("Age");

            //Booked_Room = info.GetInt16("Booked_Room");
        }
    }
}
