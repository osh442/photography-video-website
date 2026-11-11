using PhotoNetwork.Data.Enums;

namespace PhotoNetwork.Data.Entities;

// Колекция от снимки на други автори (албумът съдържа само собствени снимки).
public class Collection
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public Visibility Visibility { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public string OwnerId { get; set; } = null!;

    public ApplicationUser Owner { get; set; } = null!;

    public ICollection<CollectionPhoto> CollectionPhotos { get; set; } = new List<CollectionPhoto>();
}
