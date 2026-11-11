using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoNetwork.Data.Entities;

namespace PhotoNetwork.Data.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.Property(g => g.Name).IsRequired().HasMaxLength(50);
        builder.HasIndex(g => g.Name).IsUnique();

        builder.HasData(
            new Genre { Id = 1, Name = "Портрет" },
            new Genre { Id = 2, Name = "Пейзаж" },
            new Genre { Id = 3, Name = "Улична фотография" },
            new Genre { Id = 4, Name = "Дива природа" },
            new Genre { Id = 5, Name = "Макро" },
            new Genre { Id = 6, Name = "Архитектура" },
            new Genre { Id = 7, Name = "Документална" },
            new Genre { Id = 8, Name = "Черно-бяла" },
            new Genre { Id = 9, Name = "Нощна фотография" },
            new Genre { Id = 10, Name = "Пътешествия" });
    }
}
