using System.Collections.Generic;
using System.Threading.Tasks;
using HourDollar.BusinessLayer.Interface;
using HourDollar.DataLayer.Interface;
using HourDollar.Models;

namespace HourDollar.BusinessLayer
{
    public class ArtistVideoBusinessLayer : IArtistVideoBusinessLayer
    {
        private IArtistVideoDataLayer dataLayer;
        public ArtistVideoBusinessLayer(IArtistVideoDataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
        }
        public async Task<List<ArtistVideo>> GetAllArtistVideos()
        {
            return await dataLayer.GetAllArtistVideos();
        }

        public async Task<List<ArtistVideo>> GetArtistVideosByArtistId(int artistId)
        {
            return await dataLayer.GetArtistVideosByArtistId(artistId);
        }

        public async Task SaveArtistVideo(ArtistVideo artistVideo)
        {
            await dataLayer.SaveArtistVideo(artistVideo);
        }

        public async Task UpdateArtistVideo(ArtistVideo artistVideo)
        {
            await dataLayer.UpdateArtistVideo(artistVideo);
        }
    }
}
