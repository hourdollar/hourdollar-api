using System.Collections.Generic;
using System.Threading.Tasks;
using HourDollar.Models;

namespace HourDollar.DataLayer.Interface
{
    public interface IArtistPlatformDataLayer
    {
        Task SaveArtistPlatform(PlatformArtist platformArtist);
        Task<List<PlatformArtist>> GetArtistPlatformByArtistId(int artistId);
    }
}