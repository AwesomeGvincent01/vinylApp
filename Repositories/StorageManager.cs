
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using vinylApp.Model;
using vinylApp;
using System.Data;
using vinylApp.vinylApp.Model;

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
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Genre WHERE Name = @GenreName", conn))
            {
                cmd.Parameters.AddWithValue("@GenreName", genreName);
                return cmd.ExecuteNonQuery();
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
            using (SqlCommand command = new SqlCommand(query, conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["CustomerID"];
                    string firstName = reader["FirstName"].ToString();
                    string lastName = reader["LastName"].ToString();
                    string email = reader["Email"].ToString();
                    string phone = reader["PhoneNumber"].ToString();

                    customers.Add(new Customer(id, firstName, lastName, email, phone));
                }
            }
            return customers;
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
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Artist WHERE ArtistName = @Name", conn))
            {
                cmd.Parameters.AddWithValue("@Name", artistName);
                return cmd.ExecuteNonQuery();
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

        public List<string[]> GetAllRecords()
        {
            List<string[]> records = new List<string[]>();

            string query = @"
        SELECT Record.RecordID, Record.Title, Record.ReleaseYear, 
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
                        string[] row = new string[]
                        {
                    reader["RecordID"].ToString(),
                    reader["Title"].ToString(),
                    reader["ReleaseYear"].ToString(),
                    reader["ArtistName"].ToString(),
                    reader["GenreName"].ToString()
                        };
                        records.Add(row);
                    }
                }
            }

            return records;
        }



        public List<string[]> SearchRecordsByArtist(string keyword)
        {
            var records = new List<string[]>();
            string sql = @"
      SELECT Record.RecordID, Record.Title, Record.ReleaseYear, Artist.ArtistName AS ArtistName, Genre.Name      AS GenreName
FROM Record
      JOIN Artist ON Record.ArtistID = Artist.ArtistID
      JOIN Genre ON Record.GenreID  = Genre.GenreID
      WHERE Artist.ArtistName LIKE @input
      ORDER BY Record.Title;";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@input", "%" + keyword + "%");
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                records.Add(new[] {
          reader["RecordID"].ToString(),
          reader["Title"].ToString(),
          reader["ReleaseYear"].ToString(),
          reader["ArtistName"].ToString(),
          reader["GenreName"].ToString()
        });
            }

            return records; 
        }


        public List<string[]> GetRecordsByYearRange(int startYear, int endYear)
        {
            List<string[]> records = new List<string[]>();

            string query = @"
        SELECT Record.RecordID, Record.Title, Record.ReleaseYear, Artist.ArtistName, Genre.Name
        FROM Record JOIN Artist ON Record.ArtistID = Artist.ArtistID
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
                        string[] row = new string[]
                        {
                    reader["RecordID"].ToString(),
                    reader["Title"].ToString(),
                    reader["ReleaseYear"].ToString(),
                    reader["ArtistName"].ToString(),
                    reader["Name"].ToString()
                        };
                        records.Add(row);
                    }
                }
            }

            return records;
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

        private int GetNextRecordId()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(RecordID),0)+1 FROM Record", conn))
            {
                return (int)cmd.ExecuteScalar();
            }
        }


        public int InsertRecord(Record recordTemp)
        {
            int newId = GetNextRecordId();

            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Record (RecordID, Title, ReleaseYear, ArtistID, GenreID) VALUES (@Id, @Title, @Year, @ArtistId, @GenreId);", conn))
            {
                cmd.Parameters.AddWithValue("@Id", newId);
                cmd.Parameters.AddWithValue("@Title", recordTemp.Title);
                cmd.Parameters.AddWithValue("@Year", recordTemp.ReleaseYear);
                cmd.Parameters.AddWithValue("@ArtistId", recordTemp.ArtistID);
                cmd.Parameters.AddWithValue("@GenreId", recordTemp.GenreID);
                cmd.ExecuteNonQuery();
                return newId;
            }
        }
        



        public int DeleteRecordByTitle(string title)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Record WHERE Title = @Title", conn))
            {
                cmd.Parameters.AddWithValue("@Title", title);
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
                    (int)reader["RecordID"],
                    reader["Title"].ToString(),
                    (int)reader["ReleaseYear"],
                    (int)reader["ArtistID"],
                    (int)reader["GenreID"]
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
                    (int)reader["RecordID"],
                    reader["Title"].ToString(),
                    (int)reader["ReleaseYear"],
                    (int)reader["ArtistID"],
                    (int)reader["GenreID"]
                ));
            }
            return records;
        }



        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            string sql = "SELECT * FROM [Order]";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int orderId = Convert.ToInt32(reader["OrderID"]);
                        int customerId = Convert.ToInt32(reader["CustomerID"]);
                        string orderDate = reader["OrderDate"].ToString();
                        string status = reader["Status"].ToString();

                        orders.Add(new Order(orderId, customerId, orderDate, status));
                    }
                }
            }

            return orders;
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
            string sql = "SELECT * FROM [User] WHERE Username = @username AND Password = @password;";

            ;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int userId = Convert.ToInt32(reader["UserID"]);
                        string uname = reader["Username"].ToString();
                        string pword = reader["Password"].ToString();
                        bool isAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                        return new User(userId, uname, pword, isAdmin);
                    }
                }
            }
            return null;
        }

        public int InsertUser(User user)
        {
            int newId = GetNextUserId();
            string sql = "INSERT INTO [User] (Username, Password, IsAdmin) VALUES (@Username, @Password, @IsAdmin)";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
        
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
                cmd.ExecuteNonQuery();
                return newId;
            }
        }

        private int GetNextUserId()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(UserID),0)+1 FROM [User]", conn))
            {
                return (int)cmd.ExecuteScalar();
            }
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
    
