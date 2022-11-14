using DAL;
using System.Collections;

namespace BIL
{
    public class HotelMethods
    {
        private static List<Hotel> HotelList = new List<Hotel>();

        public static void HotelCreate(string Name_of_Hotel, string Decsription_of_Hotel, int Hotel_Stars_Rate,
                     int Number_of_Rooms, int Number_of_Free_Rooms, ArrayList for_room)
        {

            int[] array_of_Room_Number = (int[])for_room[0];
            int[] array_of_Room_Price_For_1_Day = (int[])for_room[1];
            bool[] array_of_Is_Reserved = (bool[])for_room[2];
            List<Room> list_of_rooms = new List<Room>();

            for(int i = 0; i < Number_of_Rooms; i++) 
            {
                Room Room = new Room(array_of_Room_Number[i], array_of_Room_Price_For_1_Day[i], array_of_Is_Reserved[i]);

                list_of_rooms.Add(Room);
            }

            Hotel Hotel = new Hotel(Name_of_Hotel, Decsription_of_Hotel, Hotel_Stars_Rate,
                                    Number_of_Rooms, Number_of_Free_Rooms, list_of_rooms);

            HotelList.Add(Hotel);

            //Serriallize:
            //
            XMLSerialization<List<Hotel>> serialize_list_of_hotels = new XMLSerialization<List<Hotel>>();
            serialize_list_of_hotels.Serialize(HotelList, @"hotel_list");
            //
        }








    }
}