using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vinylApp.Model
{
    public class Record
    {
        public int RecordID { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int ArtistID { get; set; }
        public int GenreID { get; set; }

        public string ArtistName { get; set; }
        public string GenreName { get; set; }

  
        public Record() { }

        public Record(int recordId, string title, int releaseYear, int artistId, int genreId)
        {
            RecordID = recordId;
            Title = title;
            ReleaseYear = releaseYear;
            ArtistID = artistId;
            GenreID = genreId;
        }
    }
}
