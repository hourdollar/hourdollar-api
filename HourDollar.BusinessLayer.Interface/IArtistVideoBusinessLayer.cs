using System.Collections.Generic;
using System.Threading.Tasks;
using HourDollar.Models;

namespace HourDollar.BusinessLayer.Interface
{
    public interface IArtistVideoBusinessLayer
    {
        Task<List<ArtistVideo>> GetAllArtistVideos();
        Task<List<ArtistVideo>> GetArtistVideosByArtistId(int artistId);
        Task SaveArtistVideo(ArtistVideo artistVideo);
        Task UpdateArtistVideo(ArtistVideo artistVideo);
    }
}