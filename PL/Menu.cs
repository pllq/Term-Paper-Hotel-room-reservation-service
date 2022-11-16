using BIL.Logic;
using PLInput;
using System.Security.Cryptography;

namespace PL
{
    public class Menu
    {
        public static void MainMenu()
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

                                //3. Change hotel
                            case ConsoleKey.D3:
                                try
                                {
                                    Console.Clear();
                                    //InputForHotel.ChangeHotel();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;


                            //4. Show info about one hotel (D3)
                            case ConsoleKey.D4:
                                try
                                {
                                    Console.Clear();
                                    InputForHotel.ShowHotels(ConsoleKey.D3);
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
                                    Console.Clear();
                                    InputForHotel.ShowHotels(ConsoleKey.D4);
                                    Console.WriteLine("Press any key to returen to continue work.");
                                    Console.ReadKey();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;

                            //6. Show info about all hotels (D4)
                            case ConsoleKey.D6:
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
                            //Add customer
                            case ConsoleKey.D1:
                                Console.Clear();
                                InputForCustomer.AddCustomer();
                                break;


                            //Remove customer
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


                            //Change customer
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


                            //Show SPECIFIC customer
                            case ConsoleKey.D4:
                                Console.Clear();
                                try
                                {
                                    InputForCustomer.ShowCustomers(keyInfo);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;


                            //Show all customer
                            case ConsoleKey.D5:
                                Console.Clear();
                                InputForCustomer.ShowCustomers(ConsoleKey.D4);
                                break;


                            //Sort the list by first/lastname and ascednding/descending order
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
                                InputForRoom.CancelReservation();
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


                            case ConsoleKey.D4:
                                break;


                            case ConsoleKey.D5:
                                break;


                            case ConsoleKey.D6:
                                break;


                            case ConsoleKey.D7:
                                break;

                            case ConsoleKey.R:
                                break;

                            default:
                                goto wrong_key3;
                        }
                        break;



                    //4. Search
                    case ConsoleKey.D4:
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