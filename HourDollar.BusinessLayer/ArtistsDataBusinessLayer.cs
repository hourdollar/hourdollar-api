using System;
using System.Collections.Generic;
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
        private IArtistPlatformDataLayer artistPlatformDataLayer;
        public ArtistsDataBusinessLayer(IArtistsDataDataLayer dataLayer, IArtistPlatformDataLayer artistPlatformDataLayer)
        {
            this.dataLayer = dataLayer;
            this.artistPlatformDataLayer = artistPlatformDataLayer;
        }

        public Task<List<ArtistInformation>> GetArtistData()
        {
            return dataLayer.GetArtistData();
        }

        public Task<ArtistInformation> GetArtistDataById(int artistId)
        {
            return dataLayer.GetArtistDataById(artistId);
        }

        public Task<List<PlatformArtist>> GetArtistPlatformByArtistId(int artistId)
        {
            return artistPlatformDataLayer.GetArtistPlatformByArtistId(artistId);
        }

        public Task InsertArtist(ArtistInformation artist)
        {
            return dataLayer.InsertArtist(artist);
        }

        public Task SaveArtistPlatform(PlatformArtist platformArtist)
        {
            return artistPlatformDataLayer.SaveArtistPlatform(platformArtist);
        }

        public Task UpdateArtistAsync(ArtistInformation artist)
        {
            return dataLayer.UpdateArtistAsync(artist);
        }

        // private PrintItem()
    }
}
