using BLL.Logic;
using DAL;
using System.Collections;

namespace BLLTest
{
    public class CustomerMethodTests
    {
        internal const string customer_path = @"test_customer";

        internal static void CustomerNewListAndDeleteFile()
        {
            CustomerMethods.FileDelete();
            if (CustomerMethods.CustomerList.Count != 0)
            {
                CustomerMethods.CustomerList = new List<Customer>();
            }
        }


        //Create
        [Fact]
        public void CreateCustomer_should_return_length_of_list_1()
        {
            CustomerMethods.FileDelete();

            //Arrange

            int expected = 1;

            string First_Name_of_the_Customer = "Name", Last_Name_of_the_Customer = "Lastname";
            int Age = 2;

            //Act
            CustomerMethods.Name_of_file = customer_path;
            CustomerNewListAndDeleteFile();

            CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);
            int actual = CustomerMethods.CustomerListLenght();

            //Assert
            Assert.Equal(expected, actual);
        }

        //Remove
        [Fact]
        public void RemoveCustomer_should_return_length_of_list_0()
        {
            CustomerMethods.FileDelete();


            //Arrange

            int expected = 0;

            string First_Name_of_the_Customer = "Name", Last_Name_of_the_Customer = "Lastname";
            int Age = 2;
            int indexe_of_customer = 0;

            //Act
            CustomerMethods.Name_of_file = customer_path;
            CustomerNewListAndDeleteFile();

            CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);
            CustomerMethods.RemoveCustomer(indexe_of_customer);
            int actual = CustomerMethods.CustomerListLenght();

