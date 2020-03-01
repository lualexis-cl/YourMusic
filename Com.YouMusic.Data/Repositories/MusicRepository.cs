using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.YouMusic.Core.Models;
using Com.YouMusic.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Com.YouMusic.Data.Repositories
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        private readonly YouMusicDbContext _youMusicDbContext;

        public MusicRepository(YouMusicDbContext youMusicDbContext)
            : base(youMusicDbContext)
        {
            _youMusicDbContext = youMusicDbContext;
        }

        public async Task<IEnumerable<Music>> GetAllWithArtistAsync()
        {
            return
                await _youMusicDbContext
                .Musics.Include(a => a.Artist)
                .ToListAsync();
                
        }

        public async Task<IEnumerable<Music>> GetAllWithArtistByIdArtist(int idArtist)
        {
            return
                await _youMusicDbContext.Musics
                .Include(a => a.Artist)
                .Where(a => a.ArtistId == idArtist)
                .ToListAsync();
        }

        public async Task<Music> GetWithArtistById(int id)
        {
            return await _youMusicDbContext.Musics
                .Include(a => a.Artist)
                .SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
