using System;
using System.Threading.Tasks;
using Com.YouMusic.Core;
using Com.YouMusic.Core.Repositories;
using Com.YouMusic.Data.Repositories;

namespace Com.YouMusic.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly YouMusicDbContext _context;
        private MusicRepository _musicReposity;
        private ArtistRepository _artistRepository;

        public UnitOfWork(YouMusicDbContext context)
        {
            _context = context;
        }

        public IMusicRepository Musics
            => _musicReposity ??= new MusicRepository(_context);

        public IArtistRepository Artists
            => _artistRepository ??= new ArtistRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
