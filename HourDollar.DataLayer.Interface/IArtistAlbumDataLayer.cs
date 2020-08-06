using System.Collections.Generic;
using System.Threading.Tasks;
using HourDollar.Models;

namespace HourDollar.DataLayer.Interface
{
    public interface IArtistAlbumDataLayer
    {
        Task<List<ArtistAlbum>> GetAllAlbumsAsync();
        Task<List<ArtistAlbum>> GetArtistAlbumsByArtistIdAsync(int artistId);
        Task<ArtistAlbum> GetArtistAlbumsByAlbumId(int albumId);
        Task SaveArtistAlbumAsync(ArtistAlbum artistAlbum);
        Task UpdateArtistAlbumAsync(ArtistAlbum artistAlbum);
        Task DeleteArtistAlbumAsync(int artistAlbumId);
    }
}