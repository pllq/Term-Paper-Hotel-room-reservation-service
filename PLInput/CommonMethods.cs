using BLL;
using BLL.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLInput
{
    public class CommonMethods
    {
        public static void CheckIfFilesExistAndCanBeLoaded() 
        { 
            switch ((HotelMethods.HotelDataFileExists(), CustomerMethods.CustomerDataFileExists()))
            {
                case (true, true):
                    Console.WriteLine("Data of created hotels with appropriate name was found and loaded.");
                    Console.WriteLine("Data of created customers with appropriate name was found and loaded. To continue press any key.");
                    Console.ReadKey();
                    break;

                case (true, false):
                    Console.WriteLine("Data of created hotels with appropriate name was found and loaded. To continue press any key.");
                    Console.ReadKey();
                    break;

                case (false, true):
                    Console.WriteLine("Data of created customers with appropriate name was found and loaded. To continue press any key.");
                    Console.ReadKey();
                    break;

                case (false, false):
                    break;
            }
        }

        public static ConsoleKey keyIninze()
        {
            Console.Write("Press key: ");
            ConsoleKey keyInfo = Console.ReadKey().Key;
            return keyInfo;
        }

        internal static string Initialize(string first_or_last, string pattern)
        {
            Console.Write($"Input {first_or_last}: ");
            string last_and_first_name_input = Console.ReadLine();

            while (!RegexPatternCheck.Pattern_of_the_Data_check(last_and_first_name_input, pattern))
            {
                Console.Clear();
                Console.Write($"Wrong input of {first_or_last}. Please try again: ");
                last_and_first_name_input = Console.ReadLine();
            }
            return last_and_first_name_input;
        }

        internal static string ForIndexIniz(string first_or_last, string pattern)
        {
            Console.WriteLine("NOTICE: index starts from 1 !");
            return Initialize(first_or_last, pattern);
        }

        internal static int InputIndex(string index_of, string todo)
        {
            string string_index_user_input = CommonMethods.ForIndexIniz($"index of {index_of} {todo}", @"^[1-9]$|[1-9][0-9]+$");
            int index_user_input = int.Parse(string_index_user_input) - 1;

            while (index_user_input > CustomerMethods.CustomerListLenght())
            {
                Console.Clear();
                string_index_user_input = CommonMethods.ForIndexIniz($"index of {index_of} {todo}", @"^[1-9]$|[1-9][0-9]+$");
                index_user_input = int.Parse(string_index_user_input) - 1;
            }

            return index_user_input;
        }
    }
}
