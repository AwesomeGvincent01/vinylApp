
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
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Genre (Name) VALUES (@GenreName); SELECT SCOPE_IDENTITY();",
                    conn))
            {
                cmd.Parameters.AddWithValue("@GenreName", genreTemp.GenreName);
                return Convert.ToInt32(cmd.ExecuteScalar());
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
    
