using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Com.YouMusic.Core.Models;

namespace Com.YouMusic.Core.Repositories
{
    public interface IMusicRepository : IRepository<Music>
    {
        Task<IEnumerable<Music>> GetAllWithArtistAsync();

        Task<Music> GetWithArtistById(int id);

        Task<IEnumerable<Music>> GetAllWithArtistByIdArtist(int idArtist);
    }
}
