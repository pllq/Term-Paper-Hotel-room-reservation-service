using DAL;
using System.Collections;
using System.Text.RegularExpressions;

namespace BLL.Logic
{
    public class HotelMethods
    {
        public static List<Hotel> HotelList = new List<Hotel>();
        internal static XMLSerialization<List<Hotel>> xml_serialize_list_of_hotels = new XMLSerialization<List<Hotel>>();
        internal static JSONSerialization<List<Hotel>> json_serialize_list_of_hotels = new JSONSerialization<List<Hotel>>();
        public const string Name_of_file = @"..\..\..\..\DAL\BD\hotel_list";

        //public static string Name_of_file = @"G:\Studying\2) NAU (01.09.2021 - XX.06.2025)\NAU\Homeworks\Second grade\1st Semester\1) OOP\6) Term Paper\TP\DAL\BD\hotel_list";
        ////internal const string Name_of_file = "hotel_list";

        public static bool HotelDataFileExists()
        {
            if (File.Exists(Name_of_file + ".xml"))
            {
                HotelList = xml_serialize_list_of_hotels.Deserialize(Name_of_file);
                return true;
            }
            if (File.Exists(Name_of_file + ".json"))
            {
                HotelList = json_serialize_list_of_hotels.Deserialize(Name_of_file);
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

            HotelList.Add(Hotel);

            xml_serialize_list_of_hotels.Serialize(HotelList, Name_of_file);
            json_serialize_list_of_hotels.Serialize(HotelList, Name_of_file);
        }


        public static void RemoveHotel(int index_of_hotel_to_remove)
        {
            //Think about people, who ordered in that hotel room

            List<Customer> temp_to_delete = new List<Customer>();
            for (int i = 0; i < HotelList[index_of_hotel_to_remove].Rooms.Count; i++) 
            {
                if (HotelList[index_of_hotel_to_remove].Rooms[i].Is_Booked)
                {
                    temp_to_delete.Add(HotelList[index_of_hotel_to_remove].Rooms[i].Customer_of_Room);
                }
            }

            if(temp_to_delete.Count != 0) 
            {
                for (int i = 0; i < temp_to_delete.Count; i++)
                {
                    if(CustomerMethods.CustomerList[i] == temp_to_delete[i]) 
                    {
                        CustomerMethods.CustomerList[i].Have_Booked_the_Room = false;
                    }
                }

                CustomerMethods.xml_serialize_list_of_customers.Serialize(CustomerMethods.CustomerList, CustomerMethods.Name_of_file);
                CustomerMethods.json_serialize_list_of_customers.Serialize(CustomerMethods.CustomerList, CustomerMethods.Name_of_file);
            }

            HotelList.RemoveAt(index_of_hotel_to_remove);

            xml_serialize_list_of_hotels.Serialize(HotelList, Name_of_file);

            json_serialize_list_of_hotels.Serialize(HotelList, Name_of_file);
        }


        internal static void RoomIsBooked(int i, int j, int days)
        {
            HotelList[i].Rooms[j].Is_Booked = true;
            HotelList[i].Number_of_Free_Rooms -= 1;
            HotelList[i].Number_of_Reserved_Rooms += 1;
            HotelList[i].Rooms[j].Days = days;
        }
        internal static void RoomIsNotBooked(int i, int j) 
        {
            HotelList[i].Rooms[j].Is_Booked = false;
            HotelList[i].Number_of_Free_Rooms += 1;
            HotelList[i].Number_of_Reserved_Rooms -= 1;
            HotelList[i].Rooms[j].Customer_of_Room = null;
            HotelList[i].Rooms[j].Days = 0;
        }


        /// <summary>
        /// This method returns array with the names of all created hotels.
        /// <example>
        /// For example:
        /// <code>
        /// 1. *Hotel_name1*
        /// 2. *Hotel_name2*
        /// 3. *Hotel_name3*
        /// </code>
        /// </example>
        /// </summary>
        public static string[] ShowListOfCreatedHotels()
        {
            string[] array_info_of_hotels = new string[HotelList.Count];

            for (int i = 0; i < HotelList.Count; i++)
            {
                array_info_of_hotels[i] =
                    $"{i + 1}. {HotelList[i].Name_of_Hotel}\n";
            }
            return array_info_of_hotels;
        }


        /// <summary>
        /// This method returns ArrayList with full description about specific hotel.
        /// <example>
        /// For example:
        /// <code>
        /// 1. Hotel name: *Hotel_name*
        /// 2. Description of the hotel: *Hotel_description*
        /// 3. Hotel stars rate: *Hotel_stars_rate*
        /// 4. Number of Rooms: *Hotel_number_rooms*
        /// 5. Number of free rooms: *Hotel_number_of_free_rooms*
        /// 6. Brief information about all rooms.
        /// </code>
        /// </example>
        /// </summary>
        public static ArrayList ShowInfoAboutSpecificHotelWithRoomsInfo(int index)
        {
            ArrayList array_info_of_hotels = new ArrayList();

            array_info_of_hotels.Add
                (
                    $"Hotel name: {HotelList[index].Name_of_Hotel}\n" +
                    $"Description of the hotel: {HotelList[index].Description_of_Hotel}\n" +
                    $"Hotel stars rate: {HotelList[index].Hotel_Stars_Rate}\n" +
                    $"Number of Rooms: {HotelList[index].Number_of_Rooms}\n" +
                    $"Number of free rooms: {HotelList[index].Number_of_Free_Rooms}\n" +
                    $"Number of reserved rooms: {HotelList[index].Number_of_Reserved_Rooms}\n"
                );


            int[] array_of_Room_Number = new int[HotelList[index].Rooms.Count];
            int[] array_of_Room_Price_For_1_Day = new int[HotelList[index].Rooms.Count];
            string[] array_of_Is_Booked = new string[HotelList[index].Rooms.Count];

            for (int i = 0; i < HotelList[index].Rooms.Count; i++)
            {
                array_of_Room_Number[i] = HotelList[index].Rooms[i].Room_Number;
                array_of_Room_Price_For_1_Day[i] = HotelList[index].Rooms[i].Room_Price_For_1_Day;
                array_of_Is_Booked[i] = YesOrNo(index, i);
                //array_of_Is_Booked[i] = HotelList[index].Rooms[i].Is_Booked;
            }

            array_info_of_hotels.Add(array_of_Room_Number);
            array_info_of_hotels.Add(array_of_Room_Price_For_1_Day);
            array_info_of_hotels.Add(array_of_Is_Booked);

            return array_info_of_hotels;
        }
        internal static string YesOrNo(int index_of_hotel, int index_of_room)
        {
            switch (HotelList[index_of_hotel].Rooms[index_of_room].Is_Booked)
            {
                case true:
                    return "Yes";

                case false:
                    return "No";
            }
        }


        /// <summary>
        /// This method returns string array with hotel information without rooms data.
        /// <example>
        /// For example:
        /// <code>
        /// 1. Hotel name: *Hotel_name*
        /// 2. Description of the hotel: *Hotel_description*
        /// 3. Hotel stars rate: *Hotel_stars_rate*
        /// 4. Number of Rooms: *Hotel_number_rooms*
        /// 5. Number of free rooms: *Hotel_number_of_free_rooms*
        /// </code>
        /// </example>
        /// </summary>
        public static string[] ShowHotelInfoWithoutRooms()
        {
            string[] array_info_of_hotels = new string[HotelList.Count];

            for (int i = 0; i < HotelList.Count; i++)
            {
                array_info_of_hotels[i] =
                    $"{i + 1}. Hotel name: {HotelList[i].Name_of_Hotel}\n" +
                    $"   Description of the hotel: {HotelList[i].Description_of_Hotel}\n" +
                    $"   Hotel stars rate: {HotelList[i].Hotel_Stars_Rate}\n" +
                    $"   Number of Rooms: {HotelList[i].Number_of_Rooms}\n" +
                    $"   Number of free rooms: {HotelList[i].Number_of_Free_Rooms}\n"+
                    $"   Number of reserved rooms: {HotelList[i].Number_of_Reserved_Rooms}\n\n";
            }
            return array_info_of_hotels;
        }



        public static List<string[]> ShowFreeAndReservedRoomsANDPrice(int index_of_hotel)
        {
            int free_rooms = 0, reserved_rooms = 0;

            for (int i = 0; i < HotelList[index_of_hotel].Rooms.Count; i++)
            {
                switch (HotelList[index_of_hotel].Rooms[i].Is_Booked)
                {
                    case false:
                        free_rooms++;
                        break;

                    case true:
                        reserved_rooms++;
                        break;
                }
            }

            string[] array_of_free_rooms = new string[free_rooms];
            if (free_rooms == 0)
            {
                array_of_free_rooms = new string[1];
                array_of_free_rooms[0] = "All rooms are reserved.";
            }

            string[] array_of_reserved_rooms = new string[reserved_rooms];
            if (reserved_rooms == 0) 
            {
                array_of_reserved_rooms = new string[1];
                array_of_reserved_rooms[0] = "All rooms are free.";
            }

            free_rooms = 0;
            reserved_rooms = 0;

            for (int i = 0; i < HotelList[index_of_hotel].Rooms.Count; i++) 
            { 
                switch (HotelList[index_of_hotel].Rooms[i].Is_Booked) 
                {
                    case false:
                        array_of_free_rooms[free_rooms] = 
                            $"{free_rooms+1}. Room number #{HotelList[index_of_hotel].Rooms[i].Room_Number}\n"+
                            $"   Price for 1 day: {HotelList[index_of_hotel].Rooms[i].Room_Number}";
                        free_rooms++;
                        break;

                    case true:
                        array_of_reserved_rooms[reserved_rooms] =
                            $"{reserved_rooms + 1}. Room number #{HotelList[index_of_hotel].Rooms[i].Room_Number}.\n" +
                            $"   Price for 1 day: {HotelList[index_of_hotel].Rooms[i].Room_Number}.\n" +
                            $"   Reserved by: {HotelList[index_of_hotel].Rooms[i].Customer_of_Room.First_name} " +
                                                 $"{HotelList[index_of_hotel].Rooms[i].Customer_of_Room.Last_name}.\n" +
                            $"   Reserved for {HotelList[index_of_hotel].Rooms[i].Days} day(s).";
                        reserved_rooms++;
                        break;
                }
            }

            List<string[]> arrays_of_free_and_reserved_rooms = new List<string[]>();
            arrays_of_free_and_reserved_rooms.Add(array_of_free_rooms);
            arrays_of_free_and_reserved_rooms.Add(array_of_reserved_rooms);

            return arrays_of_free_and_reserved_rooms;
        }


        public static bool HotelWithSuchNameExists(string name_to_check)
        {
            for(int i = 0; i < HotelList.Count; i++) 
            {
                if (name_to_check.ToUpper() == HotelList[i].Name_of_Hotel.ToUpper()) 
                {
                    return true;
                }
            }

            return false;
        }

        public static int HotelIndexByName(string name_to_check)
        {
            int hotel_index = 0;
            for (int i = 0; i < HotelList.Count; i++)
            {
                if (HotelList[i].Name_of_Hotel.ToUpper() == name_to_check.ToUpper())
                {
                    return hotel_index = i;
                }
            }

            return -1;
        }

        public static void FileDelete()
        {
            if (File.Exists(Name_of_file + ".xml"))
            {
                File.Delete(Name_of_file + ".xml");
            }

            if (File.Exists(Name_of_file + ".json"))
            {
                File.Delete(Name_of_file + ".json");
                return;
            }
        }


        public static int HotelListLenght() =>  HotelList.Count;
        public static int NumberOfRoomsInSpecificHotel(int index) => HotelList[index].Rooms.Count;
    }
}