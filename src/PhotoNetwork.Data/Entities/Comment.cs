namespace PhotoNetwork.Data.Entities;

public class Comment
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public bool IsHidden { get; set; }

    public int PhotoId { get; set; }

    public Photo Photo { get; set; } = null!;

    public string AuthorId { get; set; } = null!;

    public ApplicationUser Author { get; set; } = null!;
}
