using System;
using Com.YouMusic.Core.Models;
using Com.YouMusic.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Com.YouMusic.Data
{
    public class YouMusicDbContext : DbContext
    {
        public YouMusicDbContext(DbContextOptions<YouMusicDbContext> options)
            : base(options)
        {
        }

        public DbSet<Music> Musics { get; set; }

        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MusicConfiguration());

            builder.ApplyConfiguration(new ArtistConfiguration());
        }
    }
}
