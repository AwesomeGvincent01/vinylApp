
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using vinylApp.Model;
using vinylApp;
using System.Data;
using vinylApp.Model;

namespace vinylApp.Repositories
{
    public class StorageManager
    {
        private SqlConnection conn;

        public StorageManager(string connectionString)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Connection successful");
                Console.ResetColor();

            }
            catch (SqlException e)
            {
                Console.WriteLine("The connection was not successful\n");
                Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.Message);
            }
        }



        public List<Genre> GetAllGenres()
        {
            List<Genre> genres = new List<Genre>();
            string sqlString = "SELECT * FROM Genre";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int genreId = Convert.ToInt32(reader["GenreID"]);
                        string genreName = reader["Name"].ToString();
                        genres.Add(new Genre(genreId, genreName));
                    }
                }
            }

            return genres;


        }


        public bool GenreNameExists(string name)
        {
            string sql = "SELECT COUNT(*) FROM Genre WHERE Name = @name";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", name.Trim());
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }


        public List<Genre> SearchGenresByName(string nameKeyword)
        {
            List<Genre> genres = new List<Genre>();
            string query = "SELECT * FROM Genre WHERE Name LIKE @test";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@test", "%" + nameKeyword + "%");
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        genres.Add(new Genre(
                            Convert.ToInt32(reader["GenreID"]),
                            reader["Name"].ToString()
                        ));
                    }
                }
            }

            return genres;
        }

        public List<Genre> SortGenresByName()
        {
            List<Genre> genres = new List<Genre>();
            string query = "SELECT * FROM Genre ORDER BY Name ASC";

            using (SqlCommand command = new SqlCommand(query, conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    genres.Add(new Genre(
                        Convert.ToInt32(reader["GenreID"]),
                        reader["Name"].ToString()
                    ));
                }
            }

            return genres;
        }




        public int UpdateGenreName(int genreId, string genreName)
        {
            string sql = "UPDATE Genre SET Name = @GenreName WHERE GenreID = @GenreId";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@GenreName", genreName);
                cmd.Parameters.AddWithValue("@GenreId", genreId);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertGenre(Genre genreTemp)
        {
            int newId = GetNextGenreId(); 

            using (SqlCommand cmd =
                   new SqlCommand("INSERT INTO Genre (GenreID, Name) VALUES (@Id, @Name);",
                                  conn))
            {
                cmd.Parameters.AddWithValue("@Id", newId);
                cmd.Parameters.AddWithValue("@Name", genreTemp.GenreName);
                cmd.ExecuteNonQuery();
                return newId; 
            }
        }


        public int DeleteGenreByName(string genreName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Genre WHERE Name = @GenreName", conn))
                {
                    cmd.Parameters.AddWithValue("@GenreName", genreName);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("REFERENCE constraint"))
                {
                    Console.WriteLine("This genre cannot be deleted as its still linked to one or more records.");
                }
                else
                {
                    Console.WriteLine("Unexpected error occurred: " + ex.Message);
                }
                return 0;
            }
        }


        private int GetNextGenreId()
        {
            using (SqlCommand cmd =
                   new SqlCommand("SELECT ISNULL(MAX(GenreID),0)+1 FROM Genre", conn))
            {
                return (int)cmd.ExecuteScalar(); 
            }
        }





        //customer

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            string query = "SELECT * FROM Customer";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["CustomerID"]);
                    string firstName = reader["FirstName"].ToString();
                    string lastName = reader["LastName"].ToString();
                    string email = reader["Email"].ToString();
                    string phone = reader["PhoneNumber"].ToString();

                    customers.Add(new Customer(id, firstName, lastName, email, phone));
                }
            }
            return customers;
        }

        public List<Customer> SearchCustomersByFullName(string firstName, string lastName)
        {
            List<Customer> results = new List<Customer>();
            string query = "SELECT * FROM Customer WHERE FirstName LIKE @FirstName AND LastName LIKE @LastName";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@FirstName", "%" + firstName + "%");
                cmd.Parameters.AddWithValue("@LastName", "%" + lastName + "%");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(CreateCustomerFromReader(reader));
                    }
                }
            }
            return results;
        }

        public List<Customer> SearchCustomersByEmail(string email)
        {
            List<Customer> results = new List<Customer>();
            string query = "SELECT * FROM Customer WHERE Email LIKE @Email";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", "%" + email + "%");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(CreateCustomerFromReader(reader));
                    }
                }
            }
            return results;
        }

        public List<Customer> SearchCustomersByPhone(string phone)
        {
            List<Customer> results = new List<Customer>();
            string query = "SELECT * FROM Customer WHERE PhoneNumber LIKE @Phone";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Phone", "%" + phone + "%");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(CreateCustomerFromReader(reader));
                    }
                }
            }
            return results;
        }

        public List<Customer> SortCustomersByFirstName()
        {
            return RunCustomerSortQuery("SELECT * FROM Customer ORDER BY FirstName ASC");
        }

        public List<Customer> SortCustomersByLastName()
        {
            return RunCustomerSortQuery("SELECT * FROM Customer ORDER BY LastName ASC");
        }

        private List<Customer> RunCustomerSortQuery(string query)
        {
            List<Customer> customers = new List<Customer>();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    customers.Add(CreateCustomerFromReader(reader));
                }
            }
            return customers;
        }

        private Customer CreateCustomerFromReader(SqlDataReader reader)
        {
            return new Customer(
                Convert.ToInt32(reader["CustomerID"]),
                reader["FirstName"].ToString(),
                reader["LastName"].ToString(),
                reader["Email"].ToString(),
                reader["PhoneNumber"].ToString()
            );
        }




        public int UpdateCustomer(int customerId, string firstName, string lastName, string email, string phoneNumber)
        {
            string sql = @"UPDATE Customer 
                   SET FirstName = @FirstName, LastName = @LastName, 
                       Email = @Email, PhoneNumber = @PhoneNumber 
                   WHERE CustomerID = @CustomerId";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                return cmd.ExecuteNonQuery();
            }
        }



        public int InsertCustomer(Customer customerTemp)
        {
            int newId = GetNextCustomerId();

            string sql = @"INSERT INTO Customer (CustomerID, FirstName, LastName, Email, PhoneNumber)
                   VALUES (@Id, @FirstName, @LastName, @Email, @PhoneNumber);";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", newId);
                cmd.Parameters.AddWithValue("@FirstName", customerTemp.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customerTemp.LastName);
                cmd.Parameters.AddWithValue("@Email", customerTemp.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", customerTemp.PhoneNumber);
                cmd.ExecuteNonQuery();
            }

            return newId;
        }



        public bool CustomerExists(string email, string phoneNumber)
        {
            string sql = "SELECT COUNT(*) FROM Customer WHERE Email = @Email OR PhoneNumber = @PhoneNumber";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }





        public int DeleteCustomerByName(string firstName, string lastName)
        {
            using (SqlCommand cmd = new SqlCommand(
                "SELECT CustomerID FROM Customer WHERE FirstName = @FirstName AND LastName = @LastName", conn))
            {
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);

                object result = cmd.ExecuteScalar();
                if (result == null)
                {
                    Console.WriteLine("Customer not found.");
                    return 0;
                }

                int customerId = Convert.ToInt32(result);

                if (CustomerHasOrders(customerId))
                {
                    Console.WriteLine("This customer cannot be deleted because they have existing orders.");
                    return 0;
                }

                using (SqlCommand deleteCmd = new SqlCommand("DELETE FROM Customer WHERE CustomerID = @CustomerID", conn))
                {
                    deleteCmd.Parameters.AddWithValue("@CustomerID", customerId);
                    return deleteCmd.ExecuteNonQuery();
                }
            }
        }





        private int GetNextCustomerId()
        {
            using (SqlCommand cmd =
                   new SqlCommand("SELECT ISNULL(MAX(CustomerID),0)+1 FROM Customer", conn))
            {
                return (int)cmd.ExecuteScalar();
            }
        }




        public bool CustomerHasOrders(int customerId)
        {
            string sql = "SELECT COUNT(*) FROM [Order] WHERE CustomerID = @CustomerID";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }





        public int GetCustomerIdByName(string name)
        {
            string sql = "SELECT CustomerID FROM Customer WHERE FirstName = @Name";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }






        //Artist


        public List<Artist> GetAllArtists()
        {
            List<Artist> artists = new List<Artist>();
            string sqlString = "SELECT * FROM Artist";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int artistId = Convert.ToInt32(reader["ArtistID"]);
                        string artistName = reader["ArtistName"].ToString();
                        string country = reader["Country"].ToString();
                        artists.Add(new Artist(artistId, artistName, country));
                    }
                }
            }

            return artists;
        }



        public bool ArtistNameExists(string name)
        {
            string sql = "SELECT COUNT(*) FROM Artist WHERE ArtistName = @artistName";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@artistName", name.Trim().ToLower());
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }

        }




        public List<Artist> SearchArtistsByName(string nameKeyword)
        {
            List<Artist> artists = new List<Artist>();
            string query = "SELECT * FROM Artist WHERE ArtistName LIKE @test";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@test", "%" + nameKeyword + "%");
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        artists.Add(new Artist(
    Convert.ToInt32(reader["ArtistID"]),
    reader["ArtistName"].ToString(),
    reader["Country"].ToString()
));

                    }
                }
            }

            return artists;
        }

        public List<Artist> SortArtistsByName()
        {
            List<Artist> artists = new List<Artist>();
            string query = "SELECT * FROM Artist ORDER BY ArtistName ASC";

            using (SqlCommand command = new SqlCommand(query, conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    artists.Add(new Artist(
    Convert.ToInt32(reader["ArtistID"]),
    reader["ArtistName"].ToString(),
    reader["Country"].ToString()
));

                }
            }

            return artists;
        }



        public int UpdateArtistName(int artistId, string newName)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Artist SET ArtistName = @Name WHERE ArtistID = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Name", newName);
                cmd.Parameters.AddWithValue("@Id", artistId);
                return cmd.ExecuteNonQuery();
            }
        }




        public int InsertArtist(Artist artistTemp)
        {
            int newId = GetNextArtistId();

            using (SqlCommand cmd = new SqlCommand("INSERT INTO Artist (ArtistID, ArtistName, Country) VALUES (@Id, @Name, @Country);", conn))
            {
                cmd.Parameters.AddWithValue("@Id", newId);
                cmd.Parameters.AddWithValue("@Name", artistTemp.ArtistName);
                cmd.Parameters.AddWithValue("@Country", artistTemp.Country);
                cmd.ExecuteNonQuery();
                return newId;
            }
        }

        private int GetNextArtistId()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(ArtistID),0)+1 FROM Artist", conn))
            {
                return (int)cmd.ExecuteScalar();
            }
        }




        public int DeleteArtistByName(string artistName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Artist WHERE ArtistName = @Name", conn))
                {
                    cmd.Parameters.AddWithValue("@Name", artistName);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("REFERENCE constraint"))
                {
                    Console.WriteLine("This artist can't be deleted as theres still records linked to them.");
                }
                else
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                }
                return 0;
            }
        }





        public List<Record> GetRecordsByTitle(string keyword)
        {
            List<Record> records = new List<Record>();
            string sql = "SELECT * FROM Record WHERE Title LIKE @Keyword";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["RecordID"]);
                        string title = reader["Title"].ToString();
                        int year = Convert.ToInt32(reader["ReleaseYear"]);
                        int artistId = Convert.ToInt32(reader["ArtistID"]);
                        int genreId = Convert.ToInt32(reader["GenreID"]);
                        records.Add(new Record(id, title, year, artistId, genreId));
                    }
                }
            }
            return records;
        }

        public List<Record> GetAllRecords()
        {
            List<Record> records = new List<Record>();

            string query = @"
    SELECT Record.RecordID, Record.Title, Record.ReleaseYear,
           Record.ArtistID, Record.GenreID,
           Artist.ArtistName AS ArtistName,
           Genre.Name AS GenreName
    FROM Record
    JOIN Artist ON Record.ArtistID = Artist.ArtistID
    JOIN Genre ON Record.GenreID = Genre.GenreID
    ORDER BY Record.RecordID;";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Record record = new Record()
                        {
                            RecordID = Convert.ToInt32(reader["RecordID"]),
                            Title = reader["Title"].ToString(),
                            ReleaseYear = Convert.ToInt32(reader["ReleaseYear"]),
                            ArtistID = Convert.ToInt32(reader["ArtistID"]),
                            GenreID = Convert.ToInt32(reader["GenreID"]),
                            ArtistName = reader["ArtistName"].ToString(),
                            GenreName = reader["GenreName"].ToString()
                        };

                        records.Add(record);
                    }
                }
            }

            return records;
        }




        public List<Record> SearchRecordsByArtist(string keyword)
        {
            var records = new List<Record>();

            string sql = @"
        SELECT Record.RecordID, Record.Title, Record.ReleaseYear,
               Record.ArtistID, Record.GenreID,
               Artist.ArtistName AS ArtistName,
               Genre.Name AS GenreName
        FROM Record
        JOIN Artist ON Record.ArtistID = Artist.ArtistID
        JOIN Genre ON Record.GenreID = Genre.GenreID
        WHERE Artist.ArtistName LIKE @input
        ORDER BY Record.Title;";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@input", "%" + keyword + "%");
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var record = new Record()
                {
                    RecordID = Convert.ToInt32(reader["RecordID"]),
                    Title = reader["Title"].ToString(),
                    ReleaseYear = Convert.ToInt32(reader["ReleaseYear"]),
                    ArtistID = Convert.ToInt32(reader["ArtistID"]),
                    GenreID = Convert.ToInt32(reader["GenreID"]),
                    ArtistName = reader["ArtistName"].ToString(),
                    GenreName = reader["GenreName"].ToString()
                };
                records.Add(record);
            }

            return records;
        }





       

        private int GetNextRecordId()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(RecordID),0)+1 FROM Record", conn))
            {
                return (int)cmd.ExecuteScalar();
            }
        }


        public bool ArtistExists(int artistId)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Artist WHERE ArtistID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", artistId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public bool GenreExists(int genreId)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Genre WHERE GenreID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", genreId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public bool RecordExists(int recordId)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Record WHERE RecordID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", recordId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public int InsertRecord(Record record)
        {
            int newId = GetNextRecordId();
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Record (RecordID, Title, ReleaseYear, ArtistID, GenreID) VALUES (@Id, @Title, @Year, @ArtistId, @GenreId);", conn))
            {
                cmd.Parameters.AddWithValue("@Id", newId);
                cmd.Parameters.AddWithValue("@Title", record.Title);
                cmd.Parameters.AddWithValue("@Year", record.ReleaseYear);
                cmd.Parameters.AddWithValue("@ArtistId", record.ArtistID);
                cmd.Parameters.AddWithValue("@GenreId", record.GenreID);
                cmd.ExecuteNonQuery();
                return newId;
            }
        }

        public int DeleteRecordByTitle(string title)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Record WHERE Title = @Title", conn))
                {
                    cmd.Parameters.AddWithValue("@Title", title);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) 
                    return -1;
                throw;
            }
        }

        public int UpdateRecordTitle(int recordId, string newTitle)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Record SET Title = @Title WHERE RecordID = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Title", newTitle);
                cmd.Parameters.AddWithValue("@Id", recordId);
                return cmd.ExecuteNonQuery();
            }
        }


        public List<Record> SortRecordsByTitle()
        {
            var records = new List<Record>();
            string sql = "SELECT * FROM Record ORDER BY Title ASC";
            using var cmd = new SqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                records.Add(new Record(
                    Convert.ToInt32(reader["RecordID"]),
                    reader["Title"].ToString(),
                    Convert.ToInt32(reader["ReleaseYear"]),
                    Convert.ToInt32(reader["ArtistID"]), 
                    Convert.ToInt32(reader["GenreID"])
                ));
            }
            return records;
        }

        public List<Record> SortRecordsByYear()
        {
            var records = new List<Record>();
            string sql = "SELECT * FROM Record ORDER BY ReleaseYear ASC";
            using var cmd = new SqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                records.Add(new Record(
                    Convert.ToInt32(reader["RecordID"]),
                    reader["Title"].ToString(),
                    Convert.ToInt32(reader["ReleaseYear"]),
                    Convert.ToInt32(reader["ArtistID"]),
                    Convert.ToInt32(reader["GenreID"])
                ));
            }
            return records;
        }


        public List<Record> GetRecordsByYearRange(int startYear, int endYear)
        {
            List<Record> records = new List<Record>();

            string query = @"
        SELECT Record.RecordID, Record.Title, Record.ReleaseYear,
               Record.ArtistID, Record.GenreID,
               Artist.ArtistName AS ArtistName,
               Genre.Name AS GenreName
        FROM Record
        JOIN Artist ON Record.ArtistID = Artist.ArtistID
        JOIN Genre ON Record.GenreID = Genre.GenreID
        WHERE Record.ReleaseYear BETWEEN @startYear AND @endYear
        ORDER BY Record.ReleaseYear;";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@startYear", startYear);
                cmd.Parameters.AddWithValue("@endYear", endYear);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Record record = new Record()
                        {
                            RecordID = Convert.ToInt32(reader["RecordID"]),
                            Title = reader["Title"].ToString(),
                            ReleaseYear = Convert.ToInt32(reader["ReleaseYear"]),
                            ArtistID = Convert.ToInt32(reader["ArtistID"]),
                            GenreID = Convert.ToInt32(reader["GenreID"]),
                            ArtistName = reader["ArtistName"].ToString(),
                            GenreName = reader["GenreName"].ToString()
                        };

                        records.Add(record);
                    }
                }
            }

            return records;
        }




        public List<Order> GetOrders(User viewer)
        {
            List<Order> orders = new List<Order>();

            string sql = viewer.Role == "Customer"
                ? "SELECT * FROM [Order] WHERE CustomerID = @cid"
                : "SELECT * FROM [Order]";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (viewer.Role == "Customer")
                    cmd.Parameters.AddWithValue("@cid", viewer.UserID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(readordertest(reader));
                    }
                }
            }

            return orders;
        }





        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            List<Order> orders = new List<Order>();
            string query = "SELECT * FROM [Order] WHERE CustomerID = @CustomerID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int orderId = Convert.ToInt32(reader["OrderID"]);
                        DateTime date = (DateTime)reader["OrderDate"];
                        string status = reader["Status"].ToString();

                        orders.Add(new Order(orderId, customerId, date, status));
                    }
                }
            }
            return orders;
        }

        public List<Order> GetOrdersByStatus(string status)
        {
            List<Order> orders = new List<Order>();
            string query = "SELECT * FROM [Order] WHERE Status = @Status";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Status", status);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int orderId = Convert.ToInt32(reader["OrderID"]);
                        int customerId = Convert.ToInt32(reader["CustomerID"]);
                        DateTime date = (DateTime)reader["OrderDate"];
                        orders.Add(new Order(orderId, customerId, date, status));
                    }
                }
            }
            return orders;
        }

        public List<Order> GetOrdersByDateRange(DateTime start, DateTime end)
        {
            List<Order> orders = new List<Order>();
            string query = "SELECT * FROM [Order] WHERE OrderDate BETWEEN @Start AND @End";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Start", start);
                cmd.Parameters.AddWithValue("@End", end);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int orderId = Convert.ToInt32(reader["OrderID"]);
                        int customerId = Convert.ToInt32(reader["CustomerID"]);
                        DateTime date = (DateTime)reader["OrderDate"];
                        string status = reader["Status"].ToString();
                        orders.Add(new Order(orderId, customerId, date, status));
                    }
                }
            }
            return orders;
        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            List<OrderDetail> details = new List<OrderDetail>();
            string query = "SELECT * FROM OrderDetail WHERE OrderID = @OrderID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int orderDetailId = Convert.ToInt32(reader["OrderDetailID"]);
                        int recordId = Convert.ToInt32(reader["RecordID"]);
                        int quantity = Convert.ToInt32(reader["Quantity"]);
                        decimal price = (decimal)reader["Price"];
                        details.Add(new OrderDetail(orderDetailId, orderId, recordId, quantity, price));
                    }
                }
            }
            return details;
        }


        public int InsertOrder(Order orderTemp)
        {
            int newId = GetNextOrderId();

            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO [Order] (OrderID, CustomerID, OrderDate, Status) VALUES (@Id, @CustomerId, @Date, @Status);", conn))
            {
                cmd.Parameters.AddWithValue("@Id", newId);
                cmd.Parameters.AddWithValue("@CustomerId", orderTemp.CustomerID);
                cmd.Parameters.AddWithValue("@Date", orderTemp.OrderDate);
                cmd.Parameters.AddWithValue("@Status", orderTemp.Status);
                cmd.ExecuteNonQuery();
                return newId;
            }
        }


        public int UpdateOrderStatus(int orderId, string newStatus)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE [Order] SET Status = @Status WHERE OrderID = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Status", newStatus);
                cmd.Parameters.AddWithValue("@Id", orderId);
                return cmd.ExecuteNonQuery();
            }
        }



        public int DeleteOrderById(int orderId)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM [Order] WHERE OrderID = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", orderId);
                return cmd.ExecuteNonQuery();
            }
        }


        private int GetNextOrderId()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(OrderID),0)+1 FROM [Order]", conn))
            {
                return (int)cmd.ExecuteScalar();
            }
        }





        public User GetUserByUsernameAndPassword(string username, string password)
        {
            string sql = "SELECT * FROM [User] WHERE Username = @u AND Password = @p";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        int id = Convert.ToInt32(r["UserID"]);
                        string uname = r["Username"].ToString();
                        string pword = r["Password"].ToString();
                        string role = r["Role"].ToString();
                        return new User(id, uname, pword, role);
                    }
                }
            }
            return null;
        }


        public bool UsernameExists(string username)
        {
            string sql = "SELECT COUNT(*) FROM [User] WHERE Username = @u";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }



        public int InsertUser(User user)
        {
            string sql = "INSERT INTO [User] (Username, Password, Role) VALUES (@u, @p, @r); SELECT SCOPE_IDENTITY();";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@u", user.Username);
                cmd.Parameters.AddWithValue("@p", user.Password);
                cmd.Parameters.AddWithValue("@r", user.Role);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        private int GetNextUserId()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(UserID),0)+1 FROM [User]", conn))
            {
                return (int)cmd.ExecuteScalar();
            }
        }



        /* TO BE ADDED

public int InsertUser(string username, string pass, bool admin)
{
    string sql = "INSERT INTO [User] (Username,Password,IsAdmin) VALUES ('"
                 + username + "','" + pass + "'," + (admin ? 1 : 0) + ")";
    using (SqlCommand cmd = new SqlCommand(sql, conn))
    {
        return cmd.ExecuteNonQuery();
    }
}

public bool CheckLogin(string user, string pass])
{
    string q = "SELECT COUNT(*) FROM [User] WHERE Username='"
               + user + "' AND Password='" + pass + "'";
    using (SqlCommand c = new SqlCommand(q, conn))
    {
        int hits = (int)c.ExecuteScalar();
        return hits == 1;
    }
}

*/



        private Order readordertest(SqlDataReader reader)
        {
            return new Order(
                Convert.ToInt32(reader["OrderID"]),
                Convert.ToInt32(reader["CustomerID"]),
                (DateTime)reader["OrderDate"],
                reader["Status"].ToString()
            );
        }


        public void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                Console.WriteLine("Connection closed");
            }
        }

        
    }
}
    
