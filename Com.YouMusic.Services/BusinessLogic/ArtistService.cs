using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Com.YouMusic.Core;
using Com.YouMusic.Core.Dtos;
using Com.YouMusic.Core.Models;
using Com.YouMusic.Core.Services;
using Com.YouMusic.Services.Helpers;

namespace Com.YouMusic.Services.BusinessLogic
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArtistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            var mapperConfig = Mappings.GetMapperConfiguration();
            _mapper = mapperConfig.CreateMapper();
        }

        public async Task<ArtistDto> CreateArtist(ArtistDto dto)
        {
            var artist = _mapper.Map<ArtistDto, Artist>(dto);

            await _unitOfWork.Artists.AddAsync(artist);
            await _unitOfWork.CommitAsync();

            return dto;
        }

        public async Task DeleteArtist(int id)
        {
            var artist = await _unitOfWork.Artists.SingleOrDefaultAsync(a => a.Id == id);
            _unitOfWork.Artists.Remove(artist);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ArtistDto>> GetAllArtists()
        {
            var artists = await _unitOfWork.Artists.GetAllWithMusicAsync();
            var dtos = _mapper.Map<IEnumerable<ArtistDto>>(artists);

            return dtos;
        }

        public async Task<ArtistDto> GetArtistById(int id)
        {
            var artist = await _unitOfWork.Artists.GetWithMusicAsyncByIdAsync(id);
            var dto = _mapper.Map<ArtistDto>(artist);

            return dto;
        }

        public async Task UpdateArtist(ArtistDto dto)
        {
            var artist = _mapper.Map<Artist>(dto);
            _unitOfWork.Artists.Edit(artist);

            await _unitOfWork.CommitAsync();
        }
    }
}
