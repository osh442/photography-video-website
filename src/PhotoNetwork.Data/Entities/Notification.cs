using PhotoNetwork.Data.Enums;

namespace PhotoNetwork.Data.Entities;

public class Notification
{
    public int Id { get; set; }

    public NotificationType Type { get; set; }

    public string Text { get; set; } = null!;

    public bool IsRead { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public string UserId { get; set; } = null!;

    public ApplicationUser User { get; set; } = null!;
}
