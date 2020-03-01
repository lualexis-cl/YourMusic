using System;
using AutoMapper;
using Com.YouMusic.Core.Dtos;
using Com.YouMusic.Core.Models;

namespace Com.YouMusic.Services.Helpers
{
    public class Mappings
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<ArtistDto, Artist>();
                config.CreateMap<Artist, ArtistDto>();

                config.CreateMap<Music, MusicDto>()
                    .ForMember(destination => destination.Artist, option =>
                        option.MapFrom(src => src.Artist));

                config.CreateMap<MusicDto, Music>();
            });
        }
    }
}
