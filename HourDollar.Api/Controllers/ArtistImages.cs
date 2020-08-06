using System.Threading.Tasks;
using HourDollar.BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using HourDollar.Models;
using System.Collections.Generic;

namespace HourDollar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ArtistImagesController : ControllerBase
    {
        public IArtistImageBusinessLayer _businessLayer;
        public ArtistImagesController(IArtistImageBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        // [HttpGet("artistsData")]
        // public async Task<List<ArtistInformation>> GetArtistData()
        // {
        //     return await _businessLayer.GetArtistData();
        // }

        [HttpGet("{artistId}")]
        public async Task<List<ArtistImage>> GetArtistDataById(int artistId)
        {
            return await _businessLayer.GetArtistImagesByArtistId(artistId);
        }

        // [HttpPost("artistsData")]
        // public async Task InsertArtist(ArtistInformation artist)
        // {
        //     await _businessLayer.InsertArtist(artist);
        // }

        // [HttpPut("artistsData/{artistId}")]
        // public async Task UpdateArtist(ArtistInformation artist)
        // {
        //     await _businessLayer.UpdateArtistAsync(artist);
        // }
    }
}