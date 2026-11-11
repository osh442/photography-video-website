namespace PhotoNetwork.Data.Entities;

public class CollectionPhoto
{
    public int CollectionId { get; set; }

    public Collection Collection { get; set; } = null!;

    public int PhotoId { get; set; }

    public Photo Photo { get; set; } = null!;
}
