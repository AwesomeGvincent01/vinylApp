using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vinylApp.Model
{
    public class Artist
    {
        public int ArtistId { get; set; }

        public string ArtistName { get; set; }




        public Artist(int artistId, string artistName)
        {
            ArtistId = artistId;
            ArtistName = artistName;
        }
    }
}
