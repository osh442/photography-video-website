namespace PhotoNetwork.Data.Entities;

public class PhotographerProfile
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public ApplicationUser User { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string? Bio { get; set; }

    public string? AvatarPath { get; set; }
}
