using PhotoNetwork.Data.Enums;

namespace PhotoNetwork.Data.Entities;

public class Photo
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string FilePath { get; set; } = null!;

    public string ThumbnailPath { get; set; } = null!;

    public Visibility Visibility { get; set; }

    public bool IsHidden { get; set; }

    public DateTime UploadedOn { get; set; } = DateTime.UtcNow;

    public string OwnerId { get; set; } = null!;

    public ApplicationUser Owner { get; set; } = null!;

    public int? GenreId { get; set; }

    public Genre? Genre { get; set; }

    public int? AlbumId { get; set; }

    public Album? Album { get; set; }

    public ICollection<PhotoTag> PhotoTags { get; set; } = new List<PhotoTag>();

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();
}
