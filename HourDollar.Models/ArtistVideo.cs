namespace HourDollar.Models
{
    public class ArtistVideo
    {
        public int artistVideoId {get; set;}
        public int artistId {get; set;}
        public Platform platformId {get; set;}
        public string videoUrl {get; set;}
        public bool isActive {get; set;}
        public ArtistVideo() {}
    }
    
}