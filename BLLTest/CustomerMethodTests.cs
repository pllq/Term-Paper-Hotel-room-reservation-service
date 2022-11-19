using BLL.Logic;
using DAL;
using System.Collections;
using System.Diagnostics;

namespace BLLTest
{
    [Collection("Sequence")]
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
            CustomerMethods.FileDelete();
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
            CustomerMethods.FileDelete();
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
            customerbefore.First_name = CustomerMethods.CustomerList[0].First_name;
            customerbefore.Last_name = CustomerMethods.CustomerList[0].Last_name;

            CustomerMethods.ChangeCustomer(0, "HlibBrodskyi", "N");

            Customer customerafter = CustomerMethods.CustomerList[0];

            //Assert
            Assert.NotEqual(customerbefore.First_name.ToUpper() + customerbefore.Last_name.ToUpper(),
                            customerafter.First_name.ToUpper() + customerafter.Last_name.ToUpper());
            CustomerMethods.FileDelete();
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
            customerbefore.Last_name = CustomerMethods.CustomerList[0].Last_name;

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

        //Show
        [Fact]
        public void CustomersLists_shoud_not_be_eqaul() 
        {
            CustomerMethods.FileDelete();
            
            //Arrange
            string First_Name_of_the_Customer = "Name", Last_Name_of_the_Customer = "Lastname";
            int Age = 2;

            string First_Name_of_the_Customer2 = "Name2", Last_Name_of_the_Customer2 = "Lastname2";
            int Age2 = 10;

            string First_Name_of_the_Customer3 = "Name3", Last_Name_of_the_Customer3 = "Lastname3";
            int Age3 = 19;

            //Act
            CustomerMethods.Name_of_file = customer_path;
            CustomerNewListAndDeleteFile();

            CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);
            CustomerMethods.CreateCustomer(First_Name_of_the_Customer2, Last_Name_of_the_Customer2, Age2);

            string[] for_expected_array = CustomerMethods.CustomersList();
            string expected = "";

            for (int i = 0; i < for_expected_array.Length; i++) 
            {
                expected += for_expected_array[i];
            }
            

            CustomerMethods.CreateCustomer(First_Name_of_the_Customer3, Last_Name_of_the_Customer3, Age3);

            string[] for_actual_array = CustomerMethods.CustomersList();
            string actual = "";

            for (int i = 0; i < for_actual_array.Length; i++)
            {
                actual += for_actual_array[i];
            }

            //Assert
            Assert.NotEqual(expected, actual);
            CustomerMethods.FileDelete();
        }

        [Fact]
        public void SpecificCustomer_shoud_be_eqaul()
        {
            CustomerMethods.FileDelete();

            //Arrange
            string First_Name_of_the_Customer = "Name", Last_Name_of_the_Customer = "Lastname";
            int Age = 2;

            //Act
            CustomerMethods.Name_of_file = customer_path;
            CustomerNewListAndDeleteFile();

            CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);

            string expected = CustomerMethods.SpecificCustomer(0);
            string actual = CustomerMethods.SpecificCustomer(0);

            //Assert
            Assert.Equal(expected, actual);
            CustomerMethods.FileDelete();
        }

        [Fact]
        public void ViewWholeInfoOfCustomers_shoud_be_eqaul()
        {
            //Arrange
            string First_Name_of_the_Customer = "Name", Last_Name_of_the_Customer = "Lastname";
            int Age = 2;

            string First_Name_of_the_Customer2 = "Name2", Last_Name_of_the_Customer2 = "Lastname2";
            int Age2 = 10;

            string First_Name_of_the_Customer3 = "Name3", Last_Name_of_the_Customer3 = "Lastname3";
            int Age3 = 19;

            //Act
            CustomerMethods.Name_of_file = customer_path;
            CustomerNewListAndDeleteFile();

            CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);
            CustomerMethods.CreateCustomer(First_Name_of_the_Customer2, Last_Name_of_the_Customer2, Age2);

            string[] for_expected_array = CustomerMethods.ViewWholeInfoOfCustomers();
            string expected = "";

            for (int i = 0; i < for_expected_array.Length; i++)
            {
                expected += for_expected_array[i];
            }


            CustomerMethods.CreateCustomer(First_Name_of_the_Customer3, Last_Name_of_the_Customer3, Age3);

            string[] for_actual_array = CustomerMethods.ViewWholeInfoOfCustomers();
            string actual = "";

            for (int i = 0; i < for_actual_array.Length; i++)
            {
                actual += for_actual_array[i];
            }

            //Assert
            Assert.NotEqual(expected, actual);
            CustomerMethods.FileDelete();
        }

        [Fact]
        public void CustomerAlreadyCreated_should_return_true()
        {
            //Arrange
            bool expected = true;

            string First_Name_of_the_Customer = "Name", Last_Name_of_the_Customer = "Lastname";
            int Age = 2;

            string First_Name_of_the_Customer2 = "Name", Last_Name_of_the_Customer2 = "Lastname";


            //Act
            CustomerMethods.Name_of_file = customer_path;
            CustomerNewListAndDeleteFile();

            CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);

            var actual = CustomerMethods.CustomerAlreadyCreated(First_Name_of_the_Customer2, Last_Name_of_the_Customer2);

            //Assert
            Assert.Equal(expected, actual);
            CustomerMethods.FileDelete();
        }

        [Fact]
        public void CustomerIndexByFirstAndLastName_shoud_return_1_when_expected_1()
        {
            //Arrange
            int expected = 0;

            string First_Name_of_the_Customer = "Name", Last_Name_of_the_Customer = "Lastname";
            int Age = 2;

            string First_Name_of_the_Customer2 = "Name", Last_Name_of_the_Customer2 = "Lastname";


            //Act
            CustomerMethods.Name_of_file = customer_path;
            CustomerNewListAndDeleteFile();

            CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);

            int actual = CustomerMethods.CustomerIndexByFirstAndLastName(First_Name_of_the_Customer2, Last_Name_of_the_Customer2);

            //Assert
            Assert.Equal(expected, actual);
            CustomerMethods.FileDelete();
        }
    }
}