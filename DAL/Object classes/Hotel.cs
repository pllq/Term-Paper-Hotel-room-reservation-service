using System.Runtime.Serialization;
using System.Xml.Linq;

namespace DAL
{
    [Serializable]
    public class Hotel : ISerializable
    {

        public string Name_of_Hotel { get; set; }
        public string Description_of_Hotel { get; set; }
        public int Hotel_Stars_Rate { get; set; }
        public int Number_of_Rooms { get; set; }
        public int Number_of_Free_Rooms { get; set; }
        public int Number_of_Reserved_Rooms { get; set; }

        public List<Room> Rooms = new List<Room>();
        
        /*
                public Hotel(string Name_of_Hotel, string Decsription_of_Hotel, int Hotel_Stars_Rate, 
                             int Number_of_Rooms, int Number_of_Free_Rooms,
                             int Room_Number, int Room_Price_For_1_Day, bool Have_Booked_the_Room)
                {
                    this.Name_of_Hotel = Name_of_Hotel;
                    this.Description_of_Hotel = Decsription_of_Hotel;
                    this.Hotel_Stars_Rate = Hotel_Stars_Rate;
                    this.Number_of_Rooms = Number_of_Rooms;
                    this.Number_of_Free_Rooms = Number_of_Free_Rooms;

                    //Room:
                    Room = new Room(Room_Number, Room_Price_For_1_Day, Have_Booked_the_Room);
                    Rooms.Add(Room);
                }

                public Hotel(string Name_of_Hotel, string Decsription_of_Hotel, int Hotel_Stars_Rate,
                             int Number_of_Rooms, int Number_of_Free_Rooms, Room Room)
                {
                    this.Name_of_Hotel = Name_of_Hotel;
                    this.Description_of_Hotel = Decsription_of_Hotel;
                    this.Hotel_Stars_Rate = Hotel_Stars_Rate;
                    this.Number_of_Rooms = Number_of_Rooms;
                    this.Number_of_Free_Rooms = Number_of_Free_Rooms;

                    //Room:
                    this.Room = Room;
                    Rooms.Add(this.Room);
                }
        */

        public Hotel() { }

        public Hotel(string Name_of_Hotel, string Decsription_of_Hotel, int Hotel_Stars_Rate,
             int Number_of_Rooms, List<Room> Rooms_List)
        {
            this.Name_of_Hotel = Name_of_Hotel;
            this.Description_of_Hotel = Decsription_of_Hotel;
            this.Hotel_Stars_Rate = Hotel_Stars_Rate;
            this.Number_of_Rooms = Number_of_Rooms;
            this.Number_of_Free_Rooms = this.Number_of_Rooms;
            //Room
            this.Rooms = Rooms_List;
        }

        public Hotel(string Name_of_Hotel, string Decsription_of_Hotel, int Hotel_Stars_Rate,
                     int Number_of_Rooms, int Number_of_Free_Rooms, List<Room> Rooms_List)
        {
            this.Name_of_Hotel = Name_of_Hotel;
            this.Description_of_Hotel = Decsription_of_Hotel;
            this.Hotel_Stars_Rate = Hotel_Stars_Rate;
            this.Number_of_Rooms = Number_of_Rooms;
            this.Number_of_Free_Rooms = Number_of_Free_Rooms;

            //Room
            this.Rooms = Rooms_List;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name_of_Hotel", Name_of_Hotel);
            info.AddValue("Description_of_Hotel", Description_of_Hotel);
            info.AddValue("Hotel_Stars_Rate", Hotel_Stars_Rate);
            info.AddValue("Number_of_Rooms", Number_of_Rooms);
            info.AddValue("Number_of_Free_Rooms", Number_of_Free_Rooms);
            info.AddValue("Rooms", Rooms);
        }

        public Hotel(SerializationInfo info, StreamingContext context)
        {
            Name_of_Hotel = info.GetString("Name_of_Hotel");
            Description_of_Hotel = info.GetString("Description_of_Hotel");
            Hotel_Stars_Rate = info.GetInt16("Hotel_Stars_Rate");
            Number_of_Rooms = info.GetInt16("Number_of_Rooms");
            Number_of_Free_Rooms = info.GetInt16("Number_of_Free_Rooms");

            //Tofix: has to be Rooms = info.GetRoom("Rooms");
            //Rooms = info.GetString("Rooms");
        }



        public override bool Equals(object obj) => this.Equals(obj as Hotel);

        public bool Equals(Hotel hotel)
        {
            if (hotel is null)
            {
                return false;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != hotel.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (Name_of_Hotel == hotel.Name_of_Hotel) &&
                    (Description_of_Hotel == hotel.Description_of_Hotel) &&
                    (Hotel_Stars_Rate == hotel.Hotel_Stars_Rate) &&
                    (Number_of_Rooms == hotel.Number_of_Rooms) &&
                    (Number_of_Free_Rooms == hotel.Number_of_Free_Rooms)&&
                    (Number_of_Reserved_Rooms == hotel.Number_of_Reserved_Rooms)&&
                    (Rooms == hotel.Rooms);
        }

        public static bool operator ==(Hotel left_hotel, Hotel right_hotel)
        {
            if (left_hotel is null)
            {
                if (right_hotel is null)
                {
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return left_hotel.Equals(right_hotel);
        }

        public static bool operator !=(Hotel left_hotel, Hotel right_hotel) => !(left_hotel == right_hotel);
    }
}