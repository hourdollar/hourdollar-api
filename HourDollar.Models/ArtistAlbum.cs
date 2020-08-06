using System;

namespace HourDollar.Models
{
    public class ArtistAlbum
    {
        public int artistAlbumId {get; set;}
        public int artistId {get; set;}
        public string albumEmbedUrl {get; set;}
        public string albumArt {get; set;}
        public DateTime albumReleaseDate {get; set;}
        public string albumTitle {get; set;}
        public bool isActive {get; set;}
        public bool isSingle {get; set;}
        public ArtistAlbum() {}

    }
}