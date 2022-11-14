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
            return (
                    "Press key from the list to open one of the menus.\n\n" +
                    "1. Hotels management.\n" +
                    "2. Customers management.\n" +
                    "3. Search.\n" +
                    "4. Exit.\n"
                   );
        }


        internal static string HotelManagementMenu()
        {
            return (
                    "Press key from the list to open one of the menus.\n\n" +
                    "1. Add hotel.\n" +
                    "2. Remove hotel.\n" +
                    "3. View specific hotel.\n" +
                    "4. View all hotels (description, star rate and number of free rooms).\n"+
                    "R. Return ot the Main menu"
                   );
        }

        internal static string CustomersManagementMenu()
        {
            return (
                    "Press key from the list to open one of the menus.\n\n" +
                    "1. Customer information.\n" +
                    "2. Customer interaction with hotel.\n"+
                    "R. Return ot the Main menu"
                   );
        }
        internal static string CustomerInformationMenu()
        {
            return (
                      "Press key from the list to open one of the menus.\n\n" +
                      "1. Add customer.\n"+
                      "2. Remove customer.\n" +
                      "3. Change the customer’s information.\n" +
                      "4. View all hotels(description and number of free rooms.\n"+
                      "5. View the information about the specific customer.\n"+
                      "6. View the information about all customers.\n"+
                      "7. An ability to sort the list by First name.\n"+
                      "8. An ability to sort the list by Last name.\n"+
                      "R. Return ot the Customers management menu"
                   );
        }
        internal static string CustomerInteractionWithHotelMenu()
        {
            return (   
                       "Press key from the list to open one of the menus.\n\n" +
                       "1. Book a room at a particular hotel.\n" +
                       "2. Cancel a customer’s room reservation at a particular hotel.\n"+
                       "3. View the details of a specific room reservation at a particular hotel..\n" +
                       "4. View the number of reserved rooms in a hotel(Specify each room’s number).\n" +
                       "5. View the information about the number of reserved rooms in a hotel(Specify each room’s number).\n" +
                       "6. View the information about the price of service for one - day room reservation.\n" +
                       "7. View the information about customers who have booked rooms at the hotel.\n"+
                       "R. Return ot the Customers management menu"
                   );
        }

        internal static string SearchMenu()
        {
            return (   
                       "Press key from the list to open one of the menus.\n\n" +
                       "1. Search by a keyword among the hotels.\n" +
                       "2. Search by a keyword among the customer.\n"+
                       "R. Return ot the Main menu"
                   );
        }





    }
}
