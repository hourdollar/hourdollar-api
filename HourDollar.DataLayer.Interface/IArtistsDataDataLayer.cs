using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using HourDollar.Models;

namespace HourDollar.DataLayer.Interface
{
    public interface IArtistsDataDataLayer
    {
        Task<GetItemResponse> GetArtistData(ArtistId artistId);
    }
}
