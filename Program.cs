using LanguageExt;
using vinylApp.Model;
using vinylApp.Repositories;
using vinylApp.View;
using vinylApp.vinylApp.Model;

namespace vinylApp
{
    public class Program
    {
        private static StorageManager storageManager1;
        private static ConsoleView view;

        static void Main(string[] args)
        {

            Console.WriteLine("Connecting to the vinyl database system... may take a while, please be patient.");
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\vgkel\\Downloads\\VincentKellett_SQLProj 2 1\\VincentKellett_SQLProj 2\\VincentKellett_SQLProj\\vinylDBTrue\\vinylDBTrue.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=True";


            storageManager1 = new StorageManager(connectionString);
            view = new ConsoleView();






            HandleAccountMenu();
            storageManager1.CloseConnection();
        }

        private static void HandleGenreMenu()
        {
            while (true)
            {
                string choice = view.DisplayGenreMenu();
                switch (choice)
                {
                    case "1":
                        view.DisplayGenres(storageManager1.GetAllGenres());
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

                        Console.WriteLine( "please choose a valid option. If you're confused, the options are number based\n\n " +
                            "" +
                            "For example, if you'd like to update genre name, you can see that it is assigned to the number '2', so, if you would\n like to update genre name, simply input '2' into the program, and so on!\n");
                        Console.ResetColor();
                        break;
                        
                }
            }
        }

        private static void HandleCustomerMenu()
        {
            while (true)
            {
                string choice = view.DisplayCustomerMenu();
                switch (choice)
                {
                    case "1":
                        view.DisplayCustomers(storageManager1.GetAllCustomers());
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
                        break;
                }
            }
        }

        private static void HandleArtistMenu()
        {
            while (true)
            {
                string choice = view.DisplayArtistMenu();
                switch (choice)
                {
                    case "1":
                        view.DisplayArtists(storageManager1.GetAllArtists());
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
                        break;
                }
            }
        }



        private static void HandleRecordMenu()
        {
            bool recordMenuActive = true;
            while (recordMenuActive)
            {
                string choice = view.DisplayRecordMenu();
                switch (choice)
                {
                    case "1":
                        var all = storageManager1.GetAllRecords();
                        view.DisplayRecords(all);
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
                        Console.Write("Enter title keyword to search: ");
                        var keyword = view.GetInput();
                        var results = storageManager1.GetRecordsByTitle(keyword);
                        view.DisplayRecords(results);
                        break;

                    case "6":
                        var sortedByTitle = storageManager1.SortRecordsByTitle();
                        view.DisplayRecords(sortedByTitle);
                        break;

                    case "7":
                        var sortedByYear = storageManager1.SortRecordsByYear();
                        view.DisplayRecords(sortedByYear);
                        break;

                    case "8":
                        recordMenuActive = false;
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
                        break;
                }
            }
        }



        private static void HandleOrderMenu()
        {
            while (true)
            {
                string choice = view.DisplayOrderMenu();
                switch (choice)
                {
                    case "1":
                        view.DisplayOrders(storageManager1.GetAllOrders());
                        break;
                    case "2":
                        UpdateOrderStatus();
                        break;
                    case "3":
                        InsertNewOrder();
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
                            "For example, if you'd like to update order status, you can see that it is assigned to the number '2', so, if you would\n like to update order status, simply input '2' into the program, and so on!\n");
                        Console.ResetColor();
                        break;
                }
            }
        }



        private static User currentUser = null;

