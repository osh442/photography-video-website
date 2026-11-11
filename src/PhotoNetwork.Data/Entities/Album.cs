using PhotoNetwork.Data.Enums;

namespace PhotoNetwork.Data.Entities;

public class Album
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public Visibility Visibility { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public string OwnerId { get; set; } = null!;

    public ApplicationUser Owner { get; set; } = null!;

    public ICollection<Photo> Photos { get; set; } = new List<Photo>();
}
