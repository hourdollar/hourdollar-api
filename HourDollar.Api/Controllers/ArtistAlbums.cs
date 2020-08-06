using System.Threading.Tasks;
using HourDollar.BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using HourDollar.Models;
using System.Collections.Generic;
using System;

namespace HourDollar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ArtistAlbumsController : ControllerBase
    {
        public IArtistAlbumBusinessLayer businessLayer;
        public ArtistAlbumsController(IArtistAlbumBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;
        }

        // [HttpGet("artistsData")]
        // public async Task<List<ArtistInformation>> GetArtistData()
        // {
        //     return await _businessLayer.GetArtistData();
        // }

        [HttpGet]
        public async Task<List<ArtistAlbum>> GetAllArtistAlbums()
        {
            return await businessLayer.GetAllAlbumsAsync();
        }

        [HttpGet("{artistId}")]
        public async Task<List<ArtistAlbum>> GetArtistAlbumsByArtistId(int artistId)
        {
            return await businessLayer.GetArtistAlbumsByArtistIdAsync(artistId);
        }

        [HttpPost]
        public async Task SaveArtistAlbum(int artistId, string embedUrl, string art, DateTime releaseDate, string title, bool isActive, bool isSingle)
        {
            var artistAlbum = new ArtistAlbum
            {
                artistId = artistId,
                albumEmbedUrl = embedUrl,
                albumArt = art,
                albumReleaseDate = releaseDate,
                albumTitle = title,
                isActive = isActive,
                isSingle = isSingle
            };

            await businessLayer.SaveArtistAlbumAsync(artistAlbum);
        }

        [HttpPut("{albumId}")]
        public async Task UpdateArtistAlbum(int albumId, int artistId, string embedUrl, string art, DateTime releaseDate, string title, bool isActive, bool isSingle)
        {
            var previousValue =  await businessLayer.GetArtistAlbumsByAlbumId(albumId);

            var artistAlbum = new ArtistAlbum
            {
                artistAlbumId = albumId,
                artistId = artistId == 0 ? previousValue.artistId : artistId,
                albumEmbedUrl = String.IsNullOrEmpty(embedUrl) ? previousValue.albumEmbedUrl : embedUrl,
                albumArt = String.IsNullOrEmpty(art) ? previousValue.albumArt : art,
                albumReleaseDate = releaseDate == DateTime.MinValue ? previousValue.albumReleaseDate : releaseDate,
                albumTitle = String.IsNullOrEmpty(title) ? previousValue.albumTitle : title,
                isActive = isActive,
                isSingle = isSingle
            };
            
            await businessLayer.UpdateArtistAlbumAsync(artistAlbum);
        }

        [HttpPost("{albumId}/platform")]
        public async Task SaveAlbumPlatform(int albumId, Platform platformId, string directUrl, bool isActive)
        {
            var platformAlbum = new PlatformAlbum
            {
                artistAlbumId = albumId,
                platformId = platformId,
                albumDirectUrl = directUrl,
                isActive = isActive
            };

            await businessLayer.SaveAlbumPlatform(platformAlbum);
        }

        [HttpGet("{albumId}/platform")]
        public async Task<List<PlatformAlbum>> GetAlbumPlatformByAlbumId(int albumId)
        {
            return await businessLayer.GetAlbumPlatformByAlbumId(albumId);
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