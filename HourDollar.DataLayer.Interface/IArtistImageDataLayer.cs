using System.Collections.Generic;
using System.Threading.Tasks;
using HourDollar.Models;

namespace HourDollar.DataLayer.Interface
{
    public interface IArtistImageDataLayer
    {
        Task<List<ArtistImage>> GetArtistImagesByArtistId(int artistId);
    }
}