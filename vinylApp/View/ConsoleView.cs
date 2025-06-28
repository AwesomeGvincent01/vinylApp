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
            Console.WriteLine("4. Record Menu");
            Console.WriteLine("5. Order Menu");
            Console.WriteLine("6. Create User/Admin Account");
            Console.WriteLine("7. Logout");
            Console.Write("Select a option: ");

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
            Console.Write("Select a option: ");
            return Console.ReadLine();
        }

        public string DisplayCustomerMenu()
        {
            Console.WriteLine("\n--- Customer Menu ---");
            Console.WriteLine("1. View All Customers");
            Console.WriteLine("2. Update Customer Name by ID");
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
            Console.Write("Select a option: ");
            return Console.ReadLine();
        }


        public string DisplayRecordMenu()
        {
            Console.WriteLine("\n--- Record Menu ---");
            Console.WriteLine("1. View All Records");
            Console.WriteLine("2. Update Record Title");
            Console.WriteLine("3. Insert New Record");
            Console.WriteLine("4. Delete Record by Title");
            Console.WriteLine("5. Return to Main Menu");
            Console.Write("Select a option: ");
            return Console.ReadLine();
        }


        public string DisplayOrderMenu()
        {
            Console.WriteLine("\n--- Order Menu ---");
            Console.WriteLine("1. View All Orders");
            Console.WriteLine("2. Update Order Status");
            Console.WriteLine("3. Insert New Order");
            Console.WriteLine("4. Delete Order by ID");
            Console.WriteLine("5. Return to Main Menu");
            Console.Write("Select a option: ");
            return Console.ReadLine();
        }




        public void DisplayGenres(List<Genre> genres)
        {
            Console.WriteLine("\nID | Name");
            Console.WriteLine("-----------");
            foreach (Genre genre in genres)
            {
                Console.WriteLine($"{genre.GenreId}, {genre.GenreName}");
            }
        }

        public void DisplayCustomers(List<Customer> customers)


        {
            Console.WriteLine("\nID  | Name");
            Console.WriteLine("------------------");

            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{customer.CustomerId}     {customer.FirstName} {customer.LastName}");
            }
        }

        



        public void DisplayArtists(List<Artist> artists)
        {
            Console.WriteLine("ID   | Name               | Country");
            Console.WriteLine("-----------------------------------");

            foreach (Artist artist in artists)
            {
                Console.WriteLine(artist.ArtistId + "    | " + artist.ArtistName + "           | " + artist.Country);
            }
        }


        public void DisplayRecords(List<Record> records)
        {
            Console.WriteLine("\nRecordID    | Title          | ReleaseYear | ArtistID | GenreID");
            Console.WriteLine("-----------------------------------");
            foreach (Record record in records)
            {
                Console.WriteLine($"{record.RecordID},         {record.Title},         {record.ReleaseYear}, ArtistID:                {record.ArtistID}, GenreID: {record.GenreID}");
            }
        }


        public void DisplayOrders(List<Order> orders)
        {
            foreach (Order order in orders)
            {
                Console.WriteLine($"{order.OrderID}, CustomerID: {order.CustomerID}, Date: {order.OrderDate}, Status: {order.Status}");
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



