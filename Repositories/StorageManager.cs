
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





        //test

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
                        string customerName = reader["FirstName"].ToString();
                        customers.Add(new Customer(customerId, customerName));
                    }
                }
            }

            return customers;


        }

        public int UpdateCustomerName(int customerId, string customerName)
        {
            string sql = "UPDATE Customer SET FirstName = @FirstName WHERE CustomerID = @CustomerId";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@FirstName", customerName);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                return cmd.ExecuteNonQuery();
            }
        }

       public int InsertCustomer(Customer customerTemp)
        {
            int newId = GetNextCustomerId();

            using (SqlCommand cmd =
                   new SqlCommand("INSERT INTO Customer (CustomerID, FirstName) VALUES (@Id, @Name);",
                                  conn))
            {
                cmd.Parameters.AddWithValue("@Id", newId);
                cmd.Parameters.AddWithValue("@Name", customerTemp.CustomerName);
                cmd.ExecuteNonQuery();
                return newId;
            }
        }



        public int DeleteCustomerByName(string customerName)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Customer WHERE FirstName = @CustomerName", conn))
            {
                cmd.Parameters.AddWithValue("@CustomerName", customerName);
                return cmd.ExecuteNonQuery();
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
    
