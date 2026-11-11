using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoNetwork.Data.Entities;

namespace PhotoNetwork.Data.Configurations;

public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.Property(r => r.Reason).IsRequired().HasMaxLength(500);

        // Сигналът е или за снимка, или за коментар - никога за двете.
        builder.ToTable(t => t.HasCheckConstraint(
            "CK_Reports_PhotoOrComment",
            "([PhotoId] IS NOT NULL AND [CommentId] IS NULL) OR ([PhotoId] IS NULL AND [CommentId] IS NOT NULL)"));

        // Съдържанието се скрива чрез флаг, затова сигналите не се трият каскадно.
        builder.HasOne(r => r.Reporter)
            .WithMany()
            .HasForeignKey(r => r.ReporterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Photo)
            .WithMany()
            .HasForeignKey(r => r.PhotoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Comment)
            .WithMany()
            .HasForeignKey(r => r.CommentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.ResolvedBy)
            .WithMany()
            .HasForeignKey(r => r.ResolvedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
