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
            Console.WriteLine("3. Artist Menu");
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
            Console.WriteLine("1. View Records");
            Console.WriteLine("2. Update Record Title");
            Console.WriteLine("3. Insert New Record");
            Console.WriteLine("4. Delete Record by Title");
            Console.WriteLine("5. Return to Main Menu");
            Console.Write("Select an option: ");
            return Console.ReadLine();
        }

        public string DisplayRecordSubmenu()
        {
            Console.Clear();
            Console.WriteLine("--- How would you like to view records? pick below: ---");
            Console.WriteLine("1. View All Records");
            Console.WriteLine("2. Search by Title");
            Console.WriteLine("3. Search by Artist");
            Console.WriteLine("4. Sort by Title (Ascending)");
            Console.WriteLine("5. Sort by Year (Newest to Oldest)");
            Console.WriteLine("6. Advanced Filters");
            Console.WriteLine("7. Return to Record Menu");
            Console.Write("Select an option: ");
            return Console.ReadLine();
        }


        public string DisplayYearRangeFilterMenu()
        {
            Console.WriteLine("\n--- Filter Record By Year Range ---");
            Console.WriteLine("How would you like to search?");
            Console.WriteLine("1. Specific Range (example: 1990 - 2000)");
            Console.WriteLine("2. Non-Specific (example: all from the 1980s)");
            Console.Write("Select an option: ");
            return Console.ReadLine();
        }

        public void DisplayMessage1(string msg)
        {
            Console.WriteLine(msg);
        }

        public void PromptInputMessage(string msg)
        {
            Console.Write(msg);
        }


        public void DisplayError11(string msg)
        {
            Console.WriteLine(msg);

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

        public string DisplayRecordsSubSubMenu()
        {
            Console.Clear();
            Console.WriteLine("--- Advanced Record Filters ---");
            Console.WriteLine("1. Filter by year range");
            Console.WriteLine("2. Return to previous menu");
            Console.Write("Select an option: ");
            return Console.ReadLine();
        }





        public void DisplayGenres(List<Genre> genres)
        {
            Console.WriteLine("\nID  | Genre Name");
            Console.WriteLine("----|----------------");
            foreach (Genre genre in genres)
            {
                Console.WriteLine($"{genre.GenreId,-4} | {genre.GenreName,-15}");
            }
        }


        public void DisplayCustomers(List<Customer> customers)
        {
            Console.WriteLine("\nID   | First Name        | Last Name         | Email                      | Phone Number");
            Console.WriteLine("-----|--------------------|-------------------|-----------------------------|----------------");
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{customer.CustomerId,-5} | {customer.FirstName,-18} | {customer.LastName,-17} | {customer.Email,-27} | {customer.PhoneNumber}");
            }
        }







        public void DisplayArtists(List<Artist> artists)
        {
            Console.WriteLine("ID   | Name                     | Country");
            Console.WriteLine("-----|--------------------------|--------");

            foreach (var artist in artists)
            {
                Console.WriteLine($"{artist.ArtistId,-5} | {artist.ArtistName,-23} | {artist.Country}");
            }
        }



        public void DisplayRecords(List<Record> records)
        {
            Console.WriteLine("\nID   | Title                   | Year | ArtistID | GenreID");
            Console.WriteLine("-----|--------------------------|------|----------|--------");
            foreach (Record record in records)
            {
                Console.WriteLine($"{record.RecordID,-5} | {record.Title,-25} | {record.ReleaseYear,-4} | {record.ArtistID,-8} | {record.GenreID}");
            }
        }


        public void DisplayRecords(List<string[]> records)
{
    Console.WriteLine("\nID   | Title                   | Year | Artist      | Genre");
    Console.WriteLine("-----|--------------------------|------|-------------|--------");
    foreach (string[] record in records)
    {
        Console.WriteLine($"{record[0],-5} | {record[1],-25} | {record[2],-4} | {record[3],-11} | {record[4]}");
    }
}



        public void DisplayOrders(List<Order> orders)
        {
            Console.WriteLine("\nID   | CustomerID | Date       | Status");
            Console.WriteLine("-----|------------|------------|--------");
            foreach (Order order in orders)
            {
                Console.WriteLine($"{order.OrderID,-5} | {order.CustomerID,-10} | {order.OrderDate,-10} | {order.Status}");
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



