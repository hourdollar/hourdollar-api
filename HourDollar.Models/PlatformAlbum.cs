namespace HourDollar.Models
{
    public class PlatformAlbum
    {
        public int albumPlatformId { get; set; }
        public int artistAlbumId { get; set; }
        public Platform platformId { get; set; }
        public string albumDirectUrl { get; set; }
        public bool isActive { get; set; }
        public PlatformAlbum() {}
    }
}