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

        public static void BookRoom(int index_of_customer_that_books_room, int index_of_hotel, int index_of_room)
        {
            //If in chosen hotel, chosen room is booked, throw exception
            if (HotelMethods.HotelList[index_of_hotel].Rooms[index_of_room].Is_Booked) 
            {
                throw new Custom_exceptions.RoomIsBookedException();
            }

            HotelMethods.HotelList[index_of_hotel].Rooms[index_of_room].Customer_of_Room =
                CustomerMethods.CustomerList[index_of_customer_that_books_room];

            HotelMethods.HotelList[index_of_hotel].Rooms[index_of_room].Is_Booked = true;

            HotelMethods.xml_serialize_list_of_hotels.Serialize(HotelMethods.HotelList, HotelMethods.Name_of_file);
            HotelMethods.json_serialize_list_of_hotels.Serialize(HotelMethods.HotelList, HotelMethods.Name_of_file);
        }








    }
}
