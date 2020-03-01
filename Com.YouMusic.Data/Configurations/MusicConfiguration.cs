using System;
using Com.YouMusic.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Com.YouMusic.Data.Configurations
{
    public class MusicConfiguration : IEntityTypeConfiguration<Music>
    {
        public MusicConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                    .UseIdentityColumn();

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(a => a.Artist)
                .WithMany(b => b.Musics)
                .HasForeignKey(a => a.ArtistId);

            builder.ToTable("Musics");
        }
    }
}
