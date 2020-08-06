using System.Collections.Generic;
using System.Threading.Tasks;
using HourDollar.Models;

namespace HourDollar.BusinessLayer.Interface
{
    public interface IArtistImageBusinessLayer
    {
        Task<List<ArtistImage>> GetArtistImagesByArtistId(int artistId);
    }
}