using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Com.YouMusic.Core.Models;

namespace Com.YouMusic.Core.Repositories
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetAllWithMusicAsync();

        Task<Artist> GetWithMusicAsyncByIdAsync(int id);
    }
}
