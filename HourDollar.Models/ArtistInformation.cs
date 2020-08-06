using System;

namespace HourDollar.Models
{
    public class ArtistInformation
    {
        public int artistId { get; set; }
        public string artistName { get; set; }
        public string artistRoute { get; set; }
        public string twitterUrl { get; set; }
        public string instagramUrl { get; set; }
        public string facebookUrl { get; set; }
        public string artistBio { get; set; }
        public string calendarUrl { get; set; }
        public bool isActive {get; set;}

        internal DatabaseSettings Db { get; set; }

        public ArtistInformation()
        {
        }

    }
}
