using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class Customer : ISerializable /*, IComparable, IComparable<Customer>*/
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

        public int CompareTo(object? obj)
        {
            Customer temp = obj as Customer;


            throw new NotImplementedException();
        }

        public Customer(SerializationInfo info, StreamingContext context)
        {
            First_name = info.GetString("First_name");
            Last_name = info.GetString("Last_name");
            Age = info.GetInt16("Age");

            //Booked_Room = info.GetInt16("Booked_Room");
        }

        public override bool Equals(object obj) => this.Equals(obj as Customer);

        public bool Equals(Customer customer)
        {
            if (customer is null)
            {
                return false;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != customer.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (First_name == customer.First_name) &&
                   (Last_name == customer.Last_name) &&
                   (Age == customer.Age) &&
                   (Have_Booked_the_Room == customer.Have_Booked_the_Room);
        }

        public static bool operator ==(Customer left_customer, Customer right_customer)
        {
            if (left_customer is null)
            {
                if (right_customer is null)
                {
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return left_customer.Equals(right_customer);
        }

        public static bool operator !=(Customer left_customer, Customer right_customer) => !(left_customer == right_customer);





    }
}
