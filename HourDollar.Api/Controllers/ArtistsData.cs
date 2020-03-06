using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using HourDollar.BusinessLayer.Interface;
using HourDollar.Models;
using Microsoft.AspNetCore.Mvc;

namespace HourDollar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ArtistsDataController : ControllerBase
    {
        private readonly IArtistsDataBusinessLayer businessLayer;
        public ArtistsDataController(IArtistsDataBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;
        }

        [HttpGet("{artistId}")]
        public async Task<GetItemResponse> GetArtistData(ArtistId artistId) =>
            await businessLayer.GetArtistData(artistId);
    }
}