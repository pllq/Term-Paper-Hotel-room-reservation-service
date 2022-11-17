﻿using DAL;
using System;

namespace BIL.Logic
{
    public class CustomerMethods
    {
        internal static List<Customer> CustomerList = new List<Customer>();
        internal static XMLSerialization<List<Customer>> xml_serialize_list_of_customers = new XMLSerialization<List<Customer>>();
        internal static JSONSerialization<List<Customer>> json_serialize_list_of_customers = new JSONSerialization<List<Customer>>();
        internal const string Name_of_file = "customer_list";


        public static bool CustomerDataFileExists()
        {
            if (File.Exists(Name_of_file + ".xml"))
            {
                CustomerList = xml_serialize_list_of_customers.Deserialize(Name_of_file);
                return true;
            }
            if (File.Exists(Name_of_file + ".json"))
            {
                CustomerList = json_serialize_list_of_customers.Deserialize(Name_of_file);
                return true;
            }

            return false;
        }

        public static void CreateCustomer(string First_Name_of_the_Customer, string Last_Name_of_the_Customer, int Age)
        {
            //if exist == throw new?
            Customer Cusomter = new Customer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);

            CustomerList.Add(Cusomter);

            xml_serialize_list_of_customers.Serialize(CustomerList, Name_of_file);
            json_serialize_list_of_customers.Serialize(CustomerList, Name_of_file);
        }


        private static void IfCustomerHaveBookedTheRoom(int index_of_customer_to_remove)
        {
            int hotel_index = 0, room_index = 0;

            if (CustomerList[index_of_customer_to_remove].Have_Booked_the_Room)
            {
                for (int i = 0; i < HotelMethods.HotelList.Count; i++)
                {
                    for (int j = 0; j < HotelMethods.HotelList[i].Rooms.Count; j++)
                    {
                        if (HotelMethods.HotelList[i].Rooms[j].Customer_of_Room == CustomerList[index_of_customer_to_remove])
                        {
                            hotel_index = i;
                            room_index = j;
                            goto have_found;
                        }
                    }
                }

                have_found:

                HotelMethods.RoomIsNotBooked(hotel_index, room_index);

                HotelMethods.xml_serialize_list_of_hotels.Serialize(HotelMethods.HotelList, HotelMethods.Name_of_file);
                HotelMethods.json_serialize_list_of_hotels.Serialize(HotelMethods.HotelList, HotelMethods.Name_of_file);
            }
        }

        public static void RemoveCustomer(int index_of_customer_to_remove)
        {
            IfCustomerHaveBookedTheRoom(index_of_customer_to_remove);

            CustomerList.RemoveAt(index_of_customer_to_remove);

            xml_serialize_list_of_customers.Serialize(CustomerList, Name_of_file);
            json_serialize_list_of_customers.Serialize(CustomerList, Name_of_file);
        }



        public static void ChangeCustomer(int index_of_customer_to_remove, string data_to_edit, string what_field_to_edit)
        {
            IfCustomerHaveBookedTheRoom(index_of_customer_to_remove);

            switch (what_field_to_edit)
            {
                case "N":
                    string last_name = "";

                    for (int i = 0; i < data_to_edit.Length; i++)
                    {
                        if (i != 0 && RegexPatternCheck.Pattern_of_the_Data_check(data_to_edit[i].ToString(), @"^[A-Z]$"))
                        {

                            last_name = data_to_edit.Substring(i, (data_to_edit.Length - i));
                            data_to_edit = data_to_edit.Substring(0, i);

                            CustomerList[index_of_customer_to_remove].First_name = data_to_edit;
                            CustomerList[index_of_customer_to_remove].Last_name = last_name;

                            break;
                        }
                    }
                    break;

                case "F":
                    CustomerList[index_of_customer_to_remove].First_name = data_to_edit;
                    break;

                case "L":
                    CustomerList[index_of_customer_to_remove].Last_name = data_to_edit;
                    break;

                case "A":
                    CustomerList[index_of_customer_to_remove].Age = int.Parse(data_to_edit);
                    break;
            }

            xml_serialize_list_of_customers.Serialize(CustomerList, Name_of_file);
            json_serialize_list_of_customers.Serialize(CustomerList, Name_of_file);
        }


