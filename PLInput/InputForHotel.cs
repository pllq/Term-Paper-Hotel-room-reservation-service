using BLL;
using BLL.Custom_exceptions;
using BLL.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PLInput
{
    public class InputForHotel
    {
        public static void IfHotelsListLenghtIsZero()
        {
            if (BLL.Logic.HotelMethods.HotelListLenght() == 0)
            {
                throw new HotelListIsEmptyExeption();
            }
        }


        public static void CreateHotel()
        {
            string Name_of_Hotel = "", Description_of_Hotel = "";
            int Hotel_Stars_Rate, Number_of_Rooms, Room_Number, Room_Price_For_1_Day;

            string string_Hotel_Stars_Rate, string_Number_of_Rooms, string_Room_Number, string_Room_Price_For_1_Day;

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
                throw new HotelWithSuchNameAlreadyExistsExeption();
            }

            Console.Clear();
            Console.Write("Write decsription of hotel: ");
            Description_of_Hotel = Console.ReadLine().Trim();
            while (string.IsNullOrEmpty(Description_of_Hotel))
            {
                Console.Clear();
                Console.Write("Wrong input of hotel desctiption, please try again: ");
                Name_of_Hotel = Console.ReadLine();
            }

            Console.Clear();
            string_Hotel_Stars_Rate = CommonMethods.Initialize("number of stars, that hotel has", @"^[1-5]$");
            Hotel_Stars_Rate = int.Parse(string_Hotel_Stars_Rate);

            Console.Clear();
            string_Number_of_Rooms = CommonMethods.Initialize("number of rooms in the hotel", @"^[1-9]$|^[1-9][0-9]+$");
            Number_of_Rooms = int.Parse(string_Number_of_Rooms);


            ArrayList List_of_arrays_for_Room_iniz = new ArrayList();
            int[] array_of_Room_Number = new int[Number_of_Rooms];
            int[] array_of_Room_Price_For_1_Day = new int[Number_of_Rooms];
            List<int> list_of_room_numbers = new List<int>();

            ConsoleKey keyInfo;
            for (int i = 0; i < Number_of_Rooms; i++)
            {
                Console.Clear();
                string_Room_Number = CommonMethods.Initialize("room number", @"^\d+$");
                Room_Number = int.Parse(string_Room_Number);
                while (list_of_room_numbers != null && list_of_room_numbers.Contains(Room_Number))
                {
                    Console.Clear();
                    Console.WriteLine("You have already created room with this number.");
                    string_Room_Number = CommonMethods.Initialize("another room number", @"^\d+$");
                    Room_Number = int.Parse(string_Room_Number);
                }
                list_of_room_numbers.Add(Room_Number);
                Console.WriteLine();

                Console.Clear();
                string_Room_Price_For_1_Day = CommonMethods.Initialize("room price for 1 day", @"^\d+$");
                Room_Price_For_1_Day = int.Parse(string_Room_Price_For_1_Day);
                Console.WriteLine();

                array_of_Room_Number[i] = Room_Number;
                array_of_Room_Price_For_1_Day[i] = Room_Price_For_1_Day;
            }

            List_of_arrays_for_Room_iniz.Add(array_of_Room_Number);
            List_of_arrays_for_Room_iniz.Add(array_of_Room_Price_For_1_Day);


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
                    "Do you want to create this hotel?\n" +
                    "Press \"Y\" key, to create hotel, or \"N\" key, to cancel the creation."
                );
            Console.WriteLine();

            keyInfo = CommonMethods.keyIninze();
            switch (keyInfo)
            {
                case ConsoleKey.Y:
                    break;

                case ConsoleKey.N:
                    return;

                default:
                    goto wrong_key;
            }
            Console.WriteLine();

            BLL.Logic.HotelMethods.CreateHotel(Name_of_Hotel, Description_of_Hotel, Hotel_Stars_Rate,
                                     Number_of_Rooms, List_of_arrays_for_Room_iniz);

            Console.Write("Hotel was successfully created! To return to Main Menu press any key.");
            Console.ReadKey();
        }

        public static void RemoveHotel()
        {
            IfHotelsListLenghtIsZero();

            ConsoleKey keyInfo;

            switch (BLL.Logic.HotelMethods.HotelListLenght())
            {
                case 1:
                    Console.Clear();

                    Console.WriteLine("There is only one created hotel.");
                    Console.WriteLine("Do you want to see the information about this hotel?");
                    Console.WriteLine("Press \"Y\" key, to see information about this single hotel, or any other to delete it without showing it.");

                    keyInfo = CommonMethods.keyIninze();

                    switch (keyInfo)
                    {
                        case ConsoleKey.Y:
                            keyInfo = ConsoleKey.D4;
                            Console.Clear();
                            ShowHotels(keyInfo);
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();

                            Console.WriteLine("Do you still want to delete this hotel?");
                            Console.WriteLine("Press \"Y\" key, to delete it, or press any other key to return to Main Menu without deleteing this hotel. ");

                            keyInfo = CommonMethods.keyIninze();
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

                    BLL.Logic.HotelMethods.RemoveHotel(0);

                    Console.Clear();
                    Console.WriteLine("Hotel was successfully deleted.");
                    Console.WriteLine("Press any key to return to Main Menu.");
                    Console.ReadKey();
                    break;


                case > 1:
                    Console.Clear();
                    ShowHotels(ConsoleKey.D4);

                    string user_input = CommonMethods.ForIndexIniz("index of hotel, you want to delete. " +
                                                    "If you don't want to remove anything, then write 'R' to return to Main Menu",
                                                    @"^[1-9]$|[1-9][0-9]+$|^R$|^r$");

                    switch (user_input)
                    {
                        case "R":
                        case "r":
                            return;

                        default:
                            int index_of_hotel_to_remove = int.Parse(user_input) - 1;

                            while (index_of_hotel_to_remove > BLL.Logic.HotelMethods.HotelListLenght())
                            {
                                string string_index_of_hotel_to_remove;
                                Console.WriteLine($"Index \"{index_of_hotel_to_remove}\" is greater then lenght of the list of hotels: {BLL.Logic.HotelMethods.HotelListLenght()}.");
                                string_index_of_hotel_to_remove = CommonMethods.ForIndexIniz($"write index as digit, strting from 1 to {BLL.Logic.HotelMethods.HotelListLenght()}",
                                    @"^[1-9]$|[1-9][0-9]+$");
                                index_of_hotel_to_remove = int.Parse(string_index_of_hotel_to_remove) - 1;
                            }

                            BLL.Logic.HotelMethods.RemoveHotel(index_of_hotel_to_remove);
                            Console.Clear();
                            Console.WriteLine("Hotel was successfully deleted.");
                            Console.WriteLine("Press any key to return to Main Menu.");
                            Console.ReadKey();
                            break;
                    }
                    break;
            }
        }

        public static void ShowHotels(ConsoleKey consoleKey)
        {
            IfHotelsListLenghtIsZero();

            string[] array_of_hotels_info = new string[1];
            switch (consoleKey)
            {
                case ConsoleKey.D3:
                    array_of_hotels_info = BLL.Logic.HotelMethods.ShowListOfCreatedHotels();
                    break;

                case ConsoleKey.D4:
                    array_of_hotels_info = BLL.Logic.HotelMethods.ShowHotelInfoWithoutRooms();
                    break;
            }
            Console.WriteLine("\tAll created hotels\n");

            for (int i = 0; i < array_of_hotels_info.Length; i++)
            {
                Console.Write(array_of_hotels_info[i]);
            }
        }



        public static void ShowInfoAboutSpecificHotel()
        {
            Console.Clear();

            ShowHotels(ConsoleKey.D3);
            Console.WriteLine();

            int index_of_hotel = CommonMethods.InputIndex("hotel", "whole information you want to see");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.Clear();

            ShowInfoAboutSpecificHotel(index_of_hotel);
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadKey();
        }
        internal static void ShowInfoAboutSpecificHotel(int index_of_hotel)
        {
            Console.WriteLine("\tChosen hotel\n");

            ArrayList array_of_specific_hotel = BLL.Logic.HotelMethods.ShowInfoAboutSpecificHotelWithRoomsInfo(index_of_hotel);

            int number_of_rooms_in_specific_hotel = BLL.Logic.HotelMethods.NumberOfRoomsInSpecificHotel(index_of_hotel);

            int[] array_of_Room_Number = (int[])array_of_specific_hotel[1];
            int[] array_of_Room_Price_For_1_Day = (int[])array_of_specific_hotel[2];
            string[] array_of_Is_Booked = (string[])array_of_specific_hotel[3];


            Console.WriteLine(array_of_specific_hotel[0]);

            for (int i = 0; i < number_of_rooms_in_specific_hotel; i++)
            {
                Console.WriteLine($"{i + 1}. Room #{array_of_Room_Number[i]}");
                Console.WriteLine($"   Rrice for 1 day: {array_of_Room_Price_For_1_Day[i]}");
                Console.WriteLine($"   Is room reserved: {array_of_Is_Booked[i]}");
            }
            Console.WriteLine();
        }
    }
}
