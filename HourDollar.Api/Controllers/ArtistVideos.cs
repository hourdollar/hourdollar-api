using System.Threading.Tasks;
using HourDollar.BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using HourDollar.Models;
using System.Collections.Generic;

namespace HourDollar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ArtistVideosController : ControllerBase
    {
        public IArtistVideoBusinessLayer _businessLayer;
        public ArtistVideosController(IArtistVideoBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        [HttpGet]
        public async Task<List<ArtistVideo>> GetAllArtistVideos()
        {
            return await _businessLayer.GetAllArtistVideos();
        }

        [HttpGet("{artistId}")]
        public async Task<List<ArtistVideo>> GetArtistVideosByArtistId(int artistId)
        {
            return await _businessLayer.GetArtistVideosByArtistId(artistId);
        }

        [HttpPost]
        public async Task SaveArtistVideo(int artistId, Platform platformId, string videoUrl, bool isActive)
        {
            var artistVideo = new ArtistVideo
            {
                artistId = artistId,
                platformId = platformId,
                videoUrl = videoUrl,
                isActive = isActive
            };
            
            await _businessLayer.SaveArtistVideo(artistVideo);
        }

        [HttpPut("{artistVideoId}")]
        public async Task UpdateArtistVideo(int artistVideoId, int artistId, Platform platformId, string videoUrl, bool isActive)
        {
            var artistVideo = new ArtistVideo
            {
                artistVideoId = artistVideoId,
                artistId = artistId,
                platformId = platformId,
                videoUrl = videoUrl,
                isActive = isActive
            };
            await _businessLayer.UpdateArtistVideo(artistVideo);
        }
    }
}