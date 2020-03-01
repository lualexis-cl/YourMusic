using System;
using System.Threading.Tasks;
using Com.YouMusic.Core.Repositories;

namespace Com.YouMusic.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMusicRepository Musics { get; }

        IArtistRepository Artists { get; }

        Task<int> CommitAsync();
    }
}