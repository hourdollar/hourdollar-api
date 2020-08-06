using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using HourDollar.Models;

namespace HourDollar.DataLayer.Interface
{
    public interface IArtistsDataDataLayer
    {
        Task<List<ArtistInformation>> GetArtistData();
        Task<ArtistInformation> GetArtistDataById(int artistId);
        Task InsertArtist(ArtistInformation artist);
        Task UpdateArtistAsync(ArtistInformation artist);
    }
}