            //Assert
            Assert.Equal(expected, actual);
        }

        //Change


        [Fact]
        public void ChangeCustomerNAME_should_return_length_of_list_0()
        {
            CustomerMethods.FileDelete();

            //Arrange

            string First_Name_of_the_Customer = "Name", Last_Name_of_the_Customer = "Lastname";
            int Age = 19;

            //Act
            CustomerMethods.Name_of_file = customer_path;
            CustomerNewListAndDeleteFile();

            CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);
            Customer customerbefore = new Customer();
            customerbefore.First_name =  CustomerMethods.CustomerList[0].First_name;
            customerbefore.Last_name = CustomerMethods.CustomerList[0].Last_name;

            CustomerMethods.ChangeCustomer(0, "HlibBrodskyi", "N");

            Customer customerafter = CustomerMethods.CustomerList[0];

            //Assert
            Assert.NotEqual(customerbefore.First_name.ToUpper()+customerbefore.Last_name.ToUpper(), 
                            customerafter.First_name.ToUpper() + customerafter.Last_name.ToUpper());
        }

        [Fact]
        public void ChangeCustomerFIRSTNAME_should_return_length_of_list_0()
        {
            CustomerMethods.FileDelete();

            //Arrange

            string First_Name_of_the_Customer = "Name", Last_Name_of_the_Customer = "Lastname";
            int Age = 19;

            //Act
            CustomerMethods.Name_of_file = customer_path;
            CustomerNewListAndDeleteFile();

            CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);
            Customer customerbefore = new Customer();
            customerbefore.First_name = CustomerMethods.CustomerList[0].First_name;

            CustomerMethods.ChangeCustomer(0, "Hlib", "F");

            Customer customerafter = CustomerMethods.CustomerList[0];

            //Assert
            Assert.NotEqual(customerbefore.First_name, customerafter.First_name);
        }


        [Fact]
        public void ChangeCustomerLASTNAME_should_return_length_of_list_0()
        {
            CustomerMethods.FileDelete();

            //Arrange
            string First_Name_of_the_Customer = "Name", Last_Name_of_the_Customer = "Lastname";
            int Age = 19;

            //Act
            CustomerMethods.Name_of_file = customer_path;
            CustomerNewListAndDeleteFile();

            CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);
            Customer customerbefore = new Customer();
            customerbefore.Last_name =  CustomerMethods.CustomerList[0].Last_name;

            CustomerMethods.ChangeCustomer(0, "Brodskyi", "L");

            Customer customerafter = CustomerMethods.CustomerList[0];

            //Assert
            Assert.NotEqual(customerbefore.Last_name, customerafter.Last_name);
        }


        [Fact]
        public void ChangeCustomerAGE_should_return_length_of_list_0()
        {
            CustomerMethods.FileDelete();

            //Arrange

            string First_Name_of_the_Customer = "Name", Last_Name_of_the_Customer = "Lastname";
            int Age = 17;

            //Act
            CustomerMethods.Name_of_file = customer_path;
            CustomerNewListAndDeleteFile();

            CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);
            Customer exptected = new Customer();
            exptected.Age = CustomerMethods.CustomerList[0].Age; 
                

            CustomerMethods.ChangeCustomer(0, "20", "A");

            Customer actual = new Customer();
            actual = CustomerMethods.CustomerList[0];

            //Assert
            Assert.NotEqual(exptected.Age, actual.Age);
        }




        //Sort by Firstname
        [Fact]
        public void SortByFirstName_inAscending_should_be_equal()
        {
            CustomerMethods.FileDelete();

            //Arrange
            string First_Name_of_the_Customer = "BName", Last_Name_of_the_Customer = "ALastname";
            int Age = 19;

            string First_Name_of_the_Customer2 = "AName", Last_Name_of_the_Customer2 = "BNotLastname";
            int Age2 = 18;


            //Act
            CustomerMethods.Name_of_file = customer_path;
            CustomerNewListAndDeleteFile();


            CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);
            CustomerMethods.CreateCustomer(First_Name_of_the_Customer2, Last_Name_of_the_Customer2, Age2);
            var first = CustomerMethods.CustomerList[0];
            var second = CustomerMethods.CustomerList[1];

            CustomerMethods.SortByFirstName(ConsoleKey.A);

            var firstafter = CustomerMethods.CustomerList[0];
            var secondafter = CustomerMethods.CustomerList[1];

            //Assert
            Assert.Equal(first, secondafter);
            Assert.Equal(second, firstafter);
        }
        [Fact]
        public void SortByFirstName_inDescending_should_be_equal()
        {
            CustomerMethods.FileDelete();

            //Arrange

            string First_Name_of_the_Customer = "BName", Last_Name_of_the_Customer = "Lastname";
            int Age = 19;

            string First_Name_of_the_Customer2 = "AName", Last_Name_of_the_Customer2 = "NotLastname";
            int Age2 = 18;


            //Act
            CustomerMethods.Name_of_file = customer_path;
            CustomerNewListAndDeleteFile();

            CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);
            CustomerMethods.CreateCustomer(First_Name_of_the_Customer2, Last_Name_of_the_Customer2, Age2);
            var first = CustomerMethods.CustomerList[0];
            var second = CustomerMethods.CustomerList[1];

            CustomerMethods.SortByFirstName(ConsoleKey.B);

            var firstafter = CustomerMethods.CustomerList[1];
            var secondafter = CustomerMethods.CustomerList[0];

            //Assert
            Assert.Equal(first, secondafter);
            Assert.Equal(second, firstafter);
        }


        //Sort by Lasttname
        [Fact]
        public void SortByLastName_inAscending_should_be_equal()
        {
            CustomerMethods.FileDelete();
            //Arrange

            string First_Name_of_the_Customer = "Name", Last_Name_of_the_Customer = "BLastname";
            int Age = 19;

            string First_Name_of_the_Customer2 = "Name", Last_Name_of_the_Customer2 = "ANotLastname";
            int Age2 = 18;


            //Act
            CustomerMethods.Name_of_file = customer_path;
            CustomerNewListAndDeleteFile();

            CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);
            CustomerMethods.CreateCustomer(First_Name_of_the_Customer2, Last_Name_of_the_Customer2, Age2);
            var first = CustomerMethods.CustomerList[0];
            var second = CustomerMethods.CustomerList[1];

            CustomerMethods.SortByLastName(ConsoleKey.A);

            var firstafter = CustomerMethods.CustomerList[1];
            var secondafter = CustomerMethods.CustomerList[0];

            //Assert
            Assert.Equal(first, firstafter);
            Assert.Equal(second, secondafter);
        }
        [Fact]
        public void SortByLastName_inDescending_should_be_equal()
        {
            CustomerMethods.FileDelete();

            //Arrange

            string First_Name_of_the_Customer = "Name", Last_Name_of_the_Customer = "BLastname";
            int Age = 19;

            string First_Name_of_the_Customer2 = "Name", Last_Name_of_the_Customer2 = "ANotLastname";
            int Age2 = 18;


            //Act
            CustomerMethods.Name_of_file = customer_path;
            CustomerNewListAndDeleteFile();

            CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);
            CustomerMethods.CreateCustomer(First_Name_of_the_Customer2, Last_Name_of_the_Customer2, Age2);
            var first = CustomerMethods.CustomerList[0];
            var second = CustomerMethods.CustomerList[1];

            CustomerMethods.SortByLastName(ConsoleKey.D);

            var firstafter = CustomerMethods.CustomerList[0];
            var secondafter = CustomerMethods.CustomerList[1];

            //Assert
            Assert.Equal(first, firstafter);
            Assert.Equal(second, secondafter);
        }










        /*
                [Fact]
                public void IfCustomerHaveBookedTheRoom_should_return_error_when_passing_index_of_minus1()
                {
                    //Arrange

                    int expected = 0;

                    string Name_of_Hotel = "Hotel_name", Decsription_of_Hotel = "Hotel_name";
                        int Hotel_Stars_Rate = 5, Number_of_Rooms = 2;
                    ArrayList List_of_arrays_for_Room_iniz = new ArrayList();

                    int[] array_of_Room_Number = new int[Number_of_Rooms];
                    int[] array_of_Room_Price_For_1_Day = new int[Number_of_Rooms];

                    for(int i = 0; i < Number_of_Rooms; i++) 
                    {
                        array_of_Room_Number[i] = 1;
                        array_of_Room_Price_For_1_Day[i] = 10;
                    }

                    List_of_arrays_for_Room_iniz.Add(array_of_Room_Number);
                    List_of_arrays_for_Room_iniz.Add(array_of_Room_Price_For_1_Day);


                    string First_Name_of_the_Customer = "Name", Last_Name_of_the_Customer = "Lastname";
                    int Age = 2;



                    int index_of_customer = 0;

                    //Act
                    HotelMethods.CreateHotel(Name_of_Hotel, Decsription_of_Hotel, Hotel_Stars_Rate, 
                        Number_of_Rooms, List_of_arrays_for_Room_iniz);
                    CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);

                    //CustomerMethods.IfCustomerHaveBookedTheRoom(index_of_customer);

                    //Assert

                    //Assert.Throws<IndexOutOfRangeException>(() => CustomerMethods.IfCustomerHaveBookedTheRoom(index_of_customer));
                }
        */

    }
}