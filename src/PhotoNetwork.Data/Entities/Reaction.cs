using PhotoNetwork.Data.Enums;

namespace PhotoNetwork.Data.Entities;

public class Reaction
{
    public int PhotoId { get; set; }

    public Photo Photo { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public ApplicationUser User { get; set; } = null!;

    public ReactionType Type { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}
