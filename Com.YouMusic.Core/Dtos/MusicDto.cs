using System;
namespace Com.YouMusic.Core.Dtos
{
    public class MusicDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ArtistDto Artist { get; set; }
    }
}
