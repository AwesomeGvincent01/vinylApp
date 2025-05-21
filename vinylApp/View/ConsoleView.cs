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
        public string? DisplayMenu()
        {
            Console.WriteLine("Welcome to my vinyl record");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View All records in Genre");
            Console.WriteLine("2. Update genre name by genre_id");
            Console.WriteLine("Insert a new genre");
            Console.WriteLine("Delete a genre by genre_name");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();

        }


        public void DisplayGenres(List<Genre> genres)
        {
            foreach (Genre genre in genres)
            {
                Console.WriteLine($"{genre.GenreId}," +
                    $"{genre.GenreName}");
            }
            {
                Console.WriteLine($"{genre.genreName}, {genre.genreName}");
            }
        }
    }
}
