namespace HourDollar.Models
{
    public class ArtistImage
    {
        public int artistImageId { get; set; }
        public int artistId { get; set;}
        public string imageUrl { get; set; }
        public ArtistImage() {}
    }
}