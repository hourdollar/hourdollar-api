using System.Collections.Generic;
using System.Threading.Tasks;
using HourDollar.Models;

namespace HourDollar.DataLayer.Interface
{
    public interface IAlbumPlatformDataLayer
    {
        Task SaveAlbumPlatform(PlatformAlbum platformAlbum);
        Task<List<PlatformAlbum>> GetAlbumPlatformByAlbumId(int albumId);
    }
}