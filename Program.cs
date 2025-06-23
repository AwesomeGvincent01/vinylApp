using vinylApp.Model;
using vinylApp.Repositories;
using vinylApp.View;

namespace vinylApp
{
    public class Program
    {
        private static StorageManager storageManager1;
        private static ConsoleView view;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Admin!");
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\vgkel\\Downloads\\VincentKellett_SQLProj 2 1\\VincentKellett_SQLProj 2\\VincentKellett_SQLProj\\vinylDBTrue\\vinylDBTrue.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=True";

            storageManager1 = new StorageManager(connectionString);
            view = new ConsoleView();



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
                        Console.WriteLine("Exiting program...");
                        storageManager1.CloseConnection();
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

            }


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
                        Console.WriteLine("Invalid option.");
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
                        UpdateCustomerName();
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
                        Console.WriteLine("Invalid option.");
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
                        
                        break;
                    case "2":
                       
                        break;
                    case "3":
                       
                        break;
                    case "4":
                       
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }


        private static void UpdateGenreName()
        {
            view.DisplayMessage("Enter the genre_id to update: ");
            int genreId = view.GetIntInput();
            view.DisplayMessage("Enter the new genre name");
            string genreName = view.GetInput();
            int rowsAffected = storageManager1.UpdateGenreName(genreId, genreName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void InsertNewGenre()
        {
            view.DisplayMessage("Enter the new genre name: ");

            string genreName = view.GetInput();
            Genre genre1 = new Genre(0, genreName);
            int generatedId = storageManager1.InsertGenre(genre1);
            view.DisplayMessage($"New genre inserted with ID: {generatedId}");
        }

        private static void DeleteGenreByName()
        {
            view.DisplayMessage("Enter the genre name to delete: ");
            string genreName = view.GetInput();
            int rowsAffected = storageManager1.DeleteGenreByName(genreName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }


        private static void UpdateCustomerName()
        {
            view.DisplayMessage("Enter the customer_id to update: ");
            int customerId = view.GetIntInput();
            view.DisplayMessage("Enter the new customer name");
            string customerName = view.GetInput();
            int rowsAffected = storageManager1.UpdateCustomerName(customerId, customerName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");






        }



        private static void InsertNewCustomer()
        {
            view.DisplayMessage("Enter the new customer name: ");

            string customerName = view.GetInput();
            Customer customer1 = new Customer(0, customerName);
            int generatedId = storageManager1.InsertCustomer(customer1);
            view.DisplayMessage($"New customer inserted with ID: {generatedId}");
        }


        private static void DeleteCustomerByName()
        {
            view.DisplayMessage("Enter the customer name to delete: ");
            string customerName = view.GetInput();
            int rowsAffected = storageManager1.DeleteCustomerByName(customerName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }
    }
}
