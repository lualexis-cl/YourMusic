using System;
using System.ComponentModel;

namespace Com.YouMusic.Core.Dtos
{
    public class MusicSaveDto
    {
        [DefaultValue(0)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ArtistId { get; set; }
    }
}
