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
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\vgkel\\Downloads\\VincentKellett_SQLProj 2 1\\VincentKellett_SQLProj 2\\VincentKellett_SQLProj\\vinylDBTrue\\vinylDBTrue.mdf\";Integrated Security=True;Connect Timeout=30";

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
                        // DeleteGenreByName();
                        break;

                    case "5":
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


    }
}
