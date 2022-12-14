using BLL.Logic;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class MenusToShow
    {
        internal static string ShowMainMenu()
        {
            return "\tMain Menu.\n" +
                    "Press key from the list to open one of the menus.\n\n" +
                    "1. Hotels management.\n" +
                    "2. Customers management.\n" +
                    "3. Room management.\n" +
                    "4. Search.\n" +
                    "5. Exit.\n";
        }
        internal static string HotelManagementMenu()
        {
            return "\tHotel Management Menu.\n" +
                    $"Hotels created: {HotelMethods.HotelListLenght()}.\n\n" +
                    "Press key from the list to open one of the menus.\n" +
                    "1. Add hotel.\n" +
                    "2. Remove hotel.\n" +
                    "3. Show list of all created hotels.\n" +
                    "4. Show information about specific hotel.\n" +
                    "5. Show the information about all hotels.\n" +
                    "R. Return to the Main menu";
        }
        internal static string CustomerManagement()
        {
            return "\tCustomer Management Menu.\n" +
                      $"Customers created: {CustomerMethods.CustomerListLenght()}.\n\n" +
                      "Press key from the list to open one of the menus.\n\n" +
                      "1. Add customer.\n" +
                      "2. Remove customer.\n" +
                      "3. Change the customer’s information.\n" +
                      "4. Show list of all created customers.\n" +
                      "5. Show information about specific customer.\n" +
                      "6. Show the information about all customers.\n" +
                      "7. Sort the list by first name (ascending or descending order).\n" +
                      "8. Sort the list by last name (ascending or descending order).\n" +
                      "R. Return to the Main Menu";
        }
        internal static string RoomManagement()
        {
            return "\tRoom Management Menu.\n" +
                       "Press key from the list to open one of the menus.\n\n" +
                       "1. Book a room at a particular hotel.\n" +
                       "2. Cancel a customer’s room reservation.\n" +
                       "3. Show list of all created rooms in the specific hotel.\n" +
                       "4. Show free and reserved rooms with information about thier price, who booked and for how many days.\n" +
                       "R. Return to the Main Menu";
        }
        internal static string SearchMenu()
        {
            return "\tSearch Menu.\n" +
                       "Press key from the list to open one of the menus.\n\n" +
                       "1. Search by a keyword among the hotels.\n" +
                       "2. Search by a keyword among the customer.\n" +
                       "R. Return to the Main Menu";
        }
    }
}
