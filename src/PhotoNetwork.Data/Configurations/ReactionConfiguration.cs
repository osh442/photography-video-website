using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoNetwork.Data.Entities;

namespace PhotoNetwork.Data.Configurations;

public class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
{
    public void Configure(EntityTypeBuilder<Reaction> builder)
    {
        // Един потребител има най-много една реакция към снимка.
        builder.HasKey(r => new { r.PhotoId, r.UserId });

        builder.HasOne(r => r.Photo)
            .WithMany(p => p.Reactions)
            .HasForeignKey(r => r.PhotoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
