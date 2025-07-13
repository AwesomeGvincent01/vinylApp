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


        public string DisplayGenreSubmenu()
        {
            Console.WriteLine("\n--- View Genres ---");
            Console.WriteLine("1. iew All Genres");
            Console.WriteLine("2. Search by Name");
            Console.WriteLine("3. Sort alphabetically");
            Console.WriteLine("4. Return to Genre Menu");
            Console.Write("Select an option: ");
            return Console.ReadLine();
        }



        public string DisplayCustomerMenu()
        {
         
            Console.WriteLine("\n--- Customer Menu ---");
            Console.WriteLine("1. View Customers");
            Console.WriteLine("2. Update Customer Name by ID");
            Console.WriteLine("3. Insert New Customer");
            Console.WriteLine("4. Delete Customer by Name");
            Console.WriteLine("5. Return to Main Menu");
            Console.Write("Select an option: ");
            return Console.ReadLine();
        }

        public string DisplayCustomerSubmenu()
        {
            Console.WriteLine("\n--- Customer Filter Menu ---");
            Console.WriteLine("1. View All Customers");
            Console.WriteLine("2. Search by Full Name");
            Console.WriteLine("3. Search by Email");
            Console.WriteLine("4. Search by Phone Number");
            Console.WriteLine("5. Sort by First Name (ascending)");
            Console.WriteLine("6. Sort by Last Name (ascending)");
            Console.WriteLine("7. Return to Main Menu");
            Console.Write("Select a option: ");
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

        public string DisplayArtistSubmenu()
        {
            Console.WriteLine("\n--- View Artists ---");
            Console.WriteLine("1. View Artists");
            Console.WriteLine("2. Search by Name");
            Console.WriteLine("3. Sort Alphabetically");
            Console.WriteLine("4. Return to main Menu");
            Console.Write("Select an option: ");
            return Console.ReadLine();
        }



        public string DisplayRecordMenu()
        {
            Console.Clear();
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
            Console.WriteLine("1. View Orders");
            Console.WriteLine("2. Insert New Orders");
            Console.WriteLine("3. Update Order Status'");
            Console.WriteLine("4. Delete Order");
            Console.WriteLine("5. Return to Main Menu");
            Console.Write("Select an option: ");
            return Console.ReadLine();
        }




        public void DisplayOrderDetails(List<OrderDetail> details)
        {
            Console.WriteLine("\n--- Order Details ---");
            Console.WriteLine("RecordID | Quantity | Price");
            Console.WriteLine("----------------------------");
            foreach (var detail in details)
            {
                Console.WriteLine($"{detail.RecordID}      | {detail.Quantity}       | ${detail.Price:F2}");
            }
        }

        public string DisplayOrder2Menu()
        {
            Console.WriteLine("\n--- Order Menu ---");
            Console.WriteLine("1. View Orders");
            Console.WriteLine("2. Return to  menu");
            Console.Write("Select an option: ");
            return Console.ReadLine();
        }

        public string DisplayOrderSubmenu()
        {
            Console.WriteLine("\n--- View Orders ---");
            Console.WriteLine("1. View All Order");
            Console.WriteLine("2. Search by Customer ID");
            Console.WriteLine("3. Filter by Order Status");
            Console.WriteLine("4. Filter by Date Range");
            Console.WriteLine("5. View Order Details by Order ID");
            Console.WriteLine("6. Return to Order Menu");
            Console.Write("Select an option: ");
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


        public string DisplayUserSubMenu()
        {
            Console.WriteLine("\n--- Record Menu ---");
            Console.WriteLine("1. View All Records");
            Console.WriteLine("2. Search by Title");
            Console.WriteLine("3. Search by Artist");
            Console.WriteLine("4. Filter by Year/Decade");
            Console.WriteLine("5. Sort by Title");
            Console.WriteLine("6. Sort by Year");
            Console.WriteLine("7. Back to User Menu");
            Console.Write("Choose a option: ");
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
            int pageSize = 20;
            int totalPages = (int)Math.Ceiling((double)customers.Count / pageSize);
            int currentPage = 1;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ID   | First Name        | Last Name         | Email                      | Phone Number");
                Console.WriteLine("-----|--------------------|-------------------|-----------------------------|----------------");

                var pageData = customers.Skip((currentPage - 1) * pageSize).Take(pageSize);

                foreach (var c in pageData)
                {
                    Console.WriteLine($"{c.CustomerId,-5} | {c.FirstName,-18} | {c.LastName,-18} | {c.Email,-28} | {c.PhoneNumber}");
                }

                Console.WriteLine("N - Next       P = Previous        Q - Quit");
                Console.WriteLine($"\n{currentPage}/{totalPages}");

                string input = Console.ReadLine();

                if ((input == "n" || input == "N") && currentPage < totalPages)
                {
                    currentPage++;
                }
                else if ((input == "p" || input == "P") && currentPage > 1)
                {
                    currentPage--;
                }
                else if (input == "q" || input == "Q")
                {
                    break;
                }
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
            int pageSize = 20;
            int totalPages = (int)Math.Ceiling((double)records.Count / pageSize);
            int currentPage = 1;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ID   | Title                   | Year | Artist      | Genre");
                Console.WriteLine("-----|--------------------------|------|-------------|--------");

                var pageData = records.Skip((currentPage - 1) * pageSize).Take(pageSize);

                foreach (var r in pageData)
                {
                    Console.WriteLine($"{r.RecordID,-5} | {r.Title,-25} | {r.ReleaseYear,-4} | {r.ArtistName,-11} | {r.GenreName}");
                }

                Console.WriteLine("N - Next       P = Previous        Q - Quit");
                Console.WriteLine($"\n{currentPage}/{totalPages}");

                string input = Console.ReadLine();

                if ((input == "n" || input == "N") && currentPage < totalPages)
                {
                    currentPage++;
                }
                else if ((input == "p" || input == "P") && currentPage > 1)
                {
                    currentPage--;
                }
                else if (input == "q" || input == "Q")
                {
                    break;
                }
            }
        }









        public void DisplayOrders(List<Order> orders)
        {
            int pageSize = 20;
            int totalPages = (int)Math.Ceiling((double)orders.Count / pageSize);
            int currentPage = 1;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ID   | CustomerID | Order Date        | Status");
                Console.WriteLine("-----|------------|-------------------|--------------");

                var pageData = orders.Skip((currentPage - 1) * pageSize).Take(pageSize);

                foreach (var o in pageData)
                {
                    Console.WriteLine($"{o.OrderID,-5} | {o.CustomerID,-10} | {o.OrderDate.ToShortDateString(),-17} | {o.Status}");
                }

                Console.WriteLine("N - Next       P = Previous        Q - Quit");
                Console.WriteLine($"\n{currentPage}/{totalPages}");

                string input = Console.ReadLine();

                if ((input == "n" || input == "N") && currentPage < totalPages)
                {
                    currentPage++;
                }
                else if ((input == "p" || input == "P") && currentPage > 1)
                {
                    currentPage--;
                }
                else if (input == "q" || input == "Q")
                {
                    break;
                }
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



