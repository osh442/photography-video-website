namespace PhotoNetwork.Data.Entities;

public class Genre
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<Photo> Photos { get; set; } = new List<Photo>();
}
