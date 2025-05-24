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
            Console.WriteLine("Welcome to my vinyl record");
            Console.WriteLine("------------------------------- ");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View All records in Genre");
            Console.WriteLine("2. Update genre name by genre_id");
            Console.WriteLine("3. Insert a new genre");
            Console.WriteLine("4. Delete a genre by genre_name");
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



