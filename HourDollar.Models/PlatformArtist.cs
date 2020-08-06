namespace HourDollar.Models
{
    public class PlatformArtist
    {
        public int artistPlatformId { get; set; }
        public int artistId { get; set; }
        public Platform platformId { get; set; }
        public string platformUrl { get; set; }
        public bool isActive { get; set; }
        public PlatformArtist() {}
    }
}