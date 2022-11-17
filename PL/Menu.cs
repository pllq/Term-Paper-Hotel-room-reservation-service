using BIL.Logic;
using PLInput;
using System.Reflection;
using System.Security.Cryptography;

namespace PL
{
    public class Menu
    {
        public static void MainMenu()
        {
            switch ((BIL.Logic.HotelMethods.HotelDataFileExists(), CustomerMethods.CustomerDataFileExists()))
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


            ConsoleKey keyInfo;
            bool not_Exit_key = true;

            while (not_Exit_key)
            {
                Console.Clear();
                Console.WriteLine(MenusToShow.ShowMainMenu());
                keyInfo = CommonMethods.keyIninze();

                try 
                { 
                    switch (keyInfo)
                    {
                        //1. Hotels management.
                        case ConsoleKey.D1:
                        wrong_key1:


                                Console.Clear();
                                Console.WriteLine(MenusToShow.HotelManagementMenu());

                                keyInfo = CommonMethods.keyIninze();

                                switch (keyInfo)
                                {

                                    //1. Add hotel
                                    case ConsoleKey.D1:
                                        Console.Clear();
                                        InputForHotel.AddHotel();
                                        break;

                                    //2. Remove hotel
                                    case ConsoleKey.D2:
                                        InputForHotel.RemoveHotel();
                                        break;

                                    //3. Show info about one hotel (D3)
                                    case ConsoleKey.D3:
                                    case ConsoleKey.D4:
                                            Console.Clear();
                                            InputForHotel.ShowHotels(keyInfo);
                                            Console.WriteLine("Press any key to return to Main Nenu.");
                                            Console.ReadKey();
                                        break;


                                    //5. Show info about all hotels (D4)
                                    case ConsoleKey.D5:
                                        InputForHotel.SpecificHotelInfo();
                                        break;


                                    case ConsoleKey.R:
                                        break;

                                    default:
                                        goto wrong_key1;
                                }
                                break;



                        //2.Customers management.
                        case ConsoleKey.D2:
                        wrong_key2:

                            Console.Clear();
                            Console.WriteLine(MenusToShow.CustomerManagement());
                            keyInfo = CommonMethods.keyIninze();

                            switch (keyInfo)
                            {
                                //1. Add customer
                                case ConsoleKey.D1:
                                    Console.Clear();
                                    InputForCustomer.AddCustomer();
                                    break;


                                //2. Remove customer
                                case ConsoleKey.D2:
                                    Console.Clear();
                                    InputForCustomer.RemoveCustomer();
                                    break;


                                //3. Change customer
                                case ConsoleKey.D3:
                                    Console.Clear();
                                    InputForCustomer.ChangeCustomer();
                                    break;


                                //4. This method returns array with the names of all created customers.
                                case ConsoleKey.D4:
                                    Console.Clear();
                                    InputForCustomer.ShowCustomers(ConsoleKey.D3);
                                    Console.WriteLine("Press any key to return to Main Menu.");
                                    Console.ReadKey();
                                    break;


                                //5. Information about SPECIFIC cusotmer.
                                case ConsoleKey.D5:
                                    Console.Clear();
                                    InputForCustomer.SpecificCustomerInfo();
                                    Console.WriteLine("Press any key to return to Main Menu.");
                                    Console.ReadKey();
                                    break;

                                //6. Information about ALL customers.
                                case ConsoleKey.D6:
                                    Console.Clear();
                                    InputForCustomer.ShowCustomers(ConsoleKey.D4);
                                    Console.WriteLine("Press any key to return to Main Menu.");
                                    Console.ReadKey();
                                    break;




                                //7. and 8. Sort the list by first/lastname and ascednding/descending order
                                case ConsoleKey.D7:
                                case ConsoleKey.D8:
                                    Console.Clear();
                                        InputForCustomer.SortList(keyInfo);
                                    break;


                                case ConsoleKey.R:
                                    break;

                                default:
                                    goto wrong_key2;
                            }
                            break;



                        //3.Room management.
                        case ConsoleKey.D3:
                            Console.Clear();
                            InputForHotel.IfHotelsListLenghtIsZero();
                            InputForCustomer.IfCustomerListLenghtIsZero();

                        wrong_key3:

                            Console.Clear();
                            Console.WriteLine(MenusToShow.RoomManagement());
                            keyInfo = CommonMethods.keyIninze();

                            switch (keyInfo)
                            {
                                //Book a room
                                case ConsoleKey.D1:
                                    InputForRoom.BookRoom();
                                    break;

                                //Cancel reservation
                                case ConsoleKey.D2:
                                    InputForRoom.CancelReservation();
                                    break;


                                case ConsoleKey.D3:
                                    InputForRoom.ShowDetailsOfSpecificRoomInSpecificHotel();
                                    break;


                                //4. An ability to view the number of free rooms in a hotel
                                case ConsoleKey.D4:
                                    InputForRoom.ShowInfoOfAllFreeRooms();
                                    break;


                                case ConsoleKey.R:
                                    break;

                                default:
                                    goto wrong_key3;
                            }
                            break;



                        //4. Search
                        case ConsoleKey.D4:
                            //Smth like that:
                            Console.Clear();

                            //BUT NOT 'AND'!!
                            //HERE HAS TO BE 'OR'
                            InputForHotel.IfHotelsListLenghtIsZero();
                            InputForCustomer.IfCustomerListLenghtIsZero();

                        wrong_key4:
                            Console.Clear();
                            Console.WriteLine(MenusToShow.SearchMenu());

                            keyInfo = CommonMethods.keyIninze();

                            switch (keyInfo)
                            {
                                case ConsoleKey.D1:
                                case ConsoleKey.D2:
                                    InputForSearch.Search(keyInfo);
                                    break;

                                case ConsoleKey.R:
                                    break;

                                default:
                                    goto wrong_key4;
                            }
                            break;



                        //5. Exit.
                        case ConsoleKey.D5:
                            not_Exit_key = false;
                            return;
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to return to Main Menu.");
                    Console.ReadKey();
                }
            }
        }
    }
}