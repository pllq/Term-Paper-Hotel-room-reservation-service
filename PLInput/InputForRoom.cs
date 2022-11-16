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

        private static int InputHotelIndex(string todo)
        {
            InputForHotel.ShowHotels(ConsoleKey.D4);
            Console.WriteLine("Press any key to returen to continue work.");
            Console.ReadKey();

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

            InputForHotel.SpecificHotelInfo(index_of_hotel);

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

            InputForHotel.SpecificHotelInfo(index_of_hotel);
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
