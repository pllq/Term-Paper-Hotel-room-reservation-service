﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class Room : ISerializable
    {
        public int Room_Number { get; set; }
        public int Room_Price_For_1_Day { get; set; }
        public bool Is_Reserved { get; set; }

        public Room()
        {
        }


        public Room(int Room_Number, int Room_Price_For_1_Day, bool Is_Reserved)
        {
            this.Room_Number = Room_Number;
            this.Room_Price_For_1_Day = Room_Price_For_1_Day;
            this.Is_Reserved = Is_Reserved;
        }



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Room_Number", Room_Number);
            info.AddValue("Room_Price_For_1_Day", Room_Price_For_1_Day);
            info.AddValue("Is_Reserved", Is_Reserved);
        }

        public Room(SerializationInfo info, StreamingContext context)
        {
            Room_Number = info.GetInt16("Room_Number");
            Room_Price_For_1_Day = info.GetInt16("Room_Price_For_1_Day");
            Is_Reserved = info.GetBoolean("Is_Reserved");
        }
    }
}
