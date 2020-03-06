using System;

namespace HourDollar.Models
{
    public class ArtistInformation
    {
        public ArtistId ArtistId {get; set;}
        public string ArtistName {get; set;}
        public string ArtistRoute {get; set;}
    }

    public enum ArtistId 
    {
        Nice87,
        BLewie,
        DaveHill,
        EBaggs

    }
}
