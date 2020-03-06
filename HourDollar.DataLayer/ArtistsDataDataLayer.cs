using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using HourDollar.DataLayer.Interface;
using HourDollar.Models;

namespace HourDollar.DataLayer
{
    public class ArtistsDataDataLayer : IArtistsDataDataLayer
    {
        private readonly IAmazonDynamoDB client;

        public ArtistsDataDataLayer(IAmazonDynamoDB client)
        {
            this.client = client;
        }

        public async Task<GetItemResponse> GetArtistData(ArtistId artistId)
        {
            var request = new GetItemRequest
            {
                TableName = "ArtistData",
                Key = new Dictionary<string, AttributeValue>()
                {
                    {
                        "ArtistId", new AttributeValue { N = artistId.ToString()}
                    }
                }
            };
            return await GetItem(request);
        }
        private Task<GetItemResponse> GetItem(GetItemRequest request) =>
            client.GetItemAsync(request);
    }
}
