using Microsoft.AspNetCore.Identity;

namespace PhotoNetwork.Data.Entities;

public class ApplicationUser : IdentityUser
{
    public bool IsBlocked { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public PhotographerProfile? Profile { get; set; }

    public ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public ICollection<Album> Albums { get; set; } = new List<Album>();
}
