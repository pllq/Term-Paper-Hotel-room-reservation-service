using BLL.Logic;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLInput
{
    public class InputForSearch
    {
        public static void Search(ConsoleKey keyInfo)
        {
            Console.Clear();

            switch (keyInfo) 
            {
                //Case hotel:
                case ConsoleKey.D1:
                    string Name_of_Hotel;

                    Console.Write("Input name of the hotel: ");
                    Name_of_Hotel = Console.ReadLine().Trim();

                    while (string.IsNullOrEmpty(Name_of_Hotel))
                    {
                        Console.Clear();
                        Console.Write("Wrong input of hotel name, please try again: ");
                        Name_of_Hotel = Console.ReadLine();
                    }

                    if (HotelMethods.HotelWithSuchNameExists(Name_of_Hotel))
                    {
                        Console.Clear();
                        int index = HotelMethods.HotelIndexByName(Name_of_Hotel);
                        InputForHotel.ShowInfoAboutSpecificHotel(index);
                        Console.Write("Hotel was successfully found! To return to Main Menu press any key.");
                        Console.ReadKey();
                    }
                    else 
                    {
                        throw new Exception("Hotel wasn't found.");
                    }

                    break;

                //case customer:
                case ConsoleKey.D2:

                    string First_Name_of_the_Customer = CommonMethods.Initialize("first name", @"^[a-zA-Z]+$").ToLower();
                    First_Name_of_the_Customer = char.ToUpper(First_Name_of_the_Customer[0]) + First_Name_of_the_Customer.Substring(1);// to make first letter Upper case and others lower case

                    string Last_Name_of_the_Customer = CommonMethods.Initialize("last name", @"^[a-zA-Z]+$").ToLower();
                    Last_Name_of_the_Customer = char.ToUpper(Last_Name_of_the_Customer[0]) + Last_Name_of_the_Customer.Substring(1);

                    if (CustomerMethods.CustomerAlreadyCreated(First_Name_of_the_Customer, Last_Name_of_the_Customer))
                    {
                        Console.Clear();
                        int index = CustomerMethods.CustomerIndexByFirstAndLastName(First_Name_of_the_Customer, Last_Name_of_the_Customer);
                        InputForCustomer.ShowInfoAboutSpecificCustomer(index);

                        Console.Write("Customer was successfully found! To return to Main Menu press any key.");
                        Console.ReadKey();
                    }
                    else 
                    {
                        throw new Exception("Customer wasn't found.");
                    }
                    break;
            }
        }
    }
}
