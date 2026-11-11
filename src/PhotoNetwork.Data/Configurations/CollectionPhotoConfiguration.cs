using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoNetwork.Data.Entities;

namespace PhotoNetwork.Data.Configurations;

public class CollectionPhotoConfiguration : IEntityTypeConfiguration<CollectionPhoto>
{
    public void Configure(EntityTypeBuilder<CollectionPhoto> builder)
    {
        builder.HasKey(cp => new { cp.CollectionId, cp.PhotoId });

        builder.HasOne(cp => cp.Collection)
            .WithMany(c => c.CollectionPhotos)
            .HasForeignKey(cp => cp.CollectionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cp => cp.Photo)
            .WithMany()
            .HasForeignKey(cp => cp.PhotoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
