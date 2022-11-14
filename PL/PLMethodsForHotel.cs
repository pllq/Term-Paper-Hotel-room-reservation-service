using BIL;
using BIL.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class PLMethodsForHotel
    {
        private static string InizCustomer(string first_or_last, string pattern)
        {
            Console.Write($"Input {first_or_last}: ");
            string last_and_first_name_input = Console.ReadLine();

            while (!RegexPatternCheck.Pattern_of_the_Data_check(last_and_first_name_input, pattern))
            {
                Console.Clear();
                Console.Write($"Wrong input of {first_or_last}. Please try again: ");
                last_and_first_name_input = Console.ReadLine();
            }
            return last_and_first_name_input;
        }



        public static void AddHotel() 
        {
            string Name_of_Hotel = "", Description_of_Hotel = "";
            int Hotel_Stars_Rate, Number_of_Rooms, Number_of_Free_Rooms = 0, Room_Number, Room_Price_For_1_Day;
            bool Is_Reserved;

            string string_Hotel_Stars_Rate, string_Number_of_Rooms, string_Room_Number, string_Room_Price_For_1_Day;

            Console.Write("Input Name of the hotel: ");
            Name_of_Hotel = Console.ReadLine();

            while (String.IsNullOrEmpty(Name_of_Hotel))
            {
                Console.Clear();
                Console.Write("Wrong input of hotel name, please try again: ");
                Name_of_Hotel = Console.ReadLine();
            }

            Console.Clear();
            Console.Write("Write decsription of hotel: ");
            Description_of_Hotel = Console.ReadLine();
            while (String.IsNullOrEmpty(Description_of_Hotel))
            {
                Console.Clear();
                Console.Write("Wrong input of hotel desctiption, please try again: ");
                Name_of_Hotel = Console.ReadLine();
            }

            //_____

            Console.Clear();
            string_Hotel_Stars_Rate = InizCustomer("number of stars, that hotel has", @"^[1-5]$");
            Hotel_Stars_Rate = int.Parse(string_Hotel_Stars_Rate);

            Console.Clear();
            Console.Write("Input number of rooms in the hotel: ");
            string_Number_of_Rooms = Console.ReadLine();
            while (!RegexPatternCheck.Pattern_of_the_Data_check(string_Number_of_Rooms, @"^\d+$"))
            {
                Console.Clear();
                Console.Write("Wrong input of hotel's room number.  Please try again: ");
                string_Number_of_Rooms = Console.ReadLine();
            }
            Number_of_Rooms = int.Parse(string_Number_of_Rooms);


            ArrayList List_of_arrays_for_Room_iniz = new ArrayList();
            int[] array_of_Room_Number = new int[Number_of_Rooms];
            int[] array_of_Room_Price_For_1_Day = new int[Number_of_Rooms];
            bool[] array_of_Is_Reserved = new bool[Number_of_Rooms];
            ConsoleKey keyInfo;

            for (int i = 0; i < Number_of_Rooms; i++) 
            {
                Console.Clear();
                Console.Write("Input room number: ");
                string_Room_Number = Console.ReadLine();
                while (!RegexPatternCheck.Pattern_of_the_Data_check(string_Room_Number, @"^\d+$"))
                {
                    Console.Clear();
                    Console.Write("Wrong input of room number. Please try again: ");
                    string_Room_Number = Console.ReadLine();
                }
                Room_Number = int.Parse(string_Room_Number);
                Console.WriteLine();

                Console.Clear();
                Console.Write("Input room price for 1 day: ");
                string_Room_Price_For_1_Day = Console.ReadLine();
                while (!RegexPatternCheck.Pattern_of_the_Data_check(string_Room_Price_For_1_Day, @"^\d+$"))
                {
                    Console.Clear();
                    Console.Write("Wrong input of room price for 1 day. Please try again: ");
                    string_Room_Price_For_1_Day = Console.ReadLine();
                }
                Room_Price_For_1_Day = int.Parse(string_Room_Price_For_1_Day);
                Console.WriteLine();

/*              
                wrong_YorN_key:
                Console.Clear();
                Console.Write("Is room reserved? Press \"Y\" key, to create hotel, or \"N\" key, to cancel the creation: ");
                keyInfo = Menu.keyIninze();

                switch (keyInfo)
                {
                    case ConsoleKey.Y:
                        Have_Booked_the_Room = true;
                        break;

                    case ConsoleKey.N:
                        Have_Booked_the_Room = false;
                        Number_of_Free_Rooms++;
                        break;

                    default:
                        goto wrong_YorN_key;
                }
*/
                array_of_Room_Number[i] = Room_Number;
                array_of_Room_Price_For_1_Day[i]= Room_Price_For_1_Day;
                //array_of_Is_Reserved[i]= Have_Booked_the_Room;
            }

            List_of_arrays_for_Room_iniz.Add(array_of_Room_Number);
            List_of_arrays_for_Room_iniz.Add(array_of_Room_Price_For_1_Day);
            //List_of_arrays_for_Room_iniz.Add(array_of_Is_Reserved);

        
        wrong_key:
            Console.Clear();
            Console.WriteLine
                (
                    $"Information about {Name_of_Hotel} hotel:\n\n" +
                    $"Name: {Name_of_Hotel}.\n" +
                    $"Description of the hotel: {Description_of_Hotel}.\n" +
                    $"Number of stars: {Hotel_Stars_Rate}.\n" +
                    $"Number of rooms in the hotel: {Number_of_Rooms}.\n"
                );

            Console.WriteLine
                (
                    "Do you want to create this hotel?\n"+
                    "Press \"Y\" key, to create hotel, or \"N\" key, to cancel the creation."
                );
            Console.WriteLine();

            keyInfo = Menu.keyIninze();
            switch (keyInfo)
            {
                case ConsoleKey.Y:
                    break;

                case ConsoleKey.N:
                    return;

                default:
                    goto wrong_key;
            }

            HotelMethods.CreateHotel(Name_of_Hotel, Description_of_Hotel, Hotel_Stars_Rate,
                                     Number_of_Rooms, List_of_arrays_for_Room_iniz);

            Console.Write("Hotel was successfully created! To return to Main menu press any key.");
            Console.ReadKey();
        }

        public static void RemoveHotel() 
        {
            string Name_of_Hotel = "";
            ConsoleKey keyInfo;

            switch (HotelMethods.HotelListLenght()) 
            {
                case 0:
                    if (HotelMethods.HotelListLenght() == 0)
                    {
                        throw new HotelListIsEmptyExeption($"List of hotels is equal to {HotelMethods.HotelListLenght()}.");
                    }

                    /*
                                        Console.WriteLine("You haven't added any hotel. Do you want to create one?");
                                        Console.Write("Press \"Y\" key, to create hotel, or press any other key, to cancel the creation and continue to Main menu.");
                                        ConsoleKey keyInfo = Menu.keyIninze();

                                        switch (keyInfo)
                                        {
                                            case ConsoleKey.Y:
                                                AddCustomer();
                                                break;

                                            default:
                                                return;
                                        }
                    */
                    break;


                case 1:
                    Console.Clear();

                    Console.WriteLine("There is only one created hotel.");
                    Console.WriteLine("Do you want to see the information about this hotel?");
                    Console.WriteLine("Press \"Y\" key, to see information about this single hotel, or any other to delete it without showing it.");

                    keyInfo = Menu.keyIninze();

                    switch (keyInfo)
                    {
                        case ConsoleKey.Y:
                            keyInfo = ConsoleKey.D4;
                            Console.Clear();
                            ShowHotels(keyInfo);

                            Console.WriteLine("Do you still want to delete this hotel?");
                            Console.WriteLine("Press \"Y\" key, to delete it, or press any other key to return to Main menu without deleteing this hotel. ");

                            keyInfo = Menu.keyIninze();
                            switch (keyInfo)
                            {
                                case ConsoleKey.Y:
                                    break;

                                default:
                                    return;
                            }
                            break;

                        default:
                            break;
                    }

                    HotelMethods.RemoveHotel(0);

                    Console.Clear();
                    Console.WriteLine("Hotel was successfully deleted.");
                    Console.WriteLine("Press any key to returen to Main menu.");
                    Console.ReadKey();

                    break;

                case > 1:
                casegreaterthen1:
                    Console.Clear();
                    Console.WriteLine("Do you want to see the information about hotels?");
                    Console.WriteLine("Press \"Y\" key, to see information about all hotels, or any other Key, to delete without showing.");

                    keyInfo = Menu.keyIninze();

                    switch (keyInfo)
                    {
                        case ConsoleKey.Y:
                            keyInfo = ConsoleKey.D4;
                            Console.Clear();
                            ShowHotels(keyInfo);

                            break;

                        case ConsoleKey.N:
                            break;

                        default:
                            goto casegreaterthen1;
                    }
                    

                    //Console.Clear();
                    Console.WriteLine("NOTICE: index starts from 1 !");
                    Console.Write("Input index of hotel, you want to delete. If you don't want to remove anything, then write 'R' to return to Main menu: ");

                    string user_input = Console.ReadLine();
                    while (!RegexPatternCheck.Pattern_of_the_Data_check(user_input, @"^[1-9]$|[1-9][0-9]+$|^R$|^r$") )
                    {
                        Console.Clear();
                        Console.WriteLine("NOTICE: index starts from 1 !");
                        Console.Write("Wrong input. Please write index as digit, strting from 1, or 'R' to return to Main menu: ");
                        user_input = Console.ReadLine();
                    }

                    switch (user_input)
                    {
                        case "R":
                        case "r":
                            return;

                        default:
                            int index_of_hotel_to_remove = int.Parse(user_input) - 1;
                                      
                            while (index_of_hotel_to_remove > HotelMethods.HotelListLenght())
                            {
                                string string_index_of_hotel_to_remove;
                                Console.WriteLine($"Index \"{index_of_hotel_to_remove}\" is greater then lenght of the list of hotels: {HotelMethods.HotelListLenght()}.");
                                Console.WriteLine("NOTICE: index starts from 1 !");
                                Console.Write($"Wrong input. Please write index as digit, strting from 1 to {HotelMethods.HotelListLenght()}: ");
                                string_index_of_hotel_to_remove = Console.ReadLine();

                                while (!RegexPatternCheck.Pattern_of_the_Data_check(string_index_of_hotel_to_remove, @"^[1-9]$|[1-9][0-9]+$")) 
                                {
                                    Console.WriteLine($"Index \"{index_of_hotel_to_remove}\" is greater then lenght of the list of hotels: {HotelMethods.HotelListLenght()}.");
                                    Console.WriteLine("NOTICE: index starts from 1 !");
                                    Console.Write($"Wrong input. Please write index as digit, strting from 1 to {HotelMethods.HotelListLenght()}: ");
                                    string_index_of_hotel_to_remove = Console.ReadLine();
                                }

                                index_of_hotel_to_remove = int.Parse(string_index_of_hotel_to_remove) - 1;
                            }

                            HotelMethods.RemoveHotel(index_of_hotel_to_remove);
                            break;
                    }
                    break;
            }
        }


        public static void ShowHotels(ConsoleKey consoleKey) 
        {
            if (HotelMethods.HotelListLenght() == 0)
            {
                throw new HotelListIsEmptyExeption($"List of hotels is equal to {HotelMethods.HotelListLenght()}.");
            }


            string[] array_of_hotels_info = new string[1];
            switch(consoleKey)
            {
                case ConsoleKey.D3:
                    array_of_hotels_info = HotelMethods.HotelsList();
                    break;

                case ConsoleKey.D4:
                    array_of_hotels_info = HotelMethods.ViewWholeInfoOfHotels();
                    break;
            }
            Console.WriteLine("All created hotels:");

            for (int i = 0; i < array_of_hotels_info.Length; i++)
            {
                Console.Write(array_of_hotels_info[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Press any key to returen to Main menu.");
            Console.ReadKey();
        }



    }
}
