using BIL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class PLMethodsForHotel
    {
        private const int Stars = 5;

        public static void AddHotel() 
        {
            string Name_of_Hotel, Description_of_Hotel;
            int Hotel_Stars_Rate, Number_of_Rooms, Number_of_Free_Rooms = 0, Room_Number, Room_Price_For_1_Day;
            bool Is_Reserved;

            string string_Hotel_Stars_Rate, string_Number_of_Rooms, string_Room_Number, string_Room_Price_For_1_Day;

            Console.Write("Input Name of the hotel: ");
            Name_of_Hotel = Console.ReadLine();
/*
            while(!RegexPatternCheck.Pattern_of_the_Data_check(Name_of_Hotel, Globals.NAME_PATTERN)) 
            {
                Console.Clear();
                Console.Write("Wrong input, please try again: ");
                Name_of_Hotel = Console.ReadLine();
            }
*/
            Console.Clear();
            Console.Write("Write decsription of hotel: ");
            Description_of_Hotel = Console.ReadLine();

            Console.Clear();
            Console.Write("Input number of stars, that hotel has: ");

            string_Hotel_Stars_Rate = Console.ReadLine();
            while (!RegexPatternCheck.Pattern_of_the_Data_check(string_Hotel_Stars_Rate, @"^[1-5]$"))
            {
                Console.Clear();
                Console.Write("Wrong input of hotel's stars number. Please try again: ");
                string_Hotel_Stars_Rate = Console.ReadLine();
            }
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

                wrong_YorN_key:
                Console.Clear();
                Console.Write("Is room reserved? Press \"Y\" key, to create hotel, or \"N\" key, to cancel the creation: ");
                keyInfo = Menu.keyIninze();

                switch (keyInfo)
                {
                    case ConsoleKey.Y:
                        Is_Reserved = true;
                        break;

                    case ConsoleKey.N:
                        Is_Reserved = false;
                        Number_of_Free_Rooms++;
                        break;

                    default:
                        goto wrong_YorN_key;
                }
                array_of_Room_Number[i] = Room_Number;
                array_of_Room_Price_For_1_Day[i]= Room_Price_For_1_Day;
                array_of_Is_Reserved[i]= Is_Reserved;
            }

            List_of_arrays_for_Room_iniz.Add(array_of_Room_Number);
            List_of_arrays_for_Room_iniz.Add(array_of_Room_Price_For_1_Day);
            List_of_arrays_for_Room_iniz.Add(array_of_Is_Reserved);

        
        wrong_key:
            Console.Clear();
            Console.WriteLine
                (
                    $"Information about {Name_of_Hotel} hotel:\n\n" +
                    $"Name: {Name_of_Hotel}.\n" +
                    $"Description of the hotel: {Description_of_Hotel}.\n" +
                    $"Number of stars: {Hotel_Stars_Rate}.\n" +
                    $"Number of rooms in the hotel: {Number_of_Rooms}.\n" +
                    $"Number of free rooms in the hotel: {Number_of_Free_Rooms}.\n"
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

            HotelMethods.HotelCreate(Name_of_Hotel, Description_of_Hotel, Hotel_Stars_Rate,
                                     Number_of_Rooms, Number_of_Free_Rooms, List_of_arrays_for_Room_iniz);

            Console.Write("Hotel was successfully created! To return to Main menu press any key.");
            Console.ReadKey();
        }
    }
}
