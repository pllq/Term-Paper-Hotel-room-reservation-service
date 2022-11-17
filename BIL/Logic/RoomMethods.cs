using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL.Logic
{
    public class RoomMethods
    {
        public static void BookRoom(int index_of_customer_that_books_room, int index_of_hotel, int index_of_room, int days_to_book_room)
        {
            //If in chosen hotel, chosen room is booked, throw exception
            if (HotelMethods.HotelList[index_of_hotel].Rooms[index_of_room].Is_Booked) 
            {
                throw new Custom_exceptions.RoomIsBookedException();
            }

            CustomerMethods.CustomerList[index_of_customer_that_books_room].Have_Booked_the_Room = true;

            HotelMethods.HotelList[index_of_hotel].Rooms[index_of_room].Customer_of_Room =
                CustomerMethods.CustomerList[index_of_customer_that_books_room];

            HotelMethods.RoomIsBooked(index_of_hotel, index_of_room, days_to_book_room);


            HotelMethods.xml_serialize_list_of_hotels.Serialize(HotelMethods.HotelList, HotelMethods.Name_of_file);
            HotelMethods.json_serialize_list_of_hotels.Serialize(HotelMethods.HotelList, HotelMethods.Name_of_file);
            CustomerMethods.xml_serialize_list_of_customers.Serialize(CustomerMethods.CustomerList, CustomerMethods.Name_of_file);
            CustomerMethods.json_serialize_list_of_customers.Serialize(CustomerMethods.CustomerList, CustomerMethods.Name_of_file);
        }


        public static void CancelReservation(int index_of_customer_that_cancels_books_reservation)
        {
            //If in chosen customer, 
            if (!CustomerMethods.CustomerList[index_of_customer_that_cancels_books_reservation].Have_Booked_the_Room)
            {
                throw new Custom_exceptions.CustomerDidntReserveRoomExeption();
            }

            for(int i = 0; i < HotelMethods.HotelList.Count; i++) 
            {
                for (int j = 0; j < HotelMethods.HotelList[i].Rooms.Count; j++)
                {
                    if (HotelMethods.HotelList[i].Rooms[j].Customer_of_Room == CustomerMethods.CustomerList[index_of_customer_that_cancels_books_reservation]) 
                    {
                        CustomerMethods.CustomerList[index_of_customer_that_cancels_books_reservation].Have_Booked_the_Room = false;

                        HotelMethods.RoomIsNotBooked(i, j);

                        HotelMethods.xml_serialize_list_of_hotels.Serialize(HotelMethods.HotelList, HotelMethods.Name_of_file);
                        HotelMethods.json_serialize_list_of_hotels.Serialize(HotelMethods.HotelList, HotelMethods.Name_of_file);

                        return;
                    }
                }
            }
        }
    }
}
