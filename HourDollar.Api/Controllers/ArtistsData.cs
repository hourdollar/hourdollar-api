using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using HourDollar.BusinessLayer.Interface;
using HourDollar.DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HourDollar.Models;
using System.Collections.Generic;

namespace HourDollar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ArtistsDataController : ControllerBase
    {
        public IArtistsDataBusinessLayer _businessLayer;
        public ArtistsDataController(IArtistsDataBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        [HttpGet("artistsData")]
        public async Task<List<ArtistInformation>> GetArtistData()
        {
            return await _businessLayer.GetArtistData();
        }

        [HttpGet("artistsData/{artistId}")]
        public async Task<ArtistInformation> GetArtistDataById(int artistId)
        {
            return await _businessLayer.GetArtistDataById(artistId);
        }

        [HttpPost("artistsData")]
        public async Task InsertArtist(ArtistInformation artist)
        {
            await _businessLayer.InsertArtist(artist);
        }

        [HttpPut("artistsData/{artistId}")]
        public async Task UpdateArtist(ArtistInformation artist)
        {
            await _businessLayer.UpdateArtistAsync(artist);
        }

        [HttpGet("{artistId}/platforms")]
        public async Task<List<PlatformArtist>> GetArtistPlatformByArtistId(int artistId)
        {
            return await _businessLayer.GetArtistPlatformByArtistId(artistId);
        }

        [HttpPost("{artistId}/platform")]
        public async Task SaveArtistPlatform(int artistId, Platform platformId, string platformUrl, bool isActive)
        {
            var platformArtist = new PlatformArtist
            {
                artistId = artistId,
                platformId = platformId,
                platformUrl = platformUrl,
                isActive = isActive
            };
            
            await _businessLayer.SaveArtistPlatform(platformArtist);
        }
    }
}