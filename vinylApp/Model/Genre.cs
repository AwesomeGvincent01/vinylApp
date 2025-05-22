using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vinylApp.Model
{
    public class Genre
    {
        public int GenreId { get; set; }

        public string GenreName { get; set; }


   

    public Genre(int genreId, string genreName)
        {
            GenreId = genreId;
            GenreName = genreName;
        }
    }
}