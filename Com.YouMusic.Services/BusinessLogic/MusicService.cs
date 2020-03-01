using System;
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
    public class MusicService : IMusicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MusicService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            var mapperConfiguration = Mappings.GetMapperConfiguration();

            _mapper = mapperConfiguration.CreateMapper();
        }

        public async Task<MusicDto> CreateMusic(MusicDto dto)
        {
            var entity = _mapper.Map<MusicDto, Music>(dto);
            await _unitOfWork.Musics.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return dto;
        }

        public async Task DeleteMusic(int id)
        {
            var music = await _unitOfWork.Musics.GetByIdAsync(id);
            _unitOfWork.Musics.Remove(music);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<MusicDto>> GetAllWithArtist()
        {
            var musics = await _unitOfWork.Musics.GetAllWithArtistAsync();
            var dtos = _mapper.Map<IEnumerable<MusicDto>>(musics);

            return dtos;
        }

        public async Task<MusicDto> GetMusicById(int id)
        {
            var music = await _unitOfWork.Musics.GetWithArtistById(id);
            var dto = _mapper.Map<MusicDto>(music);

            return dto;
        }

        public async Task<IEnumerable<MusicDto>> GetMusicsByArtistId(int artistId)
        {
            var musics = await _unitOfWork.Musics.GetAllWithArtistByIdArtist(artistId);
            var dtos = _mapper.Map<IEnumerable<MusicDto>>(musics);

            return dtos;
        }

        public async Task UpdateMusic(MusicDto dto)
        {
            var entity = _mapper.Map<Music>(dto);
            _unitOfWork.Musics.Edit(entity);

            await _unitOfWork.CommitAsync();

        }
    }
}
