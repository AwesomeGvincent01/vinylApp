using LanguageExt;
using vinylApp.Model;
using vinylApp.Repositories;
using vinylApp.View;
using vinylApp.Model;
using Microsoft.SqlServer.Server;
using System.Globalization;


namespace vinylApp
{
    public class Program
    {
        private static StorageManager storageManager1;
        private static ConsoleView view;




        static void Main(string[] args)
        {

            //keeps user updated/informed on system status while VinylVault is loading
            Console.WriteLine("Connecting to VinylVault... may take a while, please be patient.");
            string mdfPath = Path.Combine(AppContext.BaseDirectory, "vinylVault.mdf");
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\vinylVault.mdf;Integrated Security=True";


            //storagemanager is the one class that manages all SQL operations, so it is the one that connects to the database
            //it is also the one that is used to access all other classes, so it is the one that is instantiated first
            storageManager1 = new StorageManager(connectionString);
            //all (or at least most) of the UI methods. Keeps program.cs less cluttered.
            view = new ConsoleView();





            //initializes  account/login loop
            HandleAccountMenu();

            // closes db connection on exit
            storageManager1.CloseConnection();
        }

        private static void HandleGenreMenu()
        {
            while (true)
            {
                Console.Clear();

                string choice = view.DisplayGenreMenu();
                switch (choice)
                {
                    case "1":
                        HandleGenreSubmenu(); 
                        break;
                    case "2":
                        UpdateGenreName();
                        break;
                    case "3":
                        InsertNewGenre();
                        break;
                    case "4":
                        DeleteGenreByName();
                        break;
                    case "5":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nInvalid input! ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("please choose a valid option. If you're confused, the options are number based\n\n " +
                            "" +
                            "For example, if you'd like to update genre name, you can see that it is assigned to the number '2', so, if you would\n like to update genre name, simply input '2' into the program, and so on!\n");
                        Console.ResetColor();
                        Console.WriteLine("Continue!? (enter)");
                        Console.ReadLine();
                        break;

                }
            }
        }

        private static void HandleGenreSubmenu()
        {
            while (true)
            {
                Console.Clear();
                string choice = view.DisplayGenreSubmenu();
                switch (choice)
                {
                    case "1":
                        view.DisplayGenres(storageManager1.GetAllGenres());
                        break;
                    case "2":
                        Console.Write("Enter genre name: ");
                        string keyword = Console.ReadLine();
                        view.DisplayGenres(storageManager1.SearchGenresByName(keyword));
                        break;
                    case "3":
                        view.DisplayGenres(storageManager1.SortGenresByName());
                        break;
                    case "4":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nInvalid input! ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("please choose a valid option. If you're confused, the options are number based\n\n " +
                            "" +
                            "For example, if you'd like to view all genres, you can see that it is assigned to the number '1', so, if you would\n like to view all genres, simply input '1' into the program, and so on!\n");
                        Console.ResetColor();
                        Console.WriteLine("Continue!? (enter)");
                        Console.ReadLine();
                        break;
                }

                Console.WriteLine("\nContinue? (enter)");
                Console.ReadLine();
            }
        }


        private static void HandleCustomerMenu()
        {
            while (true)
            {
                Console.Clear();

                string choice = view.DisplayCustomerMenu();
                switch (choice)
                {
                    case "1":
                        HandleCustomerSubmenu();
                        break;
                    case "2":
                        UpdateCustomer();
                        break;
                    case "3":
                        InsertNewCustomer();
                        break;
                    case "4":
                        DeleteCustomerByName();
                        break;
                    case "5":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nInvalid input! ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("please choose a valid option. If you're confused, the options are number based\n\n " +
                            "" +
                            "For example, if you'd like to update customer name, you can see that it is assigned to the number '2', so, if you would\n like to update customer name, simply input '2' into the program, and so on!\n");
                        Console.ResetColor();
                        Console.WriteLine("Continue!? (enter)");
                        Console.ReadLine();
                        break;
                }
            }
        }


        private static void HandleCustomerSubmenu()
        {
            while (true)
            {
                Console.Clear();
                string choice = view.DisplayCustomerSubmenu();

                switch (choice)
                {
                    case "1":
                        view.DisplayCustomers(storageManager1.GetAllCustomers());
                        break;
                    case "2":
                        Console.Write("Enter first name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter last name: ");
                        string lastName = Console.ReadLine();
                        view.DisplayCustomers(storageManager1.SearchCustomersByFullName(firstName, lastName));
                        break;
                    case "3":
                        Console.Write("Enter email: ");
                        string email = Console.ReadLine();
                        view.DisplayCustomers(storageManager1.SearchCustomersByEmail(email));
                        break;
                    case "4":
                        Console.Write("Enter phone number: ");
                        string phone = Console.ReadLine();
                        view.DisplayCustomers(storageManager1.SearchCustomersByPhone(phone));
                        break;
                    case "5":
                        view.DisplayCustomers(storageManager1.SortCustomersByFirstName());
                        break;
                    case "6":
                        view.DisplayCustomers(storageManager1.SortCustomersByLastName());
                        break;
                    case "7":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nInvalid input! ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("please choose a valid option. If you're confused, the options are number based\n\n " +
                            "" +
                            "For example, if you'd like to search for a customer by their email, you can see that it is assigned to the number '3', so, if you would\n like to search for a customer by their email, simply input '3' into the program, and so on!\n");
                        Console.ResetColor();
                        Console.WriteLine("Continue!? (enter)");
                        Console.ReadLine();
                        break;
                }
            }
        }



        private static void HandleArtistMenu()
        {
            while (true)
            {
                Console.Clear();

                string choice = view.DisplayArtistMenu();
                switch (choice)
                {
                    case "1":
                        ArtistSubMenu();
                        break;
                    case "2":
                        UpdateArtistName();
                        break;
                    case "3":
                        InsertNewArtist();
                        break;
                    case "4":
                        DeleteArtistByName();
                        break;
                    case "5":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nInvalid input! ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("please choose a valid option. If you're confused, the options are number based\n\n " +
                            "" +
                            "For example, if you'd like to update artist name, you can see that it is assigned to the number '2', so, if you would\n like to update artist name, simply input '2' into the program, and so on!\n");
                        Console.ResetColor();
                        Console.WriteLine("Continue!? (enter)");
                        Console.ReadLine();
                        break;
                }
            }
        }


