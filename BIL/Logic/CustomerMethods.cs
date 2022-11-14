using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL.Logic
{
    public class CustomerMethods
    {
        internal static List<Customer> CustomerList = new List<Customer>();
        internal static XMLSerialization<List<Customer>> xml_serialize_list_of_hotels = new XMLSerialization<List<Customer>>();
        internal static JSONSerialization<List<Customer>> json_serialize_list_of_hotels = new JSONSerialization<List<Customer>>();
        private static string name_of_file = "customer_list";


        public static bool CustomerDataFileExists()
        {
            if (File.Exists(name_of_file + ".xml"))
            {
                CustomerList = xml_serialize_list_of_hotels.Deserialize(name_of_file);
                return true;
            }
            if (File.Exists(name_of_file + ".json"))
            {
                CustomerList = json_serialize_list_of_hotels.Deserialize(name_of_file);
                return true;
            }

            return false;
        }

        public static void CreateCustomer(string First_Name_of_the_Customer, string Last_Name_of_the_Customer, int Age)
        {
            Customer Cusomter = new Customer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);

            CustomerList.Add(Cusomter);

            xml_serialize_list_of_hotels.Serialize(CustomerList, name_of_file);
            json_serialize_list_of_hotels.Serialize(CustomerList, name_of_file);
        }

        public static void RemoveCustomer(int index_of_hotel_to_remove)
        {
            CustomerList.RemoveAt(index_of_hotel_to_remove);

            xml_serialize_list_of_hotels.Serialize(CustomerList, name_of_file);

            json_serialize_list_of_hotels.Serialize(CustomerList, name_of_file);
        }



        public static string[] CustomersList()
        {
            string[] array_info_of_hotels = new string[CustomerList.Count];

            for (int i = 0; i < CustomerList.Count; i++)
            {
                array_info_of_hotels[i] =
                    $"{i + 1}. {CustomerList[i].First_name} {CustomerList[i].Last_name}\n";
            }
            return array_info_of_hotels;
        }


        public static string[] ViewWholeInfoOfCustomers()
        {
            string[] array_info_of_hotels = new string[CustomerList.Count];

            for (int i = 0; i < CustomerList.Count; i++)
            {
                array_info_of_hotels[i] =
                    $"{i + 1}. Customer: {CustomerList[i].First_name} {CustomerList[i].Last_name}\n" +
                    $"   Age: {CustomerList[i].Age}\n" +
                    $"   Have booked the room: {CustomerList[i].Have_Booked_the_Room}\n"/* +
                    $"   Number of Rooms: {CustomerList[i].Booked_Room}\n"*/;
            }
            return array_info_of_hotels;
        }





        public static int CustomerListLenght()
        {
            return CustomerList.Count;
        }




    }
}
