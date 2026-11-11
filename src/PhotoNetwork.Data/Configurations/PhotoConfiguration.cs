using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoNetwork.Data.Entities;

namespace PhotoNetwork.Data.Configurations;

public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).HasMaxLength(1000);
        builder.Property(p => p.FilePath).IsRequired().HasMaxLength(260);
        builder.Property(p => p.ThumbnailPath).IsRequired().HasMaxLength(260);

        // Емисията подрежда снимките по дата.
        builder.HasIndex(p => p.UploadedOn);

        // Потребителите не се изтриват физически, а се блокират,
        // затова връзките към потребител не са каскадни.
        builder.HasOne(p => p.Owner)
            .WithMany(u => u.Photos)
            .HasForeignKey(p => p.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Genre)
            .WithMany(g => g.Photos)
            .HasForeignKey(p => p.GenreId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(p => p.Album)
            .WithMany(a => a.Photos)
            .HasForeignKey(p => p.AlbumId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
