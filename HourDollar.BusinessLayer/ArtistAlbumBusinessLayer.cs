using System.Collections.Generic;
using System.Threading.Tasks;
using HourDollar.BusinessLayer.Interface;
using HourDollar.DataLayer.Interface;
using HourDollar.Models;

namespace HourDollar.BusinessLayer
{
    public class ArtistAlbumBusinessLayer : IArtistAlbumBusinessLayer
    {
        public IArtistAlbumDataLayer dataLayer;
        private IAlbumPlatformDataLayer albumPlatformDataLayer;

        public ArtistAlbumBusinessLayer(IArtistAlbumDataLayer dataLayer, IAlbumPlatformDataLayer albumPlatformDataLayer)
        {
            this.dataLayer = dataLayer;
            this.albumPlatformDataLayer = albumPlatformDataLayer;
        }

        public Task DeleteArtistAlbumAsync(int artistAlbumId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<PlatformAlbum>> GetAlbumPlatformByAlbumId(int albumId)
        {
            return albumPlatformDataLayer.GetAlbumPlatformByAlbumId(albumId);
        }

        public Task<List<ArtistAlbum>> GetAllAlbumsAsync()
        {
            return dataLayer.GetAllAlbumsAsync();
        }

        public Task<ArtistAlbum> GetArtistAlbumsByAlbumId(int albumId)
        {
            return dataLayer.GetArtistAlbumsByAlbumId(albumId);
        }

        public Task<List<ArtistAlbum>> GetArtistAlbumsByArtistIdAsync(int artistId)
        {
            return dataLayer.GetArtistAlbumsByArtistIdAsync(artistId);
        }

        public Task SaveAlbumPlatform(PlatformAlbum platformAlbum)
        {
            return albumPlatformDataLayer.SaveAlbumPlatform(platformAlbum);
        }

        public Task SaveArtistAlbumAsync(ArtistAlbum artistAlbum)
        {
            return dataLayer.SaveArtistAlbumAsync(artistAlbum);
        }

        public Task UpdateArtistAlbumAsync(ArtistAlbum artistAlbum)
        {
            return dataLayer.UpdateArtistAlbumAsync(artistAlbum);
        }
    }
}