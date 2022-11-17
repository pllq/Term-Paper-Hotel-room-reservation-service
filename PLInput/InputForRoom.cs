using BaseLibS.Graph;
using BIL.Logic;
using BIL;
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

            int index_of_customer_that_books_room = CommonMethods.InputIndex("customer", $"{todo}");

            return index_of_customer_that_books_room;
        }

        private static int InputHotelIndex(string todo)
        {
            InputForHotel.ShowHotels(ConsoleKey.D4);

            Console.WriteLine();
            int index_of_hotel = CommonMethods.InputIndex("hotel", $"{todo}");

            return index_of_hotel;
        }



        public static void BookRoom()
        {
            Console.Clear();

            CheckIfListOfHotelsAndCustomersAreNotEmpty();


            int index_of_customer_that_books_room = InputCustomerIndex(", that will book the room");
            Console.Clear();

            int index_of_hotel = InputHotelIndex(", in which room will be booked");
            Console.Clear();

            InputForHotel.ShowInfoAboutSpecificHotel(index_of_hotel);

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

            int index_of_hotel = InputHotelIndex("");
            Console.Clear();

            InputForHotel.ShowInfoAboutSpecificHotel(index_of_hotel);
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadKey();
        }

        public static void ShowInfoOfAllFreeRooms()
        {

            //Not only number, but details of room
            Console.Clear();

            CheckIfListOfHotelsAndCustomersAreNotEmpty();

            int index_of_hotel = InputHotelIndex("");
            Console.Clear();

            //TOdo:
            SpecificHotelInfo(index_of_hotel);

            List<string[]> free_and_reserved_rooms_with_price_info = HotelMethods.ShowFreeAndReservedRoomsANDPrice(index_of_hotel);

            string[] array_of_free_rooms = free_and_reserved_rooms_with_price_info[0];
            string[] array_of_reserved_rooms = free_and_reserved_rooms_with_price_info[1];

            Console.WriteLine("\tFree rooms:");
            for(int i = 0; i < array_of_free_rooms.Length; i++) 
            {
                Console.WriteLine(array_of_free_rooms[i]);
            }
            Console.WriteLine();

            Console.WriteLine("\tReserved rooms:");
            for (int i = 0; i < array_of_reserved_rooms.Length; i++)
            {
                Console.WriteLine(array_of_reserved_rooms[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadKey();
        }

        internal static void SpecificHotelInfo(int index_of_hotel)
        {
            Console.WriteLine("\tChosen hotel\n");

            ArrayList array_of_specific_hotel = BIL.Logic.HotelMethods.ShowInfoAboutSpecificHotelWithRoomsInfo(index_of_hotel);

            int number_of_rooms_in_specific_hotel = BIL.Logic.HotelMethods.NumberOfRoomsInSpecificHotel(index_of_hotel);

            int[] array_of_Room_Number = (int[])array_of_specific_hotel[1];
            int[] array_of_Room_Price_For_1_Day = (int[])array_of_specific_hotel[2];
            string[] array_of_Is_Booked = (string[])array_of_specific_hotel[3];

            Console.WriteLine(array_of_specific_hotel[0]);
            Console.WriteLine();
        }
    }
}
