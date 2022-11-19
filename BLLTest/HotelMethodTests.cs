using BLL.Logic;
using DAL;
using System.Collections;


namespace BLLTest
{
    [Collection("Sequence")]
    public class HotelMethodTests
    {

        internal const string hotel_path = @"test_hotel";

        internal static void HotelNewListAndDeleteFile()
        {
            HotelMethods.FileDelete();
            if (HotelMethods.HotelList.Count != 0)
            {
                HotelMethods.HotelList = new List<Hotel>();
            }
        }

        [Fact]
        public void CreateHotel_should_return_length_of_list_1()
        {
            HotelNewListAndDeleteFile();

            //Arrange

            int expected = 1;

            string Name_of_Hotel = "HotelName", Decsription_of_Hotel = "HotelDescription";
            int Hotel_Stars_Rate = 4, Number_of_Rooms = 2;
            ArrayList for_room = new ArrayList();

            int[] array_of_Room_Number = new int[2];
            int[] array_of_Room_Price_For_1_Day = new int[2];


            //Act
            HotelMethods.Name_of_file = hotel_path;

            for (int i = 0; i < array_of_Room_Number.Length; i++)
            {
                array_of_Room_Number[i] = i + 1;
                array_of_Room_Price_For_1_Day[i] = 10 * (i + 1);
            }

            for_room.Add(array_of_Room_Number);
            for_room.Add(array_of_Room_Price_For_1_Day);

            HotelMethods.CreateHotel(Name_of_Hotel, Decsription_of_Hotel, Hotel_Stars_Rate, Number_of_Rooms, for_room);
            int actual = HotelMethods.HotelListLenght();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveHotel_should_return_length_of_list_0()
        {
            HotelNewListAndDeleteFile();

            //Arrange

            int expected = 0;

            string Name_of_Hotel = "HotelName", Decsription_of_Hotel = "HotelDescription";
            int Hotel_Stars_Rate = 4, Number_of_Rooms = 2;
            ArrayList for_room = new ArrayList();

            int[] array_of_Room_Number = new int[2];
            int[] array_of_Room_Price_For_1_Day = new int[2];


            //Act
            HotelMethods.Name_of_file = hotel_path;

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
        }


        //Show
        [Fact]
        public void ShowListOfCreatedHotels_shoud_not_be_eqaul()
        {
            //Arrange
            string Name_of_Hotel = "HotelName", Decsription_of_Hotel = "HotelDescription";
            int Hotel_Stars_Rate = 4, Number_of_Rooms = 2;
            ArrayList for_room = new ArrayList();

            int[] array_of_Room_Number = new int[2];
            int[] array_of_Room_Price_For_1_Day = new int[2];


            //Act
            HotelMethods.Name_of_file = hotel_path;

            for (int i = 0; i < array_of_Room_Number.Length; i++)
            {
                array_of_Room_Number[i] = i + 1;
                array_of_Room_Price_For_1_Day[i] = 10 * (i + 1);
            }

            for_room.Add(array_of_Room_Number);
            for_room.Add(array_of_Room_Price_For_1_Day);

            HotelMethods.CreateHotel(Name_of_Hotel, Decsription_of_Hotel, Hotel_Stars_Rate, Number_of_Rooms, for_room);

            var for_expected_array = HotelMethods.ShowListOfCreatedHotels();
            string expected = "";
            for (int i = 0; i < for_expected_array.Length; i++) 
            {
                expected = for_expected_array[i];
            }

            var for_actual_array = HotelMethods.ShowListOfCreatedHotels();
            string actual = "";

            for (int i = 0; i < for_actual_array.Length; i++)
            {
                actual = for_actual_array[i];
            }


            //Assert
            Assert.Equal(expected, actual);
            HotelMethods.FileDelete();
        }

        [Fact]
        public void ShowInfoAboutSpecificHotelWithRoomsInfo_shoud_be_eqaul()
        {
            //Arrange
            string Name_of_Hotel = "HotelName", Decsription_of_Hotel = "HotelDescription";
            int Hotel_Stars_Rate = 4, Number_of_Rooms = 2;
            ArrayList for_room = new ArrayList();

            int[] array_of_Room_Number = new int[2];
            int[] array_of_Room_Price_For_1_Day = new int[2];


            //Act
            HotelMethods.Name_of_file = hotel_path;

            for (int i = 0; i < array_of_Room_Number.Length; i++)
            {
                array_of_Room_Number[i] = i + 1;
                array_of_Room_Price_For_1_Day[i] = 10 * (i + 1);
            }

            for_room.Add(array_of_Room_Number);
            for_room.Add(array_of_Room_Price_For_1_Day);

            HotelMethods.CreateHotel(Name_of_Hotel, Decsription_of_Hotel, Hotel_Stars_Rate, Number_of_Rooms, for_room);

            var expected = HotelMethods.ShowInfoAboutSpecificHotelWithRoomsInfo(0);
            var actual = HotelMethods.ShowInfoAboutSpecificHotelWithRoomsInfo(0);

            //Assert
            Assert.Equal(expected, actual);
            HotelMethods.FileDelete();
        }

        [Fact]
        public void ShowHotelInfoWithoutRooms_shoud_be_eqaul()
        {
            //Arrange
            string Name_of_Hotel = "HotelName", Decsription_of_Hotel = "HotelDescription";
            int Hotel_Stars_Rate = 4, Number_of_Rooms = 2;
            ArrayList for_room = new ArrayList();

            int[] array_of_Room_Number = new int[2];
            int[] array_of_Room_Price_For_1_Day = new int[2];


            //Act
            HotelMethods.Name_of_file = hotel_path;

            for (int i = 0; i < array_of_Room_Number.Length; i++)
            {
                array_of_Room_Number[i] = i + 1;
                array_of_Room_Price_For_1_Day[i] = 10 * (i + 1);
            }

            for_room.Add(array_of_Room_Number);
            for_room.Add(array_of_Room_Price_For_1_Day);

            HotelMethods.CreateHotel(Name_of_Hotel, Decsription_of_Hotel, Hotel_Stars_Rate, Number_of_Rooms, for_room);

            var expected = HotelMethods.ShowHotelInfoWithoutRooms();
            var actual = HotelMethods.ShowHotelInfoWithoutRooms();

            //Assert
            Assert.Equal(expected, actual);
            HotelMethods.FileDelete();
        }

        [Fact]
        public void ShowFreeAndReservedRoomsANDPrice_shoud_be_eqaul()
        {
            //Arrange
            string Name_of_Hotel = "HotelName", Decsription_of_Hotel = "HotelDescription";
            int Hotel_Stars_Rate = 4, Number_of_Rooms = 2;
            ArrayList for_room = new ArrayList();

            int[] array_of_Room_Number = new int[2];
            int[] array_of_Room_Price_For_1_Day = new int[2];


            //Act
            HotelMethods.Name_of_file = hotel_path;

            for (int i = 0; i < array_of_Room_Number.Length; i++)
            {
                array_of_Room_Number[i] = i + 1;
                array_of_Room_Price_For_1_Day[i] = 10 * (i + 1);
            }

            for_room.Add(array_of_Room_Number);
            for_room.Add(array_of_Room_Price_For_1_Day);

            HotelMethods.CreateHotel(Name_of_Hotel, Decsription_of_Hotel, Hotel_Stars_Rate, Number_of_Rooms, for_room);

            var expected = HotelMethods.ShowFreeAndReservedRoomsANDPrice(0);
            var actual = HotelMethods.ShowFreeAndReservedRoomsANDPrice(0);

            //Assert
            Assert.Equal(expected, actual);
            HotelMethods.FileDelete();
        }

        [Fact]
        public void HotelWithSuchNameExists_shoud_be_eqaul()
        {
            //Arrange
            string Name_of_Hotel = "HotelName", Decsription_of_Hotel = "HotelDescription";
            int Hotel_Stars_Rate = 4, Number_of_Rooms = 2;
            ArrayList for_room = new ArrayList();

            int[] array_of_Room_Number = new int[2];
            int[] array_of_Room_Price_For_1_Day = new int[2];


            //Act
            HotelMethods.Name_of_file = hotel_path;

            for (int i = 0; i < array_of_Room_Number.Length; i++)
            {
                array_of_Room_Number[i] = i + 1;
                array_of_Room_Price_For_1_Day[i] = 10 * (i + 1);
            }

            for_room.Add(array_of_Room_Number);
            for_room.Add(array_of_Room_Price_For_1_Day);

            HotelMethods.CreateHotel(Name_of_Hotel, Decsription_of_Hotel, Hotel_Stars_Rate, Number_of_Rooms, for_room);

            var expected = HotelMethods.HotelWithSuchNameExists(Name_of_Hotel);
            var actual = HotelMethods.HotelWithSuchNameExists(Name_of_Hotel);

            //Assert
            Assert.Equal(expected, actual);
            HotelMethods.FileDelete();
        }

        [Fact]
        public void HotelIndexByName_shoud_be_eqaul()
        {
            //Arrange
            string Name_of_Hotel = "HotelName", Decsription_of_Hotel = "HotelDescription";
            int Hotel_Stars_Rate = 4, Number_of_Rooms = 2;
            ArrayList for_room = new ArrayList();

            int[] array_of_Room_Number = new int[2];
            int[] array_of_Room_Price_For_1_Day = new int[2];


            //Act
            HotelMethods.Name_of_file = hotel_path;

            for (int i = 0; i < array_of_Room_Number.Length; i++)
            {
                array_of_Room_Number[i] = i + 1;
                array_of_Room_Price_For_1_Day[i] = 10 * (i + 1);
            }

            for_room.Add(array_of_Room_Number);
            for_room.Add(array_of_Room_Price_For_1_Day);

            HotelMethods.CreateHotel(Name_of_Hotel, Decsription_of_Hotel, Hotel_Stars_Rate, Number_of_Rooms, for_room);

            var expected = HotelMethods.HotelIndexByName(Name_of_Hotel);
            var actual = HotelMethods.HotelIndexByName(Name_of_Hotel);

            //Assert
            Assert.Equal(expected, actual);
            HotelMethods.FileDelete();
        }
    }
}
