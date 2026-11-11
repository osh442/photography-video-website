using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoNetwork.Data.Entities;

namespace PhotoNetwork.Data.Configurations;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.Property(a => a.Title).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Description).HasMaxLength(500);

        builder.HasOne(a => a.Owner)
            .WithMany(u => u.Albums)
            .HasForeignKey(a => a.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
