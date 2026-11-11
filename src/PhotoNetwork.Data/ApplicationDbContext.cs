using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoNetwork.Data.Entities;

namespace PhotoNetwork.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<PhotographerProfile> PhotographerProfiles => Set<PhotographerProfile>();

    public DbSet<Photo> Photos => Set<Photo>();

    public DbSet<Album> Albums => Set<Album>();

    public DbSet<Collection> Collections => Set<Collection>();

    public DbSet<CollectionPhoto> CollectionPhotos => Set<CollectionPhoto>();

    public DbSet<Genre> Genres => Set<Genre>();

    public DbSet<Tag> Tags => Set<Tag>();

    public DbSet<PhotoTag> PhotoTags => Set<PhotoTag>();

    public DbSet<Follow> Follows => Set<Follow>();

    public DbSet<Reaction> Reactions => Set<Reaction>();

    public DbSet<Comment> Comments => Set<Comment>();

    public DbSet<Message> Messages => Set<Message>();

    public DbSet<Report> Reports => Set<Report>();

    public DbSet<Notification> Notifications => Set<Notification>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Зарежда всички класове от папка Configurations.
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
