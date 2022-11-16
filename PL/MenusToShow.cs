using BIL.Logic;
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
                    "3. Show list of created hotels.\n" +
                    "4. Show hotel information (without rooms).\n" +
                    "5. Show hotel information with all created rooms.\n" +
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
                      "4. View information about specific customer.\n" +
                      "5. View the information about all customers.\n" +
                      "6. Sort the list by first name (ascending or descending order).\n" +
                      "7. Sort the list by last name (ascending or descending order).\n" +
                      "R. Return to the Customers management menu";
        }
        internal static string RoomManagement()
        {
            return "\tRoom Management Menu.\n" +
                       "Press key from the list to open one of the menus.\n\n" +
                       "1. Book a room at a particular hotel.\n" +
                       "2. Cancel a customer’s room reservation at a particular hotel.\n" +
                       "3. View the details of a specific room reservation at a particular hotel..\n" +
                       "4. View the number of reserved rooms in a hotel(Specify each room’s number).\n" +
                       "5. View the information about the number of reserved rooms in a hotel(Specify each room’s number).\n" +
                       "6. View the information about the price of service for one - day room reservation.\n" +
                       "7. View the information about customers who have booked rooms at the hotel.\n" +
                       "R. Return to the Customers management menu";
        }
        internal static string SearchMenu()
        {
            return "\tSearch Menu.\n" +
                       "Press key from the list to open one of the menus.\n\n" +
                       "1. Search by a keyword among the hotels.\n" +
                       "2. Search by a keyword among the customer.\n" +
                       "R. Return to the Main menu";
        }
    }
}
