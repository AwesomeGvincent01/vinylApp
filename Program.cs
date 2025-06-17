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
            Console.WriteLine("Hello, Earth!");
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\ac148838\\Downloads\\VincentKellett_SQLProj 2 1\\VincentKellett_SQLProj 2\\VincentKellett_SQLProj\\vinylDBTrue\\vinylDBTrue.mdf\";Integrated Security=True;Connect Timeout=30";

            storageManager1 = new StorageManager(connectionString);
            view = new ConsoleView();

            while (true)
            {
                string choice = view.DisplayMenu();

                switch (choice)
                {
                    case "1":
                        List<Genre> genres = storageManager1.GetAllGenres();
                        view.DisplayGenres(genres);
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
                        List<Customer> customers = storageManager1.GetAllCustomers();
                        view.DisplayCustomers(customers);
                        break;

                    case "6":
                        UpdateCustomerName();
                        break;

                    case "7":
                        InsertNewCustomer();
                        break;

                    case "8":
                        Console.WriteLine("Exiting program...");
                        Console.ReadLine();

                        return;


                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

            }
            storageManager1.CloseConnection();
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
    }
}