        private static void HandleAccountMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Welcome to the vinyl database system! ---\nPlease choose to login or register below");
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
                        break;
                }

                if (currentUser != null)
                {
                    if (currentUser.IsAdmin)
                    {
                        HandleAdminMainMenu();
                    }
                    else
                    {
                        HandleUserMainMenu();
                    }
                }
            }
        }


        private static void Login()
        {
            view.DisplayMessage("Enter username: ");
            string username = view.GetInput();

            view.DisplayMessage("Enter password: ");
            string password = view.GetInput();

            currentUser = storageManager1.GetUserByUsernameAndPassword(username, password);

            if (currentUser != null)
            {
                Console.WriteLine($"\nLogin successful! Welcome, {currentUser.Username} ({(currentUser.IsAdmin ? "Admin" : "User")})");
            }
            else
            {
                Console.WriteLine("Login failed. Invalid username or password.");
            }
        }




        private static void Register()
        {
            view.DisplayMessage("Enter a new username: ");
            string username = view.GetInput();

            view.DisplayMessage("Enter a password: ");
            string password = view.GetInput();

            bool isAdmin = false;


            if (currentUser != null && currentUser.IsAdmin)
            {
                view.DisplayMessage("Is this an admin account? (yes/no): ");
                string isAdminInput = view.GetInput().ToLower();
                isAdmin = (isAdminInput == "yes" || isAdminInput == "y");
            }

            User newUser = new User(0, username, password, isAdmin);
            int newId = storageManager1.InsertUser(newUser);
            Console.WriteLine($"Registration complete. Your user ID is {newId}.");
        }


        private static void HandleAdminMainMenu()
        {
            while (true)
            {
                string choice = view.DisplayMainMenu();
               
                  switch (choice)
                {
                    case "1":
                        HandleGenreMenu();
                        break;
                    case "2":
                        HandleCustomerMenu();
                        break;
                    case "3":
                        HandleArtistMenu();
                        break;
                    case "4":
                        HandleRecordMenu();
                        break;
                    case "5":
                        HandleOrderMenu();
                        break;
                    case "6":
                        CreateUser();
                        break;
                    case "7":
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
                        break;
                }

            }
        }
    

        private static void HandleUserMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- User Menu ---");
                Console.WriteLine("1. View All Records");
                Console.WriteLine("2. View All Genres");
                Console.WriteLine("3. View All Artists");
                Console.WriteLine("4. Logout");
                Console.Write("Choose a option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        view.DisplayRecords(storageManager1.GetAllRecords());
                        break;
                    case "2":
                        view.DisplayGenres(storageManager1.GetAllGenres());
                        break;
                    case "3":
                        view.DisplayArtists(storageManager1.GetAllArtists());
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

                        Console.WriteLine("Hello, user! please choose a valid option. If you're confused, the options are number based.\n\n " +
                            "" +
                            "For example, for the genre menu, you can see that it is assigned to the number '2', so, if you would\n like to access the customer menu, simply input '2' into the program, and so on.\n");
                        Console.ResetColor();
                        break;
                }
            }
        }


        private static void CreateUser()
        {
            Console.Write("Enter a new username: ");
            string username = view.GetInput();


            view.DisplayMessage("Enter a password:");
            string password = view.GetInput();

            view.DisplayMessage("Make this account admin? (y/n):");
            string isAdminInput = view.GetInput().ToLower();
            bool isAdmin = (isAdminInput == "yes" || isAdminInput == "y");

            User newUser = new User(0, username, password, isAdmin);
            int newId = storageManager1.InsertUser(newUser);
            Console.WriteLine($"User created successfully. ID: {newId}");
        }



        private static void UpdateGenreName()
        {
            view.DisplayMessage("Enter genre_id to update: ");
            int genreId = view.GetIntInput();
            view.DisplayMessage("Enter new genre name");
            string genreName = view.GetInput();
            int rowsAffected = storageManager1.UpdateGenreName(genreId, genreName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void InsertNewGenre()
        {
            view.DisplayMessage("Enter new genre name: ");

            string genreName = view.GetInput();
            Genre genre1 = new Genre(0, genreName);
            int generatedId = storageManager1.InsertGenre(genre1);
            view.DisplayMessage($"New genre inserted with ID: {generatedId}");
        }

        private static void DeleteGenreByName()
        {
            view.DisplayMessage("Enter genre you want to delete: ");
            string genreName = view.GetInput();
            int rowsAffected = storageManager1.DeleteGenreByName(genreName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }


        private static void UpdateCustomer()
        {
            view.DisplayMessage("Enter customer ID to update: ");
            int customerId = view.GetIntInput();

            view.DisplayMessage("Enter new first name: ");
            string firstName = view.GetInput();

            view.DisplayMessage("Enter new last name: ");
            string lastName = view.GetInput();

            view.DisplayMessage("Enter new email: ");
            string email = view.GetInput();

            view.DisplayMessage("Enter new phone number: ");
            string phoneNumber = view.GetInput();

            int rowsAffected = storageManager1.UpdateCustomer(customerId, firstName, lastName, email, phoneNumber);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }





        private static void InsertNewCustomer()
        {
            view.DisplayMessage("Enter first name of new customer: ");
            string firstName = view.GetInput();

            view.DisplayMessage("Enter last name of new customer: ");
            string lastName = view.GetInput();

            view.DisplayMessage("Enter EMAIL of new customer: ");
            string email = view.GetInput();

            view.DisplayMessage("Enter phone number of new customer: ");
            string phoneNumber = view.GetInput();

            Customer customer1 = new Customer(0, firstName, lastName, email, phoneNumber);
            int generatedId = storageManager1.InsertCustomer(customer1);

            view.DisplayMessage($"New customer inserted with ID: {generatedId}");
        }




        private static void DeleteCustomerByName()
        {
            view.DisplayMessage("Enter first name of customer to delete: ");
            string firstName = view.GetInput();

            view.DisplayMessage("Enter last name of customer to delete: ");
            string lastName = view.GetInput();

            int rowsAffected = storageManager1.DeleteCustomerByName(firstName, lastName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }



        private static void UpdateArtistName()
        {
            view.DisplayMessage("Enter artist ID to update: ");
            int artistId = view.GetIntInput();

            view.DisplayMessage("Enter new artist name: ");
            string newName = view.GetInput();

            int rowsAffected = storageManager1.UpdateArtistName(artistId, newName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }



        private static void InsertNewArtist()
        {
            view.DisplayMessage("Enter artist name: ");
            string name = view.GetInput();

            view.DisplayMessage("Enter artist country: ");
            string country = view.GetInput();

            Artist artist1 = new Artist(0, name, country);
            int generatedId = storageManager1.InsertArtist(artist1);

            view.DisplayMessage($"New artist inserted with ID: {generatedId}");
        }




        private static void DeleteArtistByName()
        {
            view.DisplayMessage("Enter name of the artist to delete: ");
            string name = view.GetInput();

            int rowsAffected = storageManager1.DeleteArtistByName(name);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }



        private static void UpdateRecordTitle()
        {
            view.DisplayMessage("Enter record ID to update: ");
            int recordId = view.GetIntInput();

            view.DisplayMessage("Enter new record title: ");
            string newTitle = view.GetInput();

            int rowsAffected = storageManager1.UpdateRecordTitle(recordId, newTitle);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }




        private static void InsertNewRecord()
        {
            view.DisplayMessage("Enter record title: ");
            string title = view.GetInput();

            view.DisplayMessage("Enter release year: ");
            int year = view.GetIntInput();

            view.DisplayMessage("Enter Artist ID: ");
            int artistId = view.GetIntInput();

            view.DisplayMessage("Enter Genre ID: ");
            int genreId = view.GetIntInput();

            Record record1 = new Record(0, title, year, artistId, genreId);
            int generatedId = storageManager1.InsertRecord(record1);

            view.DisplayMessage($"New record inserted with ID: {generatedId}");
        }




        private static void DeleteRecordByTitle()
        {
            view.DisplayMessage("Enter title of the record to delete: ");
            string title = view.GetInput();

            int rowsAffected = storageManager1.DeleteRecordByTitle(title);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }







        private static void UpdateOrderStatus()
        {
            view.DisplayMessage("Enter order ID to update: ");
            int orderId = view.GetIntInput();

            view.DisplayMessage("Enter new order status: ");
            string newStatus = view.GetInput();

            int rowsAffected = storageManager1.UpdateOrderStatus(orderId, newStatus);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }





        private static void InsertNewOrder()
        {
            view.DisplayMessage("Enter customer ID for this order: ");
            int customerId = view.GetIntInput();

            view.DisplayMessage("Enter order date (format: 0000-00-00): ");
            string date = view.GetInput();

            view.DisplayMessage("Enter order status (Processing, Cancelled, Shipped, Delivered): ");
            string status = view.GetInput();

            Order order1 = new Order(0, customerId, date, status);
            int generatedId = storageManager1.InsertOrder(order1);

            view.DisplayMessage($"New order inserted with ID: {generatedId}");
        }




        private static void DeleteOrderById()
        {
            view.DisplayMessage("Enter order ID to delete: ");
            int orderId = view.GetIntInput();

            int rowsAffected = storageManager1.DeleteOrderById(orderId);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }





    }
}



