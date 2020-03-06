using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using HourDollar.Models;

namespace HourDollar.BusinessLayer.Interface
{
    public interface IArtistsDataBusinessLayer
    {
        Task<GetItemResponse> GetArtistData(ArtistId artistId);
    }
}
