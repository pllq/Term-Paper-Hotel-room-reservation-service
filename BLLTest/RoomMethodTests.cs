using BLL.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLTest
{
    public class RoomMethodTests
    {

        [Fact]
        public void CreateHotel_should_return_length_of_list_1()
        {
            //Arrange
                //Hotel
            string Name_of_Hotel = "HotelName", Decsription_of_Hotel = "HotelDescription";
            int Hotel_Stars_Rate = 4, Number_of_Rooms = 2;
            ArrayList for_room = new ArrayList();

            int[] array_of_Room_Number = new int[2];
            int[] array_of_Room_Price_For_1_Day = new int[2];

            //Customer

            string First_Name_of_the_Customer = "Name", Last_Name_of_the_Customer = "Lastname";
            int Age = 2;

            //Act

                //Create hotel:
            HotelMethods.Name_of_file = HotelMethodTests.hotel_path;
            HotelMethodTests.HotelNewListAndDeleteFile();
            for (int i = 0; i < array_of_Room_Number.Length; i++)
            {
                array_of_Room_Number[i] = i + 1;
                array_of_Room_Price_For_1_Day[i] = 10 * (i + 1);
            }

            for_room.Add(array_of_Room_Number);
            for_room.Add(array_of_Room_Price_For_1_Day);

            HotelMethods.CreateHotel(Name_of_Hotel, Decsription_of_Hotel, Hotel_Stars_Rate, Number_of_Rooms, for_room);
            bool expected = HotelMethods.HotelList[0].Rooms[0].Is_Booked;

                //Create customer
            CustomerMethods.Name_of_file = CustomerMethodTests.customer_path;
            CustomerMethodTests.CustomerNewListAndDeleteFile();

            CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);

                //Book:
            RoomMethods.BookRoom(0, 0, 0, 10);

            bool actual = HotelMethods.HotelList[0].Rooms[0].Is_Booked;


            //Assert
            Assert.NotEqual(expected, actual);
            HotelMethods.FileDelete();
            CustomerMethods.FileDelete();
        }





    }
}
