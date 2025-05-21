
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using vinylApp.Model;
using vinylApp;

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
            string sqlString = "SELECT * FROM Name.Genre";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int genreId = Convert.ToInt32(reader["GENRE ID"]);
                        string genreName = reader                       ["GENRE_NAME"].ToString();
                        genres.Add(new Genre(genreId, genreName));
                    }
                }
            }

            return genres;

            {

            }
        }
    }
}
