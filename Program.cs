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
                        HandleRecordMenu();
                        break;
                    case "5":
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
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }



        private static void HandleRecordMenu()
        {
            while (true)
            {
                string choice = view.DisplayRecordMenu();
                switch (choice)
                {
                    case "1":
                        view.DisplayRecords(storageManager1.GetAllRecords());
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
            view.DisplayMessage("Enter the customer ID to update: ");
            int customerId = view.GetIntInput();

            view.DisplayMessage("Enter the new FIRST name: ");
            string firstName = view.GetInput();

            view.DisplayMessage("Enter the new LAST name: ");
            string lastName = view.GetInput();

            int rowsAffected = storageManager1.UpdateCustomerName(customerId, firstName, lastName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }




        private static void InsertNewCustomer()
        {
            view.DisplayMessage("Enter the FIRST name of the new customer: ");
            string firstName = view.GetInput();

            view.DisplayMessage("Enter the LAST name of the new customer: ");
            string lastName = view.GetInput();

            Customer customer1 = new Customer(0, firstName, lastName);
            int generatedId = storageManager1.InsertCustomer(customer1);

            view.DisplayMessage($"New customer inserted with ID: {generatedId}");
        }



        private static void DeleteCustomerByName()
        {
            view.DisplayMessage("Enter the FIRST name of the customer to delete: ");
            string firstName = view.GetInput();

            view.DisplayMessage("Enter the LAST name of the customer to delete: ");
            string lastName = view.GetInput();

            int rowsAffected = storageManager1.DeleteCustomerByName(firstName, lastName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }



        private static void UpdateArtistName()
        {
            view.DisplayMessage("Enter the artist ID to update: ");
            int artistId = view.GetIntInput();

            view.DisplayMessage("Enter the new artist name: ");
            string newName = view.GetInput();

            int rowsAffected = storageManager1.UpdateArtistName(artistId, newName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }



        private static void InsertNewArtist()
        {
            view.DisplayMessage("Enter the artist name: ");
            string name = view.GetInput();

            view.DisplayMessage("Enter the artist's country: ");
            string country = view.GetInput();

            Artist artist1 = new Artist(0, name, country);
            int generatedId = storageManager1.InsertArtist(artist1);

            view.DisplayMessage($"New artist inserted with ID: {generatedId}");
        }




        private static void DeleteArtistByName()
        {
            view.DisplayMessage("Enter the name of the artist to delete: ");
            string name = view.GetInput();

            int rowsAffected = storageManager1.DeleteArtistByName(name);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }



        private static void UpdateRecordTitle()
        {
            view.DisplayMessage("Enter the record ID to update: ");
            int recordId = view.GetIntInput();

            view.DisplayMessage("Enter the new record title: ");
            string newTitle = view.GetInput();

            int rowsAffected = storageManager1.UpdateRecordTitle(recordId, newTitle);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }




        private static void InsertNewRecord()
        {
            view.DisplayMessage("Enter the record title: ");
            string title = view.GetInput();

            view.DisplayMessage("Enter the release year: ");
            int year = view.GetIntInput();

            view.DisplayMessage("Enter the Artist ID: ");
            int artistId = view.GetIntInput();

            view.DisplayMessage("Enter the Genre ID: ");
            int genreId = view.GetIntInput();

            Record record1 = new Record(0, title, year, artistId, genreId);
            int generatedId = storageManager1.InsertRecord(record1);

            view.DisplayMessage($"New record inserted with ID: {generatedId}");
        }




        private static void DeleteRecordByTitle()
        {
            view.DisplayMessage("Enter the title of the record to delete: ");
            string title = view.GetInput();

            int rowsAffected = storageManager1.DeleteRecordByTitle(title);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }



    }
}



