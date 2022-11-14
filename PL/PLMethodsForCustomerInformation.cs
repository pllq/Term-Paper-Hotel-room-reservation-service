using BIL;
using BIL.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class PLMethodsForCustomerInformation
    {

        private static string InizCustomer(string first_or_last, string pattern) 
        {
            Console.Write($"Input {first_or_last} of the customer: ");
            string last_and_first_name_input = Console.ReadLine();

            while (!RegexPatternCheck.Pattern_of_the_Data_check(last_and_first_name_input, pattern))
            {
                Console.Clear();
                Console.Write($"Wrong input of {first_or_last}, please try again: ");
                last_and_first_name_input = Console.ReadLine();
            }
            return last_and_first_name_input;
        }

        public static void AddCustomer()
        {
            string First_Name_of_the_Customer = InizCustomer("first name", @"^[a-zA-Z]+$");
            string Last_Name_of_the_Customer = InizCustomer("last name", @"^[a-zA-Z]+$");

            string string_Age = InizCustomer("age", @"^[1-9][0-9]$|^1[0-2]\d$");
            int Age = int.Parse(string_Age);


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
                    if (CustomerMethods.CustomerListLenght() == 0)
                    {
                        throw new CustomerListIsEmptyExeption($"List of customers is equal to {CustomerMethods.CustomerListLenght()}.");
                    }
                    break;


                case 1:
                    Console.Clear();

                    Console.WriteLine("There is only one created customer.");
                    Console.WriteLine("Do you want to see the information about this customer?");
                    Console.WriteLine("Press \"Y\" key, to see information about this single cusotomer, or any other to delete him without showing it.");

                    keyInfo = Menu.keyIninze();

                    switch (keyInfo)
                    {
                        case ConsoleKey.Y:
                            keyInfo = ConsoleKey.D4;
                            Console.Clear();
                            ShowCustomers(keyInfo);

                            Console.WriteLine("Do you still want to delete this customer?");
                            Console.WriteLine("Press \"Y\" key, to delete him, or press any other key to return to Main menu without deleteing this customer. ");

                            keyInfo = Menu.keyIninze();
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

                    keyInfo = Menu.keyIninze();

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

        public static void ShowCustomers(ConsoleKey consoleKey)
        {
            if (CustomerMethods.CustomerListLenght() == 0)
            {
                throw new CustomerListIsEmptyExeption($"List of customers is equal to {CustomerMethods.CustomerListLenght()}.");
            }


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

            Console.WriteLine("Press any key to returen to Main menu.");
            Console.ReadKey();
        }





    }
}
