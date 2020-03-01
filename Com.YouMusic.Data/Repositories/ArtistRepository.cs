using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Com.YouMusic.Core.Models;
using Com.YouMusic.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Com.YouMusic.Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        private readonly YouMusicDbContext _context;

        public ArtistRepository(YouMusicDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Artist>> GetAllWithMusicAsync()
        {
            return await _context.Artists
                .Include(a => a.Musics)
                .ToListAsync();
        }

        public async Task<Artist> GetWithMusicAsyncByIdAsync(int id)
        {
            return await _context.Artists
                .Include(a => a.Musics)
                .SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
