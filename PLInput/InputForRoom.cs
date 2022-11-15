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
        public static void BookRoom()
        {
            InputForHotel.IfHotelsListLenghtIsZero();
            InputForCustomer.IfCustomerListLenghtIsZero();


            InputForCustomer.ShowCustomers(ConsoleKey.D4);
            Console.WriteLine();
            int index_of_customer_that_books_room = CommonMethods.InputIndex("customer", ", that will book the room");
            Console.Clear();

            InputForHotel.ShowHotels(ConsoleKey.D4);
            Console.WriteLine();
            int index_of_hotel = CommonMethods.InputIndex("hotel", ", in which room will be booked") - 1;
            Console.Clear();

            Console.WriteLine("\tChosen hotel\n");
            ArrayList array_of_specific_hotel = HotelMethods.ShowSpecificHotel(index_of_hotel);
            Console.WriteLine(array_of_specific_hotel[0]);

            int number_of_rooms_in_specific_hotel = HotelMethods.NumberOfRoomsInSpecificHotel(index_of_hotel);

            int[] array_of_Room_Number = (int[])array_of_specific_hotel[1];
            int[] array_of_Room_Price_For_1_Day = (int[])array_of_specific_hotel[2];
            bool[] array_of_Is_Booked = (bool[])array_of_specific_hotel[3];


            Console.WriteLine(array_of_specific_hotel[0]);

            for (int i = 0; i < number_of_rooms_in_specific_hotel; i++) 
            {
                Console.WriteLine($"{i+1}. Room number = {array_of_Room_Number[i]}");
                Console.WriteLine($"  Rrice for 1 day = {array_of_Room_Price_For_1_Day[i]}");
                Console.WriteLine($"  Is room booked = {array_of_Is_Booked[i]}");
            }


            int index_of_room = CommonMethods.InputIndex("room", ", that will be booked");
            Console.Clear();


            RoomMethods.BookRoom(index_of_customer_that_books_room, index_of_hotel, index_of_room);



        }

        public static void CancelReservation()
        {


        }

        public static void ViewDetailsOfSpecificRoom()
        {


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