        public static void SortByFirstName(ConsoleKey consoleKey)
        {
            switch (consoleKey)
            {
                //Ascending order A-Y
                case ConsoleKey.A:
                    CustomerList.Sort(delegate (Customer first, Customer second)
                    {
                        return first.First_name.CompareTo(second.First_name);
                    });
                    return;

                //Descending order Y-A
                case ConsoleKey.D:
                    CustomerList.Sort(delegate (Customer first, Customer second)
                    {
                        return second.First_name.CompareTo(first.First_name);
                    });
                    return;
            }
        }

        public static void SortByLastName(ConsoleKey consoleKey)
        {
            switch (consoleKey)
            {
                //Ascending order A-Z
                case ConsoleKey.A:
                    CustomerList.Sort(delegate (Customer first, Customer second)
                    {
                        return first.Last_name.CompareTo(second.Last_name);
                    });
                    return;

                //Descending order Z-A
                case ConsoleKey.D:
                    CustomerList.Sort(delegate (Customer first, Customer second)
                    {
                        return second.Last_name.CompareTo(first.Last_name);
                    });
                    return;
            }
        }



        public static string SpecificCustomer(int index)
        {
            string data_of_specific_customer;

            data_of_specific_customer =
                    $"First name: {CustomerList[index].First_name}\n" +
                    $"Last name: {CustomerList[index].Last_name}\n" +
                    $"Age: {CustomerList[index].Age}\n" /*+
                    $"Have booked the room: {CustomerList[index_of_customer_to_remove].Have_Booked_the_Room}\n"*/;


            //HotelMethods.HotelList[i].Rooms[j].Customer_of_Room.First_name;

            /*
                        for (int i = 0; i < HotelMethods.HotelList.Count; i++)
                        {
                            for (int j = 0; j < HotelMethods.HotelList[i].Rooms.Count; j++)
                            {


                            }
                        }

                        if (CustomerList[index_of_customer_to_remove].Have_Booked_the_Room) 
                        {
                            data_of_specific_customer += $"Room number: {CustomerList[index_of_customer_to_remove].Booked_Room.Room_Number}\n";
                            data_of_specific_customer += $"Have booked the room: {CustomerList[index_of_customer_to_remove].Booked_Room.Room_Price_For_1_Day}\n";
                            data_of_specific_customer += $"Have booked the room: {CustomerList[index_of_customer_to_remove].Booked_Room.Is_Booked}\n";

                        }
            */
            return data_of_specific_customer;
        }

        /// <summary>
        /// This method returns array with the names of all created customers.
        /// <example>
        /// For example:
        /// <code>
        /// 1. Customer: *firstname lastname1*
        /// 2. Customer: *firstname lastname2*
        /// 3. Customer: *firstname lastname3*
        /// </code>
        /// </example>
        /// </summary>

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


        /// <summary>
        /// This method returns string array with information about all customers.
        /// <example>
        /// For example:
        /// <code>
        /// 1. Hotel name: *Hotel_name*
        /// 2. Description of the hotel: *Hotel_description*
        /// 3. Hotel stars rate: *Hotel_stars_rate*
        /// 4. Number of Rooms: *Hotel_number_rooms*
        /// 5. Number of free rooms: *Hotel_number_of_free_rooms*
        /// </code>
        /// </example>
        /// </summary>

        public static string[] ViewWholeInfoOfCustomers()
        {
            string[] array_info_of_hotels = new string[CustomerList.Count];

            for (int i = 0; i < CustomerList.Count; i++)
            {
                array_info_of_hotels[i] =
                    $"{i + 1}. Customer: {CustomerList[i].First_name} {CustomerList[i].Last_name}\n" +
                    $"   Age: {CustomerList[i].Age}\n" +
                    $"   Have booked the room: {CustomerList[i].Have_Booked_the_Room}\n" /*+
                    $"   Rooms number: {HotelList[i]}\n"*/;
            }
            return array_info_of_hotels;
        }

        public static bool CustomerAlreadyCreated(string first_name_to_check, string last_name_to_check)
        {
            for (int i = 0; i < CustomerList.Count; i++)
            {
                if (first_name_to_check.ToUpper() == CustomerList[i].First_name.ToUpper() &&
                    last_name_to_check.ToUpper() == CustomerList[i].Last_name.ToUpper())
                {
                    return true;
                }
            }

            return false;
        }



        public static int CustomerListLenght() => CustomerList.Count;



    }
}
