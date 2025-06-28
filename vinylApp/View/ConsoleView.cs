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
        public string DisplayMainMenu()
        {
            Console.WriteLine("\nWelcome to the vinyl record database system");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Genre Menu");
            Console.WriteLine("2. Customer Menu");
            Console.WriteLine("3. Artist Menu [WIP]");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            return Console.ReadLine();
        }


        public string DisplayGenreMenu()
        {
            Console.WriteLine("\n--- Genre Menu ---");
            Console.WriteLine("1. View All Genres");
            Console.WriteLine("2. Update Genre Name by ID");
            Console.WriteLine("3. Insert New Genre");
            Console.WriteLine("4. Delete Genre by Name");
            Console.WriteLine("5. Return to Main Menu");
            Console.Write("Select an option: ");
            return Console.ReadLine();
        }

        public string DisplayCustomerMenu()
        {
            Console.WriteLine("\n--- Customer Menu ---");
            Console.WriteLine("1. View All Customers");
            Console.WriteLine("2. Update Customer First Name by ID");
            Console.WriteLine("3. Insert New Customer");
            Console.WriteLine("4. Delete Customer by Name");
            Console.WriteLine("5. Return to Main Menu");
            Console.Write("Select an option: ");
            return Console.ReadLine();
        }

        public string DisplayArtistMenu()
        {
            Console.WriteLine("\n--- Artist Menu ---");
            Console.WriteLine("1. View All Artists");
            Console.WriteLine("2. Update Artist Name by ID");
            Console.WriteLine("3. Insert New Artist");
            Console.WriteLine("4. Delete Artist by Name");
            Console.WriteLine("5. Return to Main Menu");
            Console.Write("Select an option: ");
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
                Console.WriteLine($"{customer.CustomerId}, {customer.FirstName}, {customer.LastName}");
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



