using System.Collections.Generic;
using System.Threading.Tasks;
using HourDollar.Models;

namespace HourDollar.DataLayer.Interface
{
    public interface IArtistVideoDataLayer
    {
        Task<List<ArtistVideo>> GetAllArtistVideos();
        Task<List<ArtistVideo>> GetArtistVideosByArtistId(int artistId);
        Task SaveArtistVideo(ArtistVideo artistVideo);
        Task UpdateArtistVideo(ArtistVideo artistVideo);
    }
}