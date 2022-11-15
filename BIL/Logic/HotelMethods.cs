using DAL;
using System.Collections;
using System.Text.RegularExpressions;

namespace BIL.Logic
{
    public class HotelMethods
    {
        internal static List<Hotel> HotelList = new List<Hotel>();
        internal static XMLSerialization<List<Hotel>> xml_serialize_list_of_hotels = new XMLSerialization<List<Hotel>>();
        internal static JSONSerialization<List<Hotel>> json_serialize_list_of_hotels = new JSONSerialization<List<Hotel>>();
        private static string name_of_file = "hotel_list";


        public static bool HotelDataFileExists()
        {
            if (File.Exists(name_of_file + ".xml"))
            {
                HotelList = xml_serialize_list_of_hotels.Deserialize(name_of_file);
                return true;
            }
            if (File.Exists(name_of_file + ".json"))
            {
                HotelList = json_serialize_list_of_hotels.Deserialize(name_of_file);
                return true;
            }

            return false;
        }


        public static void CreateHotel(string Name_of_Hotel, string Decsription_of_Hotel, int Hotel_Stars_Rate,
                     int Number_of_Rooms, ArrayList for_room)
        {
            int[] array_of_Room_Number = (int[])for_room[0];
            int[] array_of_Room_Price_For_1_Day = (int[])for_room[1];
            //bool[] array_of_Is_Reserved = (bool[])for_room[2];
            List<Room> list_of_rooms = new List<Room>();

            for (int i = 0; i < Number_of_Rooms; i++)
            {
                Room Room = new Room(array_of_Room_Number[i], array_of_Room_Price_For_1_Day[i]);

                list_of_rooms.Add(Room);
            }

            Hotel Hotel = new Hotel(Name_of_Hotel, Decsription_of_Hotel, Hotel_Stars_Rate,
                                    Number_of_Rooms, list_of_rooms);


            /*            Hotel Hotel = new Hotel(Name_of_Hotel, Decsription_of_Hotel, Hotel_Stars_Rate,
                                                Number_of_Rooms, Number_of_Free_Rooms, list_of_rooms);

            */
            HotelList.Add(Hotel);

            //
            xml_serialize_list_of_hotels.Serialize(HotelList, name_of_file);

            json_serialize_list_of_hotels.Serialize(HotelList, name_of_file);

        }



        public static void RemoveHotel(int index_of_hotel_to_remove)
        {
            HotelList.RemoveAt(index_of_hotel_to_remove);

            xml_serialize_list_of_hotels.Serialize(HotelList, name_of_file);

            json_serialize_list_of_hotels.Serialize(HotelList, name_of_file);
        }



        public static string[] HotelsList()
        {
            string[] array_info_of_hotels = new string[HotelList.Count];

            for (int i = 0; i < HotelList.Count; i++)
            {
                array_info_of_hotels[i] =
                    $"{i + 1}. {HotelList[i].Name_of_Hotel}\n";
            }
            return array_info_of_hotels;
        }

        public static string[] ViewWholeInfoOfHotels()
        {
            string[] array_info_of_hotels = new string[HotelList.Count];

            for (int i = 0; i < HotelList.Count; i++)
            {
                array_info_of_hotels[i] =
                    $"{i + 1}. Hotle name: {HotelList[i].Name_of_Hotel}\n" +
                    $"   Description of the hotel: {HotelList[i].Description_of_Hotel}\n" +
                    $"   Hotel stars rate: {HotelList[i].Hotel_Stars_Rate}\n" +
                    $"   Number of Rooms: {HotelList[i].Number_of_Rooms}\n" +
                    $"   Number of free rooms: {HotelList[i].Number_of_Free_Rooms}\n\n";
            }
            return array_info_of_hotels;
        }

        public static int HotelListLenght()
        {
            return HotelList.Count;
        }
    }
}