
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using vinylApp.Model;
using vinylApp;
using System.Data;

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
                Console.WriteLine("Connection successful");
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
            string sqlString = "SELECT * FROM Customer";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int customerId = Convert.ToInt32(reader["CustomerID"]);
                        string firstName = reader["FirstName"].ToString();
                        string lastName = reader["LastName"].ToString();

                        customers.Add(new Customer(customerId, firstName, lastName));
                    }
                }
            }

            return customers;
        }


        public int UpdateCustomerName(int customerId, string firstName, string lastName)
        {
            string sql = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName WHERE CustomerID = @CustomerId";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                return cmd.ExecuteNonQuery();
            }
        }


        public int InsertCustomer(Customer customerTemp)
        {
            int newId = GetNextCustomerId();

            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Customer (CustomerID, FirstName, LastName) VALUES (@Id, @FirstName, @LastName);", conn))
            {
                cmd.Parameters.AddWithValue("@Id", newId);
                cmd.Parameters.AddWithValue("@FirstName", customerTemp.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customerTemp.LastName);
                cmd.ExecuteNonQuery();
                return newId;
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
    
