using BIL.Logic;
using PLInput;
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
                                try
                                {
                                    InputForHotel.RemoveHotel();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;

                            //3. Show info about one hotel (D3)
                            case ConsoleKey.D3:
                            case ConsoleKey.D4:

                                try
                                {
                                    Console.Clear();
                                    InputForHotel.ShowHotels(keyInfo);
                                    Console.WriteLine("Press any key to returen to continue work.");
                                    Console.ReadKey();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;


                            //5. Show info about all hotels (D4)
                            case ConsoleKey.D5:
                                try
                                {
                                    InputForHotel.SpecificHotelInfo();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
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
                                try
                                {
                                    InputForCustomer.RemoveCustomer();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;


                            //3. Change customer
                            case ConsoleKey.D3:
                                Console.Clear();
                                try
                                {
                                    InputForCustomer.ChangeCustomer();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;


                            //4. This method returns array with the names of all created customers.
                            case ConsoleKey.D4:
                                Console.Clear();
                                try
                                {
                                    InputForCustomer.ShowCustomers(ConsoleKey.D3);
                                    Console.WriteLine("Press any key to returen to continue work.");
                                    Console.ReadKey();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;


                            //5. This method returns string array with information about all customers.
                            case ConsoleKey.D5:
                                Console.Clear();
                                try
                                {
                                    InputForCustomer.ShowCustomers(ConsoleKey.D4);
                                    Console.WriteLine("Press any key to returen to continue work.");
                                    Console.ReadKey();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;


                            //6. and 7. Sort the list by first/lastname and ascednding/descending order
                            case ConsoleKey.D6:
                            case ConsoleKey.D7:

                                Console.Clear();
                                try
                                {
                                    InputForCustomer.SortList(keyInfo);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
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
                        try
                        {
                            InputForHotel.IfHotelsListLenghtIsZero();
                            InputForCustomer.IfCustomerListLenghtIsZero();
                        }
                        catch (Exception e) 
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Press any key to returen to Main menu.");
                            Console.ReadKey();
                            break;
                        }

                    wrong_key3:

                        Console.Clear();
                        Console.WriteLine(MenusToShow.RoomManagement());
                        keyInfo = CommonMethods.keyIninze();

                        switch (keyInfo)
                        {
                            //Book a room
                            case ConsoleKey.D1:
                                try 
                                {
                                    InputForRoom.BookRoom();
                                }
                                catch(Exception e) 
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;

                            //Cancel reservation
                            case ConsoleKey.D2:
                                try 
                                { 
                                    InputForRoom.CancelReservation();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;


                            case ConsoleKey.D3:
                                try
                                {
                                    InputForRoom.ShowDetailsOfSpecificRoomInSpecificHotel();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }

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
                        try
                        {
                            //BUT NOT 'AND'!!
                            //HERE HAS TO BE 'OR'
                            InputForHotel.IfHotelsListLenghtIsZero();
                            InputForCustomer.IfCustomerListLenghtIsZero();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Press any key to returen to Main menu.");
                            Console.ReadKey();
                            break;
                        }

                    wrong_key4:

                        /*
                         //Here will be:

                        try
                        {
                            InputForSearch.Search();
                        }
                        catch(Exception e )
                        {
                            Console.WriteLine(e.Message);
                        }

                         */
                        Console.Clear();
                        Console.WriteLine(MenusToShow.SearchMenu());

                        keyInfo = CommonMethods.keyIninze();

                        switch (keyInfo)
                        {
                            case ConsoleKey.D1:
                                break;

                            case ConsoleKey.D2:
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
        }
    }
}