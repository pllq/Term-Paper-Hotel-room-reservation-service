using BaseLibS.Graph;
using BIL.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PLInput
{
    public class InputForRoom
    {
        private static void CheckIfListOfHotelsAndCustomersAreNotEmpty()
        {
            InputForHotel.IfHotelsListLenghtIsZero();
            InputForCustomer.IfCustomerListLenghtIsZero();
        }

        private static int InputCustomerIndex(string todo) 
        {
            InputForCustomer.ShowCustomers(ConsoleKey.D4);
            Console.WriteLine();
            int index_of_customer_that_books_room = CommonMethods.InputIndex("customer", $"{todo}");

            return index_of_customer_that_books_room;
        }

        private static int InputHotelIndex()
        {
            InputForHotel.ShowHotels(ConsoleKey.D4);
            Console.WriteLine();
            int index_of_hotel = CommonMethods.InputIndex("hotel", ", in which room will be booked");

            return index_of_hotel;
        }

        private static void SpecificHotelInfo(int index_of_hotel)
        {
            Console.WriteLine("\tChosen hotel\n");

            ArrayList array_of_specific_hotel = HotelMethods.ShowSpecificHotel(index_of_hotel);

            int number_of_rooms_in_specific_hotel = HotelMethods.NumberOfRoomsInSpecificHotel(index_of_hotel);

            int[] array_of_Room_Number = (int[])array_of_specific_hotel[1];
            int[] array_of_Room_Price_For_1_Day = (int[])array_of_specific_hotel[2];
            bool[] array_of_Is_Booked = (bool[])array_of_specific_hotel[3];


            Console.WriteLine(array_of_specific_hotel[0]);

            for (int i = 0; i < number_of_rooms_in_specific_hotel; i++)
            {
                Console.WriteLine($"{i + 1}. Room number = {array_of_Room_Number[i]}");
                Console.WriteLine($"   Rrice for 1 day = {array_of_Room_Price_For_1_Day[i]}");
                Console.WriteLine($"   Is room booked = {array_of_Is_Booked[i]}");
            }
            Console.WriteLine();
        }

        public static void BookRoom()
        {
            Console.Clear();

            CheckIfListOfHotelsAndCustomersAreNotEmpty();


            int index_of_customer_that_books_room = InputCustomerIndex(", that will book the room");
            Console.Clear();

            int index_of_hotel = InputHotelIndex();
            Console.Clear();

            SpecificHotelInfo(index_of_hotel);

            int index_of_room = CommonMethods.InputIndex("room", ", that will be booked");
            Console.Clear();

            string string_days_to_book_room = CommonMethods.Initialize("number of days for which you want to book the apartment", 
                                                                                                @"^[1-9]$|^[1-9][0-9]+$");
            int days_to_book_room = int.Parse(string_days_to_book_room);
            Console.Clear();

            RoomMethods.BookRoom(index_of_customer_that_books_room, index_of_hotel, index_of_room, days_to_book_room);

            Console.WriteLine("Customer has successfully booked a room!");
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadKey();
        }

        public static void CancelReservation()
        {
            Console.Clear();
            CheckIfListOfHotelsAndCustomersAreNotEmpty();

            int index_of_customer_that_books_room = InputCustomerIndex(", that will book cancell reservation of booked room");
            Console.Clear();

            RoomMethods.CancelReservation(index_of_customer_that_books_room);

            Console.WriteLine("Customer has successfully cancelled a room reservation!");
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadKey();

        }

        public static void ShowDetailsOfSpecificRoomInSpecificHotel()
        {
            Console.Clear();

            CheckIfListOfHotelsAndCustomersAreNotEmpty();



            InputForHotel.ShowHotels(ConsoleKey.D4);

/*            int index_of_customer_that_books_room = InputCustomerIndex("");
            Console.Clear();
*/

            int index_of_hotel = InputHotelIndex();
            Console.Clear();

            SpecificHotelInfo(index_of_hotel);
        }

        public static void ViewInfoAndNumberOfReservedRooms()
        {
            //Not only number, but details of room

        }

        public static void ShowPriceOfTheRoom()
        {


        }

        public static void SeRoom()
        {


        }

    }
}
