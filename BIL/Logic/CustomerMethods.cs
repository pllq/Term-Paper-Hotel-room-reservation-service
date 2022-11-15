using DAL;

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
            Customer Cusomter = new Customer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);

            CustomerList.Add(Cusomter);

            xml_serialize_list_of_customers.Serialize(CustomerList, Name_of_file);
            json_serialize_list_of_customers.Serialize(CustomerList, Name_of_file);
        }

        public static void RemoveCustomer(int index_of_hotel_to_remove)
        {
            CustomerList.RemoveAt(index_of_hotel_to_remove);

            xml_serialize_list_of_customers.Serialize(CustomerList, Name_of_file);

            json_serialize_list_of_customers.Serialize(CustomerList, Name_of_file);
        }


        public static void SortByFirstName(ConsoleKey consoleKey)
        {
            switch (consoleKey)
            {
                //Ascending order A-Z
                case ConsoleKey.A:
                    CustomerList.Sort(delegate (Customer first, Customer second)
                    {
                        return first.First_name.CompareTo(second.First_name);
                    });
                    return;

                //Descending order Z-A
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


        public static void ChangeCustomer(int index, string data_to_edit, string what_field_to_edit)
        {
            switch (what_field_to_edit) 
            {
                case "N":
                    string last_name = "";

                    for (int i = 0; i < data_to_edit.Length; i++) 
                    {
                        if(i != 0 && RegexPatternCheck.Pattern_of_the_Data_check(data_to_edit[i].ToString(), @"^[A-Z]$")) 
                        {
                            
                            last_name = data_to_edit.Substring(i, (data_to_edit.Length - i));
                            data_to_edit = data_to_edit.Substring(0, i);

                            CustomerList[index].First_name = data_to_edit;
                            CustomerList[index].Last_name = last_name;

                            //Probably add here Hotel.Rooms.Customer = CustomerList[index] or smt


                            xml_serialize_list_of_customers.Serialize(CustomerList, Name_of_file);
                            json_serialize_list_of_customers.Serialize(CustomerList, Name_of_file);
                            return;
                        }
                    }
                    break;

                case "F":
                    CustomerList[index].First_name = data_to_edit;
                    break;

                case "L":
                    CustomerList[index].Last_name = data_to_edit;
                    break;

                case "A":
                    CustomerList[index].Age = int.Parse(data_to_edit);
                    break;
            }
        }

        public static string SpecificCustomer(int index)
        {
            string data_of_specific_customer;

            data_of_specific_customer =
                    $"First name: {CustomerList[index].First_name}\n" +
                    $"Last name: {CustomerList[index].Last_name}\n" +
                    $"Age: {CustomerList[index].Age}\n" /*+
                    $"Have booked the room: {CustomerList[index].Have_Booked_the_Room}\n"*/;


            //HotelMethods.HotelList[i].Rooms[j].Customer_of_Room.First_name;

            /*
                        for (int i = 0; i < HotelMethods.HotelList.Count; i++)
                        {
                            for (int j = 0; j < HotelMethods.HotelList[i].Rooms.Count; j++)
                            {


                            }
                        }

                        if (CustomerList[index].Have_Booked_the_Room) 
                        {
                            data_of_specific_customer += $"Room number: {CustomerList[index].Booked_Room.Room_Number}\n";
                            data_of_specific_customer += $"Have booked the room: {CustomerList[index].Booked_Room.Room_Price_For_1_Day}\n";
                            data_of_specific_customer += $"Have booked the room: {CustomerList[index].Booked_Room.Is_Booked}\n";

                        }
            */
            return data_of_specific_customer;
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
