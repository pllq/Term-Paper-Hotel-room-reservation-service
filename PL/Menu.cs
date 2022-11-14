using BIL;


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
            ConsoleKey keyInfo;

            bool not_E_key = true;


            while (not_E_key) 
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

                                    case ConsoleKey.D8:
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
                        not_E_key = false;
                        break;
                }
            }
        }
    }
}