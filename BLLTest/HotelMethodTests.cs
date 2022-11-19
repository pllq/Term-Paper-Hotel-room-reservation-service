using BLL.Logic;
using DAL;
using System.Collections;


namespace BLLTest
{
    public class HotelMethodTests
    {

        readonly string path = @"test_hotel";

        private static void NewListAndDeleteFile()
        {
            if (HotelMethods.HotelList.Count != 0)
            {
                HotelMethods.HotelList = new List<Hotel>();
                HotelMethods.FileDelete();
            }
        }

        [Fact]
        public void CreateHotel_should_return_length_of_list_1()
        {
            //Arrange

            int expected = 1;

            string Name_of_Hotel = "HotelName", Decsription_of_Hotel = "HotelDescription";
            int Hotel_Stars_Rate = 4, Number_of_Rooms = 2;
            ArrayList for_room = new ArrayList();

            int[] array_of_Room_Number = new int[2];
            int[] array_of_Room_Price_For_1_Day = new int[2];


            //Act
            HotelMethods.Name_of_file = path;
            NewListAndDeleteFile();

            for (int i = 0; i < array_of_Room_Number.Length; i++)
            {
                array_of_Room_Number[i] = i+1;
                array_of_Room_Price_For_1_Day[i] = 10*(i+1);
            }

            for_room.Add(array_of_Room_Number);
            for_room.Add(array_of_Room_Price_For_1_Day);

            HotelMethods.CreateHotel(Name_of_Hotel, Decsription_of_Hotel, Hotel_Stars_Rate, Number_of_Rooms, for_room);
            int actual = HotelMethods.HotelListLenght();

            //Assert
            Assert.Equal(expected, actual);
            HotelMethods.FileDelete();
        }

        [Fact]
        public void RemoveHotel_should_return_length_of_list_0()
        {
            //Arrange

            int expected = 0;

            string Name_of_Hotel = "HotelName", Decsription_of_Hotel = "HotelDescription";
            int Hotel_Stars_Rate = 4, Number_of_Rooms = 2;
            ArrayList for_room = new ArrayList();

            int[] array_of_Room_Number = new int[2];
            int[] array_of_Room_Price_For_1_Day = new int[2];


            //Act
            HotelMethods.Name_of_file = path;
            NewListAndDeleteFile();

            for (int i = 0; i < array_of_Room_Number.Length; i++)
            {
                array_of_Room_Number[i] = i + 1;
                array_of_Room_Price_For_1_Day[i] = 10 * (i + 1);
            }

            for_room.Add(array_of_Room_Number);
            for_room.Add(array_of_Room_Price_For_1_Day);

            HotelMethods.CreateHotel(Name_of_Hotel, Decsription_of_Hotel, Hotel_Stars_Rate, Number_of_Rooms, for_room);

            HotelMethods.RemoveHotel(0);

            int actual = HotelMethods.HotelListLenght();

            //Assert
            Assert.Equal(expected, actual);
            HotelMethods.FileDelete();
        }



    }
}
