namespace PhotoNetwork.Data.Entities;

public class Tag
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<PhotoTag> PhotoTags { get; set; } = new List<PhotoTag>();
}
