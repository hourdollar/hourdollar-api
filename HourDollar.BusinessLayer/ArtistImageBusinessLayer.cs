using System.Collections.Generic;
using System.Threading.Tasks;
using HourDollar.BusinessLayer.Interface;
using HourDollar.DataLayer.Interface;
using HourDollar.Models;

namespace HourDollar.BusinessLayer
{
    public class ArtistImageBusinessLayer : IArtistImageBusinessLayer
    {
        public IArtistImageDataLayer dataLayer;

        public ArtistImageBusinessLayer(IArtistImageDataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
        }
        public Task<List<ArtistImage>> GetArtistImagesByArtistId(int artistId)
        {
            return dataLayer.GetArtistImagesByArtistId(artistId);
        }
    }
}