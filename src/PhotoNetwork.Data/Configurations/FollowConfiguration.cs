using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoNetwork.Data.Entities;

namespace PhotoNetwork.Data.Configurations;

public class FollowConfiguration : IEntityTypeConfiguration<Follow>
{
    public void Configure(EntityTypeBuilder<Follow> builder)
    {
        // Ключът не позволява да следваш един и същ автор два пъти.
        builder.HasKey(f => new { f.FollowerId, f.FollowedId });

        // Потребителят не може да следва себе си.
        builder.ToTable(t => t.HasCheckConstraint("CK_Follows_NotSelf", "[FollowerId] <> [FollowedId]"));

        builder.HasOne(f => f.Follower)
            .WithMany()
            .HasForeignKey(f => f.FollowerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.Followed)
            .WithMany()
            .HasForeignKey(f => f.FollowedId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
