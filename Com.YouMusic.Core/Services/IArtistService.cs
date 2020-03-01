using System.Collections.Generic;
using System.Threading.Tasks;
using Com.YouMusic.Core.Dtos;

namespace Com.YouMusic.Core.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistDto>> GetAllArtists();

        Task<ArtistDto> GetArtistById(int id);

        Task<ArtistDto> CreateArtist(ArtistDto dto);

        Task UpdateArtist(ArtistDto dto);

        Task DeleteArtist(int id);
    }
}
