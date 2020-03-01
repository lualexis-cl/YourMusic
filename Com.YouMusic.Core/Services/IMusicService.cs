using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Com.YouMusic.Core.Dtos;

namespace Com.YouMusic.Core.Services
{
    public interface IMusicService
    {
        Task<IEnumerable<MusicDto>> GetAllWithArtist();

        Task<MusicDto> GetMusicById(int id);

        Task<IEnumerable<MusicDto>> GetMusicsByArtistId(int artistId);

        Task<MusicDto> CreateMusic(MusicDto dto);

        Task UpdateMusic(MusicDto dto);

        Task DeleteMusic(int id);
    }
}
