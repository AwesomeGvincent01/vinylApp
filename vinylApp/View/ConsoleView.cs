using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vinylApp.Model;

namespace vinylApp.View
{
    public class ConsoleView
    {
        public string DisplayMenu()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Welcome to the vinyl record database system");
            Console.WriteLine("------------------------------- ");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View All records in Genre");
            Console.WriteLine("2. Update genre name by genre_id");
            Console.WriteLine("3. Insert a new genre");
            Console.WriteLine("4. Delete a genre by genre_name");
            Console.WriteLine("5. View All records in Customer");
            Console.WriteLine("6. Update Customer name by customer_id");
            Console.WriteLine("7. Insert a new Customer");
            Console.WriteLine("8. Delete a customer by customer_name");
            Console.WriteLine("9. View all records in Artist");
            Console.WriteLine("------------------------------- ");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();

        }


        public void DisplayGenres(List<Genre> genres)
        {
            foreach (Genre genre in genres)
            {
                Console.WriteLine($"{genre.GenreId}, {genre.GenreName}");
            }
        }

        public void DisplayCustomers(List<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{customer.CustomerId}, {customer.CustomerName}");
            }
        }


        public void DisplayArtists(List<Artist> artists)
        {
            foreach (Artist artist in artists)
            {
                Console.WriteLine($"{artist.ArtistId}, {artist.ArtistName}");
            }
        }



        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        public string GetInput()
        {
            return Console.ReadLine();
        }

        public int GetIntInput()
        {
            return int.Parse(Console.ReadLine() );
        }
    }
}



