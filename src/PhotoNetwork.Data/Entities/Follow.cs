namespace PhotoNetwork.Data.Entities;

public class Follow
{
    public string FollowerId { get; set; } = null!;

    public ApplicationUser Follower { get; set; } = null!;

    public string FollowedId { get; set; } = null!;

    public ApplicationUser Followed { get; set; } = null!;

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}
