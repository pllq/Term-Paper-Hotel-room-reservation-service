using BIL;
using BIL.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PLInput
{
    public class InputForCustomer
    {

        internal static void IfCustomerListLenghtIsZero() 
        {
            int CustomerListLenghtIsZero = CustomerMethods.CustomerListLenght();
            if (CustomerListLenghtIsZero == 0)
            {
                throw new CustomerListIsEmptyExeption($"List of customers is equal to {CustomerListLenghtIsZero}.");
            }
        }


        public static void AddCustomer()
        {
            string First_Name_of_the_Customer = CommonMethods.Initialize("first name", @"^[a-zA-Z]+$").ToLower();
            First_Name_of_the_Customer = char.ToUpper(First_Name_of_the_Customer[0]) + First_Name_of_the_Customer.Substring(1);// to make first letter Upper case and others lower case


            string Last_Name_of_the_Customer = CommonMethods.Initialize("last name", @"^[a-zA-Z]+$").ToLower();
            Last_Name_of_the_Customer = char.ToUpper(Last_Name_of_the_Customer[0]) + Last_Name_of_the_Customer.Substring(1);



            string string_Age = CommonMethods.Initialize("age", @"^[1-9][0-9]$|^1[0-2]\d$");
            int Age = int.Parse(string_Age);

        customer_wrongkey:
            Console.Clear();
            Console.WriteLine
                (
                    $"Customer: {First_Name_of_the_Customer} {Last_Name_of_the_Customer}.\n" +
                    $"Age: {Age}.\n"
                );

            Console.WriteLine
                (
                    "Do you want to create this customer?\n" +
                    "Press \"Y\" key, to create customer, or \"N\" key, to cancel the creation."
                );
            Console.WriteLine();

            ConsoleKey keyInfo = CommonMethods.keyIninze();
            switch (keyInfo)
            {
                case ConsoleKey.Y:
                    break;

                case ConsoleKey.N:
                    return;

                default:
                    goto customer_wrongkey;
            }
            Console.WriteLine();

            CustomerMethods.CreateCustomer(First_Name_of_the_Customer, Last_Name_of_the_Customer, Age);
            Console.Write("Customer was successfully created! To return to Main menu press any key.");
            Console.ReadKey();
        }

        public static void RemoveCustomer()
        {
            ConsoleKey keyInfo;

            switch (CustomerMethods.CustomerListLenght())
            {
                case 0:
                    IfCustomerListLenghtIsZero();
                    break;


                case 1:
                    Console.Clear();

                    Console.WriteLine("There is only one created customer.");
                    Console.WriteLine("Do you want to see the information about this customer?");
                    Console.WriteLine("Press \"Y\" key, to see information about this single cusotomer, or any other to delete him without showing it.");

                    keyInfo = CommonMethods.keyIninze();

                    switch (keyInfo)
                    {
                        case ConsoleKey.Y:
                            keyInfo = ConsoleKey.D4;
                            Console.Clear();
                            ShowCustomers(keyInfo);

                            Console.WriteLine("Do you still want to delete this customer?");
                            Console.WriteLine("Press \"Y\" key, to delete him, or press any other key to return to Main menu without deleteing this customer. ");

                            keyInfo = CommonMethods.keyIninze();
                            switch (keyInfo)
                            {
                                case ConsoleKey.Y:
                                    break;

                                default:
                                    return;
                            }
                            break;

                        default:
                            break;
                    }

                    CustomerMethods.RemoveCustomer(0);

                    Console.Clear();
                    Console.WriteLine("Customer was successfully deleted.");
                    Console.WriteLine("Press any key to returen to Main menu.");
                    Console.ReadKey();

                    break;

                case > 1:
                casegreaterthen1Customer:
                    Console.Clear();
                    Console.WriteLine("Do you want to see the information about customers?");
                    Console.WriteLine("Press \"Y\" key, to see information about all customers, or any other key, to delete without showing.");

                    keyInfo = CommonMethods.keyIninze();

                    switch (keyInfo)
                    {
                        case ConsoleKey.Y:
                            keyInfo = ConsoleKey.D4;
                            Console.Clear();
                            ShowCustomers(keyInfo);

                            break;

                        case ConsoleKey.N:
                            break;

                        default:
                            goto casegreaterthen1Customer;
                    }


                    Console.WriteLine("NOTICE: index starts from 1 !");
                    Console.Write("Input index of customer, you want to delete. If you don't want to remove anything, then write 'R' to return to Main menu: ");

                    string user_input = Console.ReadLine();
                    while (!RegexPatternCheck.Pattern_of_the_Data_check(user_input, @"^[1-9]$|[1-9][0-9]+$|^R$|^r$"))
                    {
                        Console.Clear();
                        Console.WriteLine("NOTICE: index starts from 1 !");
                        Console.Write("Wrong input. Please write index as digit, strting from 1, or 'R' to return to Main menu: ");
                        user_input = Console.ReadLine();
                    }

                    switch (user_input)
                    {
                        case "R":
                        case "r":
                            return;

                        default:
                            int index_of_customer_to_remove = int.Parse(user_input) - 1;

                            while (index_of_customer_to_remove > CustomerMethods.CustomerListLenght())
                            {
                                string string_index_of_customer_to_remove;
                                Console.WriteLine($"Index \"{index_of_customer_to_remove}\" is greater then lenght of the list of customers: {CustomerMethods.CustomerListLenght()}.");
                                Console.WriteLine("NOTICE: index starts from 1 !");
                                Console.Write($"Wrong input. Please write index as digit, strting from 1 to {CustomerMethods.CustomerListLenght()}: ");
                                string_index_of_customer_to_remove = Console.ReadLine();

                                while (!RegexPatternCheck.Pattern_of_the_Data_check(string_index_of_customer_to_remove, @"^[1-9]$|[1-9][0-9]+$"))
                                {
                                    Console.WriteLine($"Index \"{index_of_customer_to_remove}\" is greater then lenght of the list of customers: {CustomerMethods.CustomerListLenght()}.");
                                    Console.WriteLine("NOTICE: index starts from 1 !");
                                    Console.Write($"Wrong input. Please write index as digit, strting from 1 to {CustomerMethods.CustomerListLenght()}: ");
                                    string_index_of_customer_to_remove = Console.ReadLine();
                                }

                                index_of_customer_to_remove = int.Parse(string_index_of_customer_to_remove) - 1;
                            }

                            CustomerMethods.RemoveCustomer(index_of_customer_to_remove);
                            break;
                    }
                    break;
            }
        }

        public static void ChangeCustomer()
        {
            IfCustomerListLenghtIsZero();


            Console.WriteLine("Choose what customer you want to edit:");

            ShowCustomers(ConsoleKey.D4);
            Console.WriteLine();

            string user_change;

            int index_user_input = CommonMethods.InputIndex("customer", ", you want to edit");


        changewronginpu:
            Console.Clear();
            Console.WriteLine(CustomerMethods.SpecificCustomer(index_user_input));

            Console.WriteLine("Choose what exectly you want to change in customer's data.\n");
            Console.WriteLine("Press \"N\" key, to change first name and last name.");
            Console.WriteLine("Press \"F\" key, to change first name.");
            Console.WriteLine("Press \"L\" key, to change last name.");
            Console.WriteLine("Press \"A\" key, to change age.");
            //Console.WriteLine("Press \"B\" key, to change room, that user booked (if so).");

            ConsoleKey consoleKey = CommonMethods.keyIninze();
            Console.Clear();
            string what_to_edit = "";

            switch (consoleKey)
            {
                case ConsoleKey.N:
                    string first_name = CommonMethods.ForIndexIniz("new first name", @"^[a-zA-Z]+$");
                    first_name = char.ToUpper(first_name[0]) + first_name.Substring(1);

                    user_change = CommonMethods.Initialize($"new last name", @"^[a-zA-Z]+$").ToLower();
                    user_change = char.ToUpper(user_change[0]) + user_change.Substring(1);

                    user_change = first_name + user_change;
                    what_to_edit = "N";
                    break;

                case ConsoleKey.F:
                case ConsoleKey.L:
                    string forlname = "";
                    switch (consoleKey)
                    {
                        case ConsoleKey.F:
                            forlname = "first";
                            what_to_edit = "F";
                            break;

                        case ConsoleKey.L:
                            forlname = "last";
                            what_to_edit = "L";
                            break;
                    }

                    user_change = CommonMethods.Initialize($"new {forlname} name", @"^[a-zA-Z]+$").ToLower();
                    user_change = char.ToUpper(user_change[0]) + user_change.Substring(1);
                    break;


                case ConsoleKey.A:
                    Console.WriteLine("Customer cannot be younger then 10!");
                    user_change = CommonMethods.Initialize("new age", @"^[1-9]$|[1-9][0-9]+$");
                    what_to_edit = "A";

                    CustomerMethods.ChangeCustomer(index_user_input, user_change, what_to_edit);
                    break;

                /*
                                case ConsoleKey.B:
                                    break;
                */

                default:
                    goto changewronginpu;
            }


            Console.WriteLine("Do you still want to delete change this custmoer?");
            Console.WriteLine("Press \"Y\" key, to change him, or press any other key to return to Main menu without deleteing this hotel. ");

            consoleKey = CommonMethods.keyIninze();
            switch (consoleKey)
            {
                case ConsoleKey.Y:
                    CustomerMethods.ChangeCustomer(index_user_input, user_change, what_to_edit);

                    Console.Clear();
                    Console.WriteLine(CustomerMethods.SpecificCustomer(index_user_input));
                    Console.WriteLine("Customer was successfuly edited! To continue work press any button.");
                    Console.ReadKey();
                    return;

                default:
                    return;
            }
        }


        delegate void DelegateForSorting(ConsoleKey number);
        public static void SortList(ConsoleKey keyInfo) 
        {
            IfCustomerListLenghtIsZero();

            DelegateForSorting sorting_delegate = null;
            string first_of_last_name = "";
            switch (keyInfo)
            {
                case ConsoleKey.D6:
                    first_of_last_name = "first name";
                    sorting_delegate = new DelegateForSorting(CustomerMethods.SortByFirstName);
                    break;

                case ConsoleKey.D7:
                    first_of_last_name = "last name";
                    sorting_delegate = new DelegateForSorting(CustomerMethods.SortByLastName);
                    break;
            }

        sortbyfirst_or_lastname:
            Console.Clear();
            Console.WriteLine("What type of sorting_delegate by name?\n");
            Console.WriteLine($"Press \"A\" to sort lisy by {first_of_last_name} in ascdending order [A-Y].");
            Console.WriteLine($"Press \"D\" to sort lisy by {first_of_last_name} in descdending order [Y-A].");
            keyInfo = CommonMethods.keyIninze();

            switch (keyInfo)
            {
                case ConsoleKey.A:
                case ConsoleKey.D:
                    sorting_delegate(keyInfo);
                        break;

                default:
                    goto sortbyfirst_or_lastname;
            }
            Console.Clear();

            switch (keyInfo)
            {
                case ConsoleKey.A:
                    Console.WriteLine($"List was sorted in ascending order by {first_of_last_name}.");
                    break;

                case ConsoleKey.D:
                    Console.WriteLine($"List was sorted in descending order by {first_of_last_name}.");
                    break;
            }
            Console.WriteLine("Press any key, to return to Main menu.");
            Console.ReadKey();
        }



        public static void ShowCustomers(ConsoleKey consoleKey)
        {
            IfCustomerListLenghtIsZero();


            string[] array_of_customers_info = new string[1];
            switch (consoleKey)
            {
                case ConsoleKey.D3:
                    array_of_customers_info = CustomerMethods.CustomersList();
                    break;

                case ConsoleKey.D4:
                    array_of_customers_info = CustomerMethods.ViewWholeInfoOfCustomers();
                    break;
            }
            Console.WriteLine("All created customers:");

            for (int i = 0; i < array_of_customers_info.Length; i++)
            {
                Console.Write(array_of_customers_info[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Press any key to returen to continue work.");
            Console.ReadKey();
        }

    }
}
