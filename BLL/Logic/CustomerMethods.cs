using DAL;
using System;
using System.Collections.Generic;

namespace BLL.Logic
{
    public class CustomerMethods
    {
        public static List<Customer> CustomerList = new List<Customer>();
        internal static XMLSerialization<List<Customer>> xml_serialize_list_of_customers = new XMLSerialization<List<Customer>>();
        internal static JSONSerialization<List<Customer>> json_serialize_list_of_customers = new JSONSerialization<List<Customer>>();
        public const string Name_of_file = @"..\..\..\..\DAL\BD\customer_list";
        //public static string Name_of_file = @"G:\Studying\2) NAU (01.09.2021 - XX.06.2025)\NAU\Homeworks\Second grade\1st Semester\1) OOP\6) Term Paper\TP\DAL\BD\customer_list";
        //internal const string Name_of_file = "customer_list";

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

        public static void ChangeCustomer(int index_of_customer_to_change, string data_to_edit, string what_field_to_edit)
        {
            IfCustomerHaveBookedTheRoom(index_of_customer_to_change);

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

                            if (CustomerList[index_of_customer_to_change].First_name.ToUpper() == data_to_edit.ToUpper() &&
                                        CustomerList[index_of_customer_to_change].Last_name.ToUpper() == last_name.ToUpper())
                            {
                                throw new CustomerNewDataIsEqualToOld("first and last names are");
                            }

                            CustomerList[index_of_customer_to_change].First_name = data_to_edit;
                            CustomerList[index_of_customer_to_change].Last_name = last_name;

                            break;
                        }
                    }
                    break;

                case "F":
                    if (CustomerList[index_of_customer_to_change].First_name.ToUpper() == data_to_edit.ToUpper())
                    {
                        throw new CustomerNewDataIsEqualToOld("first name is");
                    }
                    CustomerList[index_of_customer_to_change].First_name = data_to_edit;
                    break;

                case "L":
                    if (CustomerList[index_of_customer_to_change].Last_name.ToUpper() == data_to_edit.ToUpper())
                    {
                        throw new CustomerNewDataIsEqualToOld("last name is");
                    }
                    CustomerList[index_of_customer_to_change].Last_name = data_to_edit;
                    break;

                case "A":
                    if (CustomerList[index_of_customer_to_change].Age == int.Parse(data_to_edit))
                    {
                        throw new CustomerNewDataIsEqualToOld("age is");
                    }

                    CustomerList[index_of_customer_to_change].Age = int.Parse(data_to_edit);
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
            string[] array_info_of_customers = new string[CustomerList.Count];

            for (int i = 0; i < CustomerList.Count; i++)
            {
                array_info_of_customers[i] =
                    $"{i + 1}. {CustomerList[i].First_name} {CustomerList[i].Last_name}\n";
            }
            return array_info_of_customers;
        }


        /// <summary>
        /// This method returns string with name, age and room reservation information of specific customers.
        /// <example>
        /// For example:
        /// <code>
        /// First name: *First_name*
        /// Last name: *Last_name*
        /// Age: *Age*
        /// Have reserved room: *Yes/No*
        /// </code>
        /// </example>
        /// </summary>
        public static string SpecificCustomer(int index)
        {
            string data_of_specific_customer;

            data_of_specific_customer =
                    $"First name: {CustomerList[index].First_name}\n" +
                    $"Last name: {CustomerList[index].Last_name}\n" +
                    $"Age: {CustomerList[index].Age}\n";

            switch (CustomerList[index].Have_Booked_the_Room)
            {
                case true:
                    data_of_specific_customer += $"Have reserved room: {YesOrNo(index)}\n";
                    break;

                case false:
                    return data_of_specific_customer;
            }

            return data_of_specific_customer;
        }
        internal static string YesOrNo(int index)
        {
            switch (CustomerList[index].Have_Booked_the_Room)
            {
                case true:
                    return "Yes";

                case false:
                    return "No";
            }
        }


        /// <summary>
        /// This method returns string array with information about all customers.
        /// <example>
        /// For example:
        /// <code>
        /// 1. Customer: *Customer_first_name_1* *Customer_last_name_1*
        ///    Age: *Age_1*
        ///    Have booked the room: *Yes/No*
        /// 2. Customer: *Customer_first_name_2* *Customer_last_name_2*
        ///    Age: *Age_2*
        ///    Have booked the room: *Yes/No*
        /// </code>
        /// </example>
        /// </summary>
        public static string[] ViewWholeInfoOfCustomers()
        {
            string[] array_info_of_customers = new string[CustomerList.Count];

            for (int i = 0; i < CustomerList.Count; i++)
            {
                array_info_of_customers[i] =
                    $"{i + 1}. Customer: {CustomerList[i].First_name} {CustomerList[i].Last_name}\n" +
                    $"   Age: {CustomerList[i].Age}\n" +
                    $"   Have booked the room: {YesOrNo(i)}\n";
            }
            return array_info_of_customers;
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

        public static int CustomerIndexByFirstAndLastName(string first_Name_of_the_Customer, string last_Name_of_the_Customer)
        {
            int customer_index = 0;
            for (int i = 0; i < CustomerList.Count; i++)
            {
                if (CustomerList[i].First_name.ToUpper() == first_Name_of_the_Customer.ToUpper() &&
                    CustomerList[i].Last_name.ToUpper() == last_Name_of_the_Customer.ToUpper())
                {
                    return customer_index = i;
                }
            }

            return -1;
        }


        public static void FileDelete() 
        {
            if (File.Exists(Name_of_file + ".xml"))
            {
                File.Delete(Name_of_file + ".xml");
            }

            if (File.Exists(Name_of_file + ".json")) 
            {
                File.Delete(Name_of_file + ".json");
                return;
            }
        }

        public static int CustomerListLenght() => CustomerList.Count;
    }
}