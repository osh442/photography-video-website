using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoNetwork.Data.Entities;

namespace PhotoNetwork.Data.Configurations;

public class PhotographerProfileConfiguration : IEntityTypeConfiguration<PhotographerProfile>
{
    public void Configure(EntityTypeBuilder<PhotographerProfile> builder)
    {
        builder.Property(p => p.DisplayName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Bio).HasMaxLength(500);
        builder.Property(p => p.AvatarPath).HasMaxLength(260);

        // Един потребител има най-много един профил.
        builder.HasOne(p => p.User)
            .WithOne(u => u.Profile)
            .HasForeignKey<PhotographerProfile>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
