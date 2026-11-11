namespace PhotoNetwork.Data.Entities;

public class Message
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public DateTime SentOn { get; set; } = DateTime.UtcNow;

    public bool IsRead { get; set; }

    public string SenderId { get; set; } = null!;

    public ApplicationUser Sender { get; set; } = null!;

    public string ReceiverId { get; set; } = null!;

    public ApplicationUser Receiver { get; set; } = null!;
}
