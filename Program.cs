using vinylApp.Model;
using vinylApp.Repositories;
using vinylApp.View;

namespace vinylApp
{
    public class Program
    {
        private static StorageManager storageManager1;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=" +
                "(localdb)" +
                "\\MSSQLLocalDB;Initial" +
                " Catalog=vinylDB;" +
                "Integrated " +
                "Security=True;Connect " +
                "Timeout=30;Encrypt=False;" +
                "Trust Server Certificate=False;Application " +
                "Intent=ReadWrite;Multi Subnet Failover=False";

            storageManager1 = new StorageManager(connectionString);
            ConsoleView view = new ConsoleView();
            string choice = view.DisplayMenu();

            switch (choice)
            {
                case "1":
                    {
                        List<Genre> genres =
                        storageManager1.GetAllGenres();
                        view.DisplayGenres(genres);
                    }
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
                     exit = true;
                    
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again");
                    break;
            }




        }
    }
}
