using BIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class CommonMethods
    {
        public static string Initialize(string first_or_last, string pattern)
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

        internal static string forIniz(string first_or_last, string pattern)
        {
            Console.WriteLine("NOTICE: index starts from 1 !");
            return CommonMethods.Initialize(first_or_last, pattern);
        }


    }
}