        private static void ArtistSubMenu()
        {
            while (true)
            {
                Console.Clear();
                string choice = view.DisplayArtistSubmenu();
                switch (choice)
                {
                    case "1":
                        view.DisplayArtists(storageManager1.GetAllArtists());
                        break;
                    case "2":
                        Console.Write("Enter name keyword: ");
                        string keyword = Console.ReadLine();
                        view.DisplayArtists(storageManager1.SearchArtistsByName(keyword));
                        break;
                    case "3":
                        view.DisplayArtists(storageManager1.SortArtistsByName());
                        break;
                    case "4":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nInvalid input! ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("please choose a valid option. If you're confused, the options are number based\n\n " +
                            "" +
                            "For example, if you'd like to update record title, you can see that it is assigned to the number '2', so, if you would\n like to update record title, simply input '2' into the program, and so on!\n");
                        Console.ResetColor();
                        Console.WriteLine("Continue!? (enter)");
                        Console.ReadLine();
                        break;
                }

                Console.WriteLine("\nContinue? (enter)");
                Console.ReadLine();
            }
        }



        private static void HandleRecordMenu()
        {
            bool recordMenuActive = true;
            while (recordMenuActive)
            {
                Console.Clear();

                string choice = view.DisplayRecordMenu();
                switch (choice)
                {
                    case "1":
                        HandleRecordSubmenu();
                        break;


                    case "2":
                        UpdateRecordTitle();
                        break;

                    case "3":
                        InsertNewRecord();
                        break;

                    case "4":
                        DeleteRecordByTitle();
                        break;



                    case "5":
                        recordMenuActive = false; //exit
                        break;



                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nInvalid input! ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("please choose a valid option. If you're confused, the options are number based\n\n " +
                            "" +
                            "For example, if you'd like to update record title, you can see that it is assigned to the number '2', so, if you would\n like to update record title, simply input '2' into the program, and so on!\n");
                        Console.ResetColor();
                        Console.WriteLine("Continue!? (enter)");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static void HandleRecordSubmenu()
        {
            while (true)
            {
                Console.Clear();
                string choice = view.DisplayRecordSubmenu();
                switch (choice)
                {
                    case "1":
                        view.DisplayRecords(storageManager1.GetAllRecords());
                        break;
                    case "2":
                        Console.Write("Enter title: ");
                        string titleKeyword = Console.ReadLine();
                        view.DisplayRecords(storageManager1.GetRecordsByTitle(titleKeyword));
                        break;
                    case "3":
                        Console.Write("Enter artist/band name: ");
                        string artistKeyword = Console.ReadLine();
                        view.DisplayRecords(storageManager1.SearchRecordsByArtist(artistKeyword));
                        break;
                    case "4":
                        view.DisplayRecords(storageManager1.SortRecordsByTitle());
                        break;
                    case "5":
                        view.DisplayRecords(storageManager1.SortRecordsByYear());
                        break;
                    case "6":
                        HandleRecordsSubSubMenu();
                        break;
                    case "7":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nInvalid input! ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("please choose a valid option. If you're confused, the options are number based\n\n " +
                            "" +
                            "For example, if you'd like to search for records by title, you can see that it is assigned to the number '2', so, if you would\n like to search for records by title, simply input '2' into the program, and so on!\n");
                        Console.ResetColor();
                        Console.WriteLine("Continue!? (enter)");
                        Console.ReadLine();
                        break;
                }

                Console.WriteLine("\nContinue? (enter)");
                Console.ReadLine();
            }
        }


        private static void HandleRecordsSubSubMenu()
        {
            while (true)
            {
                string input = view.DisplayRecordsSubSubMenu();

                switch (input)
                {
                    case "1":
                        FilterRecordsByYearRange();
                        break;
                    case "2":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nInvalid input! ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("please choose a valid option. If you're confused, the options are number based\n\n " +
                            "" +
                            "For example, if you'd like to filter by year range, you can see that it is assigned to the number '1', so, if you would\n like to filter by year range, simply input '1' into the program, and so on!\n");
                        Console.ResetColor();
                        Console.WriteLine("Continue!? (enter)");
                        Console.ReadLine();
                        break;
                }

                Console.WriteLine("\nContinue? (enter)");
                Console.ReadLine();
            }
        }



        private static void FilterRecordsByYearRange()
        {
            string choice = view.DisplayYearRangeFilterMenu();

            int startYear = 0;
            int endYear = 0;

            if (choice == "1")
            {
                view.PromptInputMessage("Enter start year: ");
                string startInput = view.GetInput();
                if (!int.TryParse(startInput, out startYear))
                {
                    view.DisplayMessage("Invalid  year, please make sure you use numbers.\n");
                    Console.WriteLine("Continue? (enter)");
                    Console.ReadLine();
                    return;
                }

                view.DisplayMessage("Enter end year: ");
                string endInput = view.GetInput();
                if (!int.TryParse(endInput, out endYear))
                {
                    view.DisplayMessage("Invalid year, please make sure you use numbers.\n");
                    Console.WriteLine("Continue? (enter)");
                    Console.ReadLine();
                    return;
                }
            }
            else if (choice == "2")
            {
                view.DisplayMessage1("Enter a decade (example: 1980): ");
                string decadeInput = view.GetInput();
                if (!int.TryParse(decadeInput, out startYear))
                {
                    view.DisplayMessage("Invalid decade input, please make sure you use numbers.\n");
                    Console.WriteLine("Continue? (enter)");
                    Console.ReadLine();
                    return;
                }
                endYear = startYear + 9;
            }
            else
            {
                view.DisplayError11("Invalid input! please choose one of the 2 options below");
                return;
            }

            if (startYear > endYear)
            {
                view.DisplayMessage("Start year cannot be greater than the end year, plz try again.");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            var results = storageManager1.GetRecordsByYearRange(startYear, endYear);
            view.DisplayRecords(results);

        }






        private static void HandleOrderMenu()
        {
            while (true)
            {
                Console.Clear();
                string choice = view.DisplayOrderMenu(); 

                switch (choice)
                {
                    case "1":
                        HandleOrderSubmenu();
                        break;
                    case "2":
                        InsertNewOrder(); 
                        break;
                    case "3":
                        UpdateOrderStatus(); 
                        break;
                    case "4":
                        DeleteOrderById(); 
                        break;
                    case "5":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nInvalid input! ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("please choose a valid option. If you're confused, the options are number based\n\n " +
                            "" +
                            "For example, if you'd like to view all orders, you can see that it is assigned to the number '1', so, if you would\n like to view all orders, simply input '1' into the program, and so on!\n");
                        Console.ResetColor();
                        Console.WriteLine("Continue!? (enter)");
                        Console.ReadLine();
                        break;
                }
            }
        }


        private static void HandleOrderSubmenu()
        {
            while (true)
            {
                Console.Clear();
                string choice = view.DisplayOrderSubmenu();
                switch (choice)
                {
                    case "1":
                        view.DisplayOrders(storageManager1.GetOrders(currentUser));

                        break;
                    case "2":
                        Console.Write("Enter Customer ID: ");
                        string idInput = view.GetInput();

                        if (string.IsNullOrWhiteSpace(idInput) || !int.TryParse(idInput, out int customerId))
                        {
                            view.DisplayMessage("IDs must be a number\n");
                            break;
                        }
                        if (customerId <= 0)
                        {
                            view.DisplayMessage("IDs must be a positive number (1 or higher).\n");
                            break;
                        }

                        view.DisplayOrders(storageManager1.GetOrdersByCustomerId(customerId));
                        break;

                    case "3":
                        Console.Write("Enter Order Status (example: Shipped, processing, delivered, cancelled): ");
                        string status = Console.ReadLine();
                        view.DisplayOrders(storageManager1.GetOrdersByStatus(status));
                        break;
                    case "4":
                        Console.Write("Enter start date (yyyy-MM-dd or dd/MM/yyyy): ");
                        string startInput = view.GetInput();
                        Console.Write("Enter end date (yyyy-MM-dd or dd/MM/yyyy): ");
                        string endInput = view.GetInput();

                        if (!DateTime.TryParse(startInput, out DateTime start) ||
                            !DateTime.TryParse(endInput, out DateTime end))
                        {
                            view.DisplayMessage("Invalid date. Please enter a date like 2025-03-15 or 15/03/2025.\n");
                            break;
                        }

                        if (start < new DateTime(1900, 1, 1) || start > new DateTime(2100, 12, 31) ||
                            end < new DateTime(1900, 1, 1) || end > new DateTime(2100, 12, 31))
                        {
                            view.DisplayMessage("Invalid date. Please enter a date between 1900-01-01 and 2100-12-31.\n");
                            break;
                        }

                        if (start >= end)
                        {
                            view.DisplayMessage("Start date must be before end date.\n");
                            break;
                        }

                        view.DisplayOrders(storageManager1.GetOrdersByDateRange(start, end));


                        break;
                    case "5":
                        Console.Write("Enter Order ID to view details: ");
                        string orderInput = view.GetInput();

                        if (string.IsNullOrWhiteSpace(orderInput) || !int.TryParse(orderInput, out int orderId))
                        {
                            view.DisplayMessage("IDs must be a number\n");
                            break;
                        }
                        if (orderId <= 0)
                        {
                            view.DisplayMessage("IDs must be a positive number (1 or higher).\n");
                            break;
                        }

                        view.DisplayOrderDetails(storageManager1.GetOrderDetails(orderId));
                        break;
                    case "6":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nInvalid input! ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("please choose a valid option. If you're confused, the options are number based\n\n " +
                            "" +
                            "For example, if you'd like to view all genres, you can see that it is assigned to the number '1', so, if you would\n like to view all genres, simply input '1' into the program, and so on!\n");
                        Console.ResetColor();
                        Console.WriteLine("Continue!? (enter)");
                        Console.ReadLine();
                        break;
                }

                Console.WriteLine("\nContinue? (enter)");
                Console.ReadLine();
            }
        }








        private static User currentUser = null;

        private static void HandleAccountMenu()
        {
            bool firstRun = true;  

            while (true)
            {
                if (!firstRun) Console.Clear();  //made it so it doesn't clear the "connection succeessful" message
                firstRun = false;               

                Console.WriteLine("\n--- Welcome to the VinylVault! ---\nPlease choose to login or register below");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Choose a option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        Register();
                        break;
                    case "3":
                        Console.WriteLine("Exiting the program... please wait...");
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nInvalid input! ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("please choose a valid option. If you're confused, the options are number based.\n\n " +
                            "" +
                            "For example, if you'd like to login, you can see that it is assigned to the number '1', so, if you would\n like to login, simply input '1' into the program, and if you'd like to register/create a new account, simply input '2'! then, if you would like to exit the program, obviously, input '3'.\n");
                        Console.ResetColor();
                        Console.WriteLine("Continue!? (enter)");
                        Console.ReadLine();
                        break;
                }

                if (currentUser != null)
                {
                    if (currentUser.Role == "Admin")
                        HandleAdminMainMenu();
                    else
                        HandleUserMainMenu();
                }
            }
        }




        private static void Login()
        {
            view.DisplayMessage("Enter username: ");
            string username = view.GetInput();

            view.DisplayMessage("Enter password: ");
            string password = view.GetInput2();

            currentUser = storageManager1.GetUserByUsernameAndPassword(username, password);

            if (currentUser != null)
            {
                Console.WriteLine($"\nLogin successful! Welcome, {currentUser.Username} " +
                  $"({(currentUser.Role == "Admin" ? "Admin" : "User")})");
            }
            else
            {
                Console.WriteLine("Login failed. Invalid username or password.");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
            }
        }


      



        private static void Register()
        {
            view.DisplayMessage("Enter a new username: ");
            string username = view.GetInput().Trim();

            view.DisplayMessage("Enter a password: ");
            string password = view.GetInput2().Trim();




            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                view.DisplayMessage("Your username and password can't be empty, please try again.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
               
            }

            if (username.Length >= 100)
            {
                view.DisplayMessage("Boundary error: you may only have a username with up to *100* characters. Please try again.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (password.Length >= 100)
            {
                view.DisplayMessage("Boundary error: you may only have a password with up to *100* characters. Please try again.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }
            if (username.Contains("$") || username.Contains("%") || username.Contains("^") || password.Contains("$") || password.Contains("%") || password.Contains("^"))
            {
                view.DisplayMessage("Usernames/password can't include funny characters like $%^. Please try again.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            string role = "Customer";

            if (currentUser != null && currentUser.Role == "Admin")
            {
                view.DisplayMessage("Is this an admin account? (yes or no): ");
                string ans = view.GetInput().Trim().ToLower();
                if (ans == "yes" || ans == "y")
                    role = "Admin";
            }

            User newUser = new User(0, username, password, role);

            if (storageManager1.UsernameExists(username))
            {
                view.DisplayMessage("Username is already taken, please try again.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            int newId = storageManager1.InsertUser(newUser);
            Console.WriteLine($"Registration complete. Your user ID is {newId}.");
            Console.WriteLine("Continue? (enter)");
            Console.ReadLine();

        }







        private static void HandleAdminMainMenu()
        {
            while (true)
            {
                Console.Clear();
                string choice = view.DisplayMainMenu();

                switch (choice)
                {
                    case "1": HandleGenreMenu(); break;
                    case "2": HandleCustomerMenu(); break;
                    case "3": HandleArtistMenu(); break;
                    case "4": HandleRecordMenu(); break;
                    case "5": HandleOrderMenu(); break;
                    case "6": CreateUser(); break;
                    case "7": HandleReportsMenu(); break;  
                    case "8":
                        Console.WriteLine("Logging out...");
                        currentUser = null;
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nInvalid input! ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("please choose a valid option. If you're confused, the options are number based.\n\n " +
                            "" +
                            "For example, for the customer menu, you can see that it is assigned to the number '2', so, if you would\n like to access the customer menu, simply input '2' into the program, and so on.\n");
                        Console.ResetColor();
                        Console.WriteLine("Continue!? (enter)");
                        Console.ReadLine();
                        break;
                }

            }
        }





        private static void HandleUserMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n--- User Menu ---");
                Console.WriteLine("1. View All Records");
                Console.WriteLine("2. View All Genres");
                Console.WriteLine("3. View All Artists");
                Console.WriteLine("4. Logout");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        HandleUserRecordSubMenu();
                        break;

                    case "2":
                        view.DisplayGenres(storageManager1.GetAllGenres());
                        Console.WriteLine("Press Enter to return to the menu.");
                        Console.ReadLine();
                        break;

                    case "3":
                        view.DisplayArtists(storageManager1.GetAllArtists());
                        Console.WriteLine("Press Enter to return to the menu.");
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.WriteLine("Logging out... please wait...");
                        currentUser = null;
                        return;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nInvalid input! ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("Hello, user! Please choose a valid option. If you're confused, the options are number based.\n\n" +
                            "For example, for the genre menu, you can see that it is assigned to the number '2'. So, if you would\n" +
                            "like to access the genre menu, simply input '2' into the program, and so on.\n");
                        Console.ResetColor();
                        Console.WriteLine("Continue!? (enter)");
                        Console.ReadLine();
                        break;
                }
            }
        }


        private static void HandleReportsMenu()
        {
            while (true)
            {
                string choice = view.DisplayReportsMenu(); //Report switch (thought I wasn't supposed to use sql commands in program.cs but it was recommended by teacheer)
                try
                {
                    switch (choice)
                    {
                        case "1": // all customers "gmail" email type
                            {
                                using var r = storageManager1.RunReport(
                                    "SELECT FirstName, LastName FROM Customer WHERE Email LIKE '%@gmail.com'");
                                view.DisplayReport(r);
                                break;
                            }
                        case "2": // records after 1975
                            {
                                using var r = storageManager1.RunReport(
                                    "SELECT Title, ReleaseYear FROM Record WHERE ReleaseYear > 1975 ORDER BY ReleaseYear ASC");
                                view.DisplayReport(r);
                                break;
                            }
                        case "3": // phone starts 021
                            {
                                using var r = storageManager1.RunReport(
                                    "SELECT FirstName, LastName FROM Customer WHERE PhoneNumber LIKE '021%' ORDER BY LastName ASC");
                                view.DisplayReport(r);
                                break;
                            }
                        case "4": // cancelled orders (sorted newest to oldest)
                            {
                                using var r = storageManager1.RunReport(
                                    "SELECT OrderID, CustomerID, OrderDate FROM [Order] WHERE Status = 'Cancelled' ORDER BY OrderDate DESC");
                                view.DisplayReport(r);
                                break;
                            }
                        case "5": // rock records (GenreID = 1)
                            {
                                using var r = storageManager1.RunReport(
                                    "SELECT Title, ReleaseYear FROM Record WHERE GenreID = 1");
                                view.DisplayReport(r);
                                break;
                            }
                        case "6": // orders per customer (count)
                            {
                                using var r = storageManager1.RunReport(
                                    @"SELECT Customer.FirstName, Customer.LastName, COUNT([Order].CustomerID) AS TotalOrders
                          FROM Customer INNER JOIN [Order] ON Customer.CustomerID = [Order].CustomerID
                          GROUP BY Customer.FirstName, Customer.LastName
                          ORDER BY TotalOrders DESC");
                                view.DisplayReport(r);
                                break;
                            }
                        case "7": // records per genre (count)
                            {
                                using var r = storageManager1.RunReport(
                                    @"SELECT Genre.[Name], COUNT(Record.RecordID) AS RecordAmount
                          FROM Genre INNER JOIN Record ON Genre.GenreID = Record.GenreID
                          GROUP BY Genre.[Name]");
                                view.DisplayReport(r);
                                break;
                            }
                        case "8": // records per artist (count)
                            {
                                using var r = storageManager1.RunReport(
                                    @"SELECT Artist.ArtistName, COUNT(Record.RecordID) AS Records
                          FROM Artist INNER JOIN Record ON Artist.ArtistID = Record.ArtistID
                          GROUP BY Artist.ArtistName
                          ORDER BY Artist.ArtistName ASC");
                                view.DisplayReport(r);
                                break;
                            }
                        case "9":
                            {
                                using var r = storageManager1.RunReport(
                                    @"SELECT Customer.FirstName, Customer.LastName, Record.Title, [Order].OrderDate, OrderDetail.Quantity
                          FROM Customer
                          INNER JOIN [Order] ON Customer.CustomerID = [Order].CustomerID
                          INNER JOIN OrderDetail ON [Order].OrderID = OrderDetail.OrderID
                          INNER JOIN Record ON OrderDetail.RecordID = Record.RecordID");
                                view.DisplayReport(r);
                                break;
                            }
                        case "10": // total ordered quantity per record
                            {
                                using var r = storageManager1.RunReport(
                                    @"SELECT Record.Title, SUM(OrderDetail.Quantity) AS TotalQuantity
                          FROM Record INNER JOIN OrderDetail ON Record.RecordID = OrderDetail.RecordID
                          GROUP BY Record.Title
                          ORDER BY TotalQuantity DESC");
                                view.DisplayReport(r);
                                break;
                            }
                        case "11": // titles released in a specific year
                            {
                                view.DisplayMessage1("Enter release year: ");
                                string input = view.GetInput();
                                if (!int.TryParse(input, out int year))
                                {
                                    view.DisplayMessage("Invalid year.\n");
                                    break;
                                }

                                using var r = storageManager1.RunReport(
                                    @"SELECT Record.Title, Record.ReleaseYear, Artist.ArtistName
                          FROM Record INNER JOIN Artist ON Record.ArtistID = Artist.ArtistID
                          WHERE Record.ReleaseYear = @year",
                                    p => p.AddWithValue("@year", year));
                                view.DisplayReport(r);
                                break;
                            }
                        case "12": // customers with total qty > N
                            {
                                view.DisplayMessage1("Enter minimum total quantity: ");
                                string input = view.GetInput();
                                if (!int.TryParse(input, out int qty))
                                {
                                    view.DisplayMessage("Invalid number.\n");
                                    break;
                                }

                                using var r = storageManager1.RunReport(
                                    @"SELECT Customer.FirstName, Customer.LastName, SUM(OrderDetail.Quantity) AS TotalQuantity
                          FROM Customer
                          INNER JOIN [Order] ON Customer.CustomerID = [Order].CustomerID
                          INNER JOIN OrderDetail ON OrderDetail.OrderID = [Order].OrderID
                          GROUP BY Customer.FirstName, Customer.LastName
                          HAVING SUM(OrderDetail.Quantity) > @q",
                                    p => p.AddWithValue("@q", qty));
                                view.DisplayReport(r);
                                break;
                            }
                        case "13": // total qty per customer per artist
                            {
                                using var r = storageManager1.RunReport(
                                    @"SELECT Customer.FirstName, Customer.LastName, Artist.ArtistName, SUM(OrderDetail.Quantity) AS TotalQuantity
                          FROM Customer
                          INNER JOIN [Order] ON Customer.CustomerID = [Order].CustomerID
                          INNER JOIN OrderDetail ON [Order].OrderID = OrderDetail.OrderID
                          INNER JOIN Record ON OrderDetail.RecordID = Record.RecordID
                          INNER JOIN Artist ON Record.ArtistID = Artist.ArtistID
                          GROUP BY Customer.FirstName, Customer.LastName, Artist.ArtistName");
                                view.DisplayReport(r);
                                break;
                            }
                        case "14": // Incomplete orders (no details). Also used left joins to displays all customers, even  without linked orders.
                            {
                                using var r = storageManager1.RunReport(
                                    @"SELECT Customer.FirstName, Customer.LastName, SUM(OrderDetail.Quantity) AS Total
                          FROM Customer
                          LEFT JOIN [Order] ON Customer.CustomerID = [Order].CustomerID
                          LEFT JOIN OrderDetail ON [Order].OrderID = OrderDetail.OrderID
                          GROUP BY Customer.FirstName, Customer.LastName
                          HAVING SUM(OrderDetail.Quantity) IS NULL");
                                view.DisplayReport(r);
                                break;
                            }
                        case "15": // total qty per genre
                            {
                                using var r = storageManager1.RunReport(
                                    @"SELECT Genre.[Name], SUM(OrderDetail.Quantity) AS TotalQuantity
                          FROM Record
                          INNER JOIN Genre ON Record.GenreID = Genre.GenreID
                          INNER JOIN OrderDetail ON Record.RecordID = OrderDetail.RecordID
                          GROUP BY Genre.[Name]
                          ORDER BY TotalQuantity DESC");
                                view.DisplayReport(r);
                                break;
                            }
                        case "16":
                            return;

                        default:
                            view.DisplayError11("Invalid input! please choose a number from the list");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    view.DisplayMessage($"Error running report: {ex.Message}\n");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
            }
        }


        private static void HandleUserRecordSubMenu()
        {
            while (true)
            {
                Console.Clear();
                string choice = view.DisplayUserSubMenu();

                switch (choice)
                {
                    case "1":
                        view.DisplayRecords(storageManager1.GetAllRecords());
                        break;
                    case "2":
                        Console.Write("Enter title keyword: ");
                        string titleKeyword = Console.ReadLine();
                        view.DisplayRecords(storageManager1.GetRecordsByTitle(titleKeyword));
                        break;
                    case "3":
                        Console.Write("Enter artist name: ");
                        string artistKeyword = Console.ReadLine();
                        view.DisplayRecords(storageManager1.SearchRecordsByArtist(artistKeyword));
                        break;
                    case "4":
                        FilterRecordsByYearRange();
                        break;
                    case "5":
                        view.DisplayRecords(storageManager1.SortRecordsByTitle());
                        break;
                    case "6":
                        view.DisplayRecords(storageManager1.SortRecordsByYear());
                        break;
                    case "7":
                        return;
                    default:
                        view.DisplayError11("Invalid input. Please choose a number from the list.");
                        break;
                }

                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
            }
        }


        private static void CreateUser()
        {
            while (true)
            {
                // username
                view.DisplayMessage("Enter a new username: ");
                string username = (view.GetInput() ?? "").Trim();

                // password (masked)
                view.DisplayMessage("Enter a password: ");
                string password = (view.GetInput2() ?? "").Trim();

                // empty checks
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    view.DisplayMessage("Your username and password can't be empty, please try again.\n");
                    Console.WriteLine("Continue? (enter)");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                }

              
                if (username.Length >= 100)
                {
                    view.DisplayMessage("Boundary error: you may only have a username with up to *100* characters. Please try again.\n");
                    Console.WriteLine("Continue? (enter)");
                    Console.ReadLine();
                    Console.Clear();

                    break;
                }
                if (password.Length >= 100)
                {
                    view.DisplayMessage("Boundary error: you may only have a password with up to *100* characters. Please try again.\n");
                    Console.WriteLine("Continue? (enter)");
                    Console.ReadLine();
                    Console.Clear();

                    break;
                }

              
                if (storageManager1.UsernameExists(username))
                {
                    view.DisplayMessage("Username is already taken, please try again.\n");
                    Console.WriteLine("Continue? (enter)");
                    Console.ReadLine();
                    Console.Clear();

                    break;
                }

                if (username.Contains("$") || username.Contains("%") || username.Contains("^") ||password.Contains("$") || password.Contains("%") || password.Contains("^"))
                {
     view.DisplayMessage("Usernames/password can't include funny characters like $%^. Please try again.\n");
                    Console.WriteLine("Continue? (enter)");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                }



                string role = "Customer";
                view.DisplayMessage("Is this an admin account? (yes or no): ");
                string ans = (view.GetInput() ?? "").Trim().ToLower();
                if (ans == "yes" || ans == "y")
                    role = "Admin";

               
                User newUser = new User(0, username, password, role);
                int newId = storageManager1.InsertUser(newUser);

                Console.WriteLine($"Account created successfully. ID: {newId}");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                break; 
            }
        }







        private static void InsertNewGenre()
        {
            view.DisplayMessage("Enter new genre name: ");
            string genreName = view.GetInput().Trim();

            if (genreName.Length > 50)
            {
                view.DisplayMessage("Genre name too long. Maximum length is 50 characters.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (string.IsNullOrWhiteSpace(genreName))
            {
                view.DisplayMessage("Genre name can't be empty\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (storageManager1.GenreNameExists(genreName))
            {
                view.DisplayMessage("Genre already exists! please try again.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            Genre genre1 = new Genre(0, genreName);
            int generatedId = storageManager1.InsertGenre(genre1);
            view.DisplayMessage($"New genre inserted with ID: {generatedId}");

            Console.WriteLine("Continue? (enter)");
            Console.ReadLine();
        }

        private static void UpdateGenreName()
        {
            view.DisplayMessage("Enter genre_id to update: ");
            string genreInput = view.GetInput();

            if (string.IsNullOrWhiteSpace(genreInput) || !int.TryParse(genreInput, out int genreId))
            {
                view.DisplayMessage("IDs must be a number.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }
            if (genreId <= 0)
            {
                view.DisplayMessage("IDs must be a positive number (1 or higher).\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }


            view.DisplayMessage("Enter new genre name: ");
            string genreName = view.GetInput();

            if (string.IsNullOrWhiteSpace(genreName))
            {
                view.DisplayMessage("Genre name can't be empty.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (genreName.Length > 50)
            {
                view.DisplayMessage("Genre name can only be up to 50 characters.");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            int rowsAffected = storageManager1.UpdateGenreName(genreId, genreName);

            if (rowsAffected == -2)
                view.DisplayMessage("Genre already exists! please try again.\n");
            else if (rowsAffected == 0)
                view.DisplayMessage("No rows updated (ID not found).\n");
            else
                view.DisplayMessage($"Rows affected: {rowsAffected}\n");

            Console.WriteLine("Continue? (enter)");
            Console.ReadLine();
        }



        private static void DeleteGenreByName()
        {
            view.DisplayMessage("Enter genre you want to delete: ");
            string genreName = view.GetInput();
            int rowsAffected = storageManager1.DeleteGenreByName(genreName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");

            Console.WriteLine("Continue? (enter)");
            Console.ReadLine();
        }


        private static void UpdateCustomer()
        {
            view.DisplayMessage("Enter customer ID to update: ");
            string custInput = view.GetInput();

            if (string.IsNullOrWhiteSpace(custInput) || !int.TryParse(custInput, out int customerId))
            {
                view.DisplayMessage("IDs must be a number, please try again.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }
            if (customerId <= 0)
            {
                view.DisplayMessage("IDs must be a positive number (1 or higher).\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }


            view.DisplayMessage("Enter new first name: ");
            string firstName = view.GetInput().Trim();

            if (string.IsNullOrWhiteSpace(firstName))
            {
                view.DisplayMessage("First name cannot be blank.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (firstName.Length > 100)
            {
                view.DisplayMessage("First name cannot be more than 100 characters.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            view.DisplayMessage("Enter new last name: ");
            string lastName = view.GetInput().Trim();

            if (string.IsNullOrWhiteSpace(lastName))
            {
                view.DisplayMessage("Last name cannot be blank.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (lastName.Length > 100)
            {
                view.DisplayMessage("Last name cannot be more than 100 characters.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            view.DisplayMessage("Enter new email: ");
            string email = view.GetInput().Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                view.DisplayMessage("Email cannot be blank.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }
            if (email.Length > 100)
            {
                view.DisplayMessage("Email cannot be more than 100 characters.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            

            view.DisplayMessage("Enter new phone number: ");
            string phoneNumber = view.GetInput().Trim();

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                view.DisplayMessage("Phone number cannot be blank.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (phoneNumber.Length > 15)
            {
                view.DisplayMessage("Email cannot be more than 15 characters.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }


            int rowsAffected = storageManager1.UpdateCustomer(customerId, firstName, lastName, email, phoneNumber);

            if (rowsAffected == -2)
                view.DisplayMessage("A customer with this email/phone number already exists. Please try again.\n");
            else if (rowsAffected == 0)
                view.DisplayMessage("No rows updated (ID not found).\n");
            else
                view.DisplayMessage($"Rows affected: {rowsAffected}\n");

            Console.WriteLine("Continue? (enter)");
            Console.ReadLine();
        }







        private static void InsertNewCustomer()
        {
            view.DisplayMessage("Enter first name of new customer: ");
            string firstName = view.GetInput();

            if (string.IsNullOrWhiteSpace(firstName))
            {
                view.DisplayMessage("First name is required.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (!firstName.All(c => char.IsLetter(c) || c == ' ' || c == '\''))
            {
                view.DisplayMessage("Name can only contain letters and spaces.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (firstName.Length > 100)
            {
                view.DisplayMessage("First name cannot be more than 100 characters.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }


            view.DisplayMessage("Enter last name of new customer: ");
            string lastName = view.GetInput();

            if (string.IsNullOrWhiteSpace(lastName))
            {
                view.DisplayMessage("Last name is required.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (lastName.Length > 100)
            {
                view.DisplayMessage("Last name cannot be more than 100 characters.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }


            if (!lastName.All(c => char.IsLetter(c) || c == ' ' || c == '\''))
            {
                view.DisplayMessage("Name can only contain letters and spaces.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            view.DisplayMessage("Enter EMAIL of new customer: ");
            string email = view.GetInput();

            if (string.IsNullOrWhiteSpace(email))
            {
                view.DisplayMessage("Email is required.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (email.Length > 100)
            {
                view.DisplayMessage("Email cannot be more than 100 characters.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }


            if (!email.Contains("@") || !email.Contains(".") || email.Length < 5)
            {
                view.DisplayMessage("Invalid email. Please check if you've mispelled anything.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            view.DisplayMessage("Enter phone number of new customer: ");
            string phoneNumber = view.GetInput();

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                view.DisplayMessage("Phone number is required.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (!phoneNumber.All(char.IsDigit) || phoneNumber.Length < 7 || phoneNumber.Length > 15)
            {
                view.DisplayMessage("Phone number must contain only digits and be 7-15 digits long.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (storageManager1.CustomerExists(email, phoneNumber))
            {
                view.DisplayMessage("A customer with this email/phone number already exists. Please try again\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            Customer customer1 = new Customer(0, firstName, lastName, email, phoneNumber);
            int generatedId = storageManager1.InsertCustomer(customer1);

            view.DisplayMessage($"New customer inserted with ID: {generatedId}");

            Console.WriteLine("Continue? (enter)");
            Console.ReadLine();
        }









        private static void DeleteCustomerByName()
        {
            view.DisplayMessage("Enter first name of customer to delete: ");
            string firstName = view.GetInput();

            view.DisplayMessage("Enter last name of customer to delete: ");
            string lastName = view.GetInput();

            int rowsAffected = storageManager1.DeleteCustomerByName(firstName, lastName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");

            Console.WriteLine("Continue? (enter)");
            Console.ReadLine();
        }



        private static void UpdateArtistName()
        {
            view.DisplayMessage("Enter artist ID to update: ");
            string artistInput = view.GetInput();

            if (string.IsNullOrWhiteSpace(artistInput) || !int.TryParse(artistInput, out int artistId))
            {
                view.DisplayMessage("IDs must be a number.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }
            if (artistId <= 0)
            {
                view.DisplayMessage("IDs must be a positive number (1 or higher).\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }


            view.DisplayMessage("Enter new artist name: ");
            string newName = view.GetInput();

            if (string.IsNullOrWhiteSpace(newName))
            {
                view.DisplayMessage("Artist name can't be empty.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }
            if (newName.Length >100)
            {
                view.DisplayMessage("Artist name cannnot be more than 100 in length\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }


            int rowsAffected = storageManager1.UpdateArtistName(artistId, newName);

            if (rowsAffected == -2)
                view.DisplayMessage("This artist already exists.\n");
            else if (rowsAffected == 0)
                view.DisplayMessage("No rows updated (ID not found).\n");
            else
                view.DisplayMessage($"Rows affected: {rowsAffected}\n");

            Console.WriteLine("Continue? (enter)");
            Console.ReadLine();
        }





        private static void InsertNewArtist()
        {
            view.DisplayMessage("Enter artist name: ");
            string artistName = view.GetInput().Trim().ToLower();

            if (string.IsNullOrWhiteSpace(artistName))
            {
                view.DisplayMessage("Artist name can't be empty\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (artistName.Length > 100)
            {
                view.DisplayMessage("Artist name too long, max length is 100 characters\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (storageManager1.ArtistNameExists(artistName))
            {
                view.DisplayMessage("That artist name already exists! please try again.");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            view.DisplayMessage("Enter artist country: ");
            string country = view.GetInput();

            if (string.IsNullOrWhiteSpace(country))
            {
                view.DisplayMessage("Artist country can't be empty\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (country.Length > 50)
            {
                view.DisplayMessage("Country name too long, max length 50 characters\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            Artist artist1 = new Artist(0, artistName, country);
            int generatedId = storageManager1.InsertArtist(artist1);
            view.DisplayMessage($"New artist inserted with ID: {generatedId}");

            Console.WriteLine("Continue? (enter)");
            Console.ReadLine();
        }









        private static void DeleteArtistByName()
        {
            view.DisplayMessage("Enter name of the artist to delete: ");
            string name = view.GetInput();

            int rowsAffected = storageManager1.DeleteArtistByName(name);
            view.DisplayMessage($"Rows affected: {rowsAffected}");

            Console.WriteLine("Continue? (enter)");
            Console.ReadLine();
        }





        private static void InsertNewRecord()
        {
            view.DisplayMessage("Enter record title: ");
            string title = view.GetInput().Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                view.DisplayMessage("Record title is required.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (title.Length > 100)
            {
                view.DisplayMessage("Record title can't be longer than 100 characters.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            view.DisplayMessage("Enter release year: ");
            string yearInput = view.GetInput();
            int year;
            if (!int.TryParse(yearInput, out year))
            {
                view.DisplayMessage("Release year must be a number\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (year < 1800 || year > DateTime.Now.Year + 1)
            {
                view.DisplayMessage("Release year must be realistic (1800 to next year max).\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            view.DisplayMessage("Enter artist ID: ");
            string artistIdInput = view.GetInput();
            if (string.IsNullOrWhiteSpace(artistIdInput) || !int.TryParse(artistIdInput, out int artistId))
            {
                view.DisplayMessage("IDs must be a number.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }
            if (artistId <= 0)
            {
                view.DisplayMessage("IDs must be a positive number (1 or higher).\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (!storageManager1.ArtistExists(artistId))
            {
                view.DisplayMessage("That Artist ID does not exist.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            view.DisplayMessage("Enter genre ID: ");
            string genreIdInput = view.GetInput();
            if (string.IsNullOrWhiteSpace(genreIdInput) || !int.TryParse(genreIdInput, out int genreId))
            {
                view.DisplayMessage("IDs must be a number.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }
            if (genreId <= 0)
            {
                view.DisplayMessage("IDs must be a positive number (1 or higher).\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (!storageManager1.GenreExists(genreId))
            {
                view.DisplayMessage("That Genre ID does not exist.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            Record record1 = new Record(0, title, year, artistId, genreId);
            int generatedId = storageManager1.InsertRecord(record1);

            view.DisplayMessage($"New record inserted with ID: {generatedId}");
            Console.WriteLine("Continue? (enter)");
            Console.ReadLine();
        }



        private static void DeleteRecordByTitle()
        {
            view.DisplayMessage("Enter title of the record to delete: ");
            string title = view.GetInput();

            int rowsAffected = storageManager1.DeleteRecordByTitle(title);
            if (rowsAffected == -1)
            {
                view.DisplayMessage("This record cannot be deleted because it is linked to existing orders.");
            }
            else
            {
                view.DisplayMessage($"Rows affected: {rowsAffected}");
            }

            Console.WriteLine("Continue? (enter)");
            Console.ReadLine();
        }





        private static void UpdateRecordTitle()
        {
            view.DisplayMessage("Enter record ID to update: ");
            string recInput = view.GetInput();

            if (string.IsNullOrWhiteSpace(recInput) || !int.TryParse(recInput, out int recordId))
            {
                view.DisplayMessage("IDs must be a number.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }
            if (recordId <= 0)
            {
                view.DisplayMessage("IDs must be a positive number (1 or higher).\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            view.DisplayMessage("Enter new record title: ");
            string newTitle = view.GetInput();

            if (string.IsNullOrWhiteSpace(newTitle))
            {
                view.DisplayMessage("Title can't be empty.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (newTitle.Length > 100)
            {
                view.DisplayMessage("Title cannot be over 100 characters long.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            int rowsAffected = storageManager1.UpdateRecordTitle(recordId, newTitle);

            if (rowsAffected == 0)
                view.DisplayMessage("No rows updated (ID not found).\n");
            else
                view.DisplayMessage($"Rows affected: {rowsAffected}\n");

            Console.WriteLine("Continue? (enter)");
            Console.ReadLine();
        }










        private static void UpdateOrderStatus()
        {
            view.DisplayMessage("Enter order ID to update: ");
            string orderInput = view.GetInput();
            if (!int.TryParse(orderInput, out int orderId))
            {
                view.DisplayMessage("IDs must be a number.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            view.DisplayMessage("Enter new order status: ");
            string newStatus = view.GetInput().Trim();

            if (string.IsNullOrWhiteSpace(newStatus))
            {
                view.DisplayMessage("Order status is required.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (newStatus.Length > 20)
            {
                view.DisplayMessage("Order status must be 20 characters or less.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            int rowsAffected = storageManager1.UpdateOrderStatus(orderId, newStatus);
            view.DisplayMessage($"Rows affected: {rowsAffected}");

            Console.WriteLine("Continue? (enter)");
            Console.ReadLine();
        }






        private static void InsertNewOrder()
        {
            view.DisplayMessage("Enter customer ID for this order: ");
            string custInput2 = view.GetInput();
            if (string.IsNullOrWhiteSpace(custInput2) || !int.TryParse(custInput2, out int customerId))
            {
                view.DisplayMessage("IDs must be a number.\n");
                return;
            }
            if (customerId <= 0)
            {
                view.DisplayMessage("IDs must be a positive number (1 or higher).\n");
                return;
            }

            view.DisplayMessage("Enter order date (format: 0000-00-00): ");
            string input = view.GetInput();

            DateTime date;
            if (!DateTime.TryParse(input, out date) || date < new DateTime(1900, 1, 1) || date > new DateTime(2100, 12, 31))
            {
                view.DisplayMessage("Invalid date. Please enter a date between 1900-01-01 and 2100-12-31.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            view.DisplayMessage("Enter order status (Processing, Cancelled, Shipped, Delivered): ");
            string status = view.GetInput().Trim();

            if (string.IsNullOrWhiteSpace(status))
            {
                view.DisplayMessage("Order status is required.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            if (status.Length > 20)
            {
                view.DisplayMessage("Order status must be 20 characters or less.\n");
                Console.WriteLine("Continue? (enter)");
                Console.ReadLine();
                return;
            }

            Order order1 = new Order(0, customerId, date, status);
            int generatedId = storageManager1.InsertOrder(order1);

            view.DisplayMessage($"New order inserted with ID: {generatedId}");

            Console.WriteLine("Continue? (enter)");
            Console.ReadLine();
        }







        private static void DeleteOrderById()
        {
            view.DisplayMessage("Enter order ID to delete: ");
            int orderId = view.GetIntInput();

            int rowsAffected = storageManager1.DeleteOrderById(orderId);
            if (rowsAffected == 0)
            {
                view.DisplayMessage($"No order found with ID: {orderId}");
            }
            else
            {
                view.DisplayMessage($"Rows affected: {rowsAffected}");
            }

            Console.WriteLine("Continue? (enter)");
            Console.ReadLine();
        }






    }
}



