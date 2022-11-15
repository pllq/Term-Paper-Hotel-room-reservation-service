using BIL.Logic;

namespace PL
{
    public class Menu
    {

        internal static ConsoleKey keyIninze() 
        {
            Console.Write("Press key: ");
            ConsoleKey keyInfo = Console.ReadKey().Key;
            return keyInfo;
        }


        public static void MainMenu() 
        {
            switch((HotelMethods.HotelDataFileExists(), CustomerMethods.CustomerDataFileExists()))
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
            bool not_4_key = true;

            while (not_4_key) 
            {
                Console.Clear();
                Console.WriteLine(MenusToShow.ShowMainMenu());
                keyInfo = keyIninze();

                switch (keyInfo) 
                {
                    //1. Hotels management.
                    case ConsoleKey.D1:
                    wrong_key1:
                        
                        Console.Clear();
                        Console.WriteLine(MenusToShow.HotelManagementMenu());
                        
                        keyInfo = keyIninze();

                        switch (keyInfo)
                        {
                            case ConsoleKey.D1:
                                Console.Clear();
                                PLMethodsForHotel.AddHotel();
                                    break;

                            case ConsoleKey.D2:
                                try 
                                { 
                                    PLMethodsForHotel.RemoveHotel();
                                }
                                catch(Exception e) 
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;

                            case ConsoleKey.D3:

                                try
                                {
                                    Console.Clear();
                                    PLMethodsForHotel.ShowHotels(keyInfo);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }

                                break;

                            case ConsoleKey.D4:

                                try
                                {
                                    Console.Clear();
                                    PLMethodsForHotel.ShowHotels(keyInfo);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;

                            case ConsoleKey.D5:
                                break;

                            case ConsoleKey.D6:
                                break;

                            case ConsoleKey.D7:
                                break;

                            case ConsoleKey.D8:
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
                        Console.WriteLine(MenusToShow.CustomersManagementMenu());

                        keyInfo = keyIninze();

                        switch (keyInfo)
                        {
                            case ConsoleKey.D1:

                            wrong_key21:

                                Console.Clear();
                                Console.WriteLine(MenusToShow.CustomerInformationMenu());
                                keyInfo = keyIninze();

                                switch (keyInfo)
                                {
                                    case ConsoleKey.D1:
                                        Console.Clear();
                                        PLMethodsForCustomerInformation.AddCustomer();
                                        break;

                                    case ConsoleKey.D2:
                                        Console.Clear();
                                        try
                                        {
                                            PLMethodsForCustomerInformation.RemoveCustomer();
                                        }
                                        catch(Exception e) 
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        break;

                                    case ConsoleKey.D3:
                                        Console.Clear();
                                        try
                                        {
                                            //PLMethodsForCustomerInformation.ShowCustomers(keyInfo);

                                            PLMethodsForCustomerInformation.ChangeCustomer();
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }

                                        break;

                                    case ConsoleKey.D4:
                                        Console.Clear();
                                        try
                                        {
                                            PLMethodsForCustomerInformation.ShowCustomers(keyInfo);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        break;

                                    case ConsoleKey.D5:
                                        Console.Clear();
                                        break;

                                    case ConsoleKey.D6:
                                        Console.Clear();

                                        break;

                                    case ConsoleKey.D7:
                                        Console.Clear();

                                        break;

                                    case ConsoleKey.D8:
                                        Console.Clear();

                                        break;

                                    case ConsoleKey.R:
                                        goto wrong_key2;

                                    default:
                                        goto wrong_key21;
                                }
                                break;


                            case ConsoleKey.D2:
                            wrong_key22:

                                Console.Clear();
                                Console.WriteLine(MenusToShow.CustomerInteractionWithHotelMenu());
                                keyInfo = keyIninze();

                                switch (keyInfo)
                                {
                                    case ConsoleKey.D1:
                                        break;

                                    case ConsoleKey.D2:
                                        break;

                                    case ConsoleKey.D3:
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
                                        goto wrong_key2;

                                    default:
                                        goto wrong_key22;
                                }
                                break;

                            case ConsoleKey.R:
                                break;

                            default:
                                goto wrong_key2;
                        }
                        break;
                     


                    //3. Search
                    case ConsoleKey.D3:
                    wrong_key3:

                        Console.Clear();
                        Console.WriteLine(MenusToShow.SearchMenu());

                        keyInfo = keyIninze();

                        switch (keyInfo) 
                        {
                            case ConsoleKey.D1:
                                break;

                            case ConsoleKey.D2:
                                break;

                            case ConsoleKey.R:
                                break;

                            default:
                                goto wrong_key3;
                        }
                        break;



                    //4. Exit.
                    case ConsoleKey.D4:
                        not_4_key = false;
                        break;
                }
            }
        }
    }
}