using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using HourDollar.BusinessLayer.Interface;
using HourDollar.DataLayer.Interface;
using HourDollar.Models;

namespace HourDollar.BusinessLayer
{
    public class ArtistsDataBusinessLayer : IArtistsDataBusinessLayer
    {
        private IArtistsDataDataLayer dataLayer;
        public ArtistsDataBusinessLayer(IArtistsDataDataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        public async Task<GetItemResponse> GetArtistData(ArtistId artistId)
        {
            return await dataLayer.GetArtistData(artistId);
        }

        // private PrintItem()
    }
}
