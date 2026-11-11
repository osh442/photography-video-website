using PhotoNetwork.Data.Enums;

namespace PhotoNetwork.Data.Entities;

// Сигнал за снимка или коментар. Попълва се само едно от PhotoId и CommentId.
public class Report
{
    public int Id { get; set; }

    public string Reason { get; set; } = null!;

    public ReportStatus Status { get; set; } = ReportStatus.Open;

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public string ReporterId { get; set; } = null!;

    public ApplicationUser Reporter { get; set; } = null!;

    public int? PhotoId { get; set; }

    public Photo? Photo { get; set; }

    public int? CommentId { get; set; }

    public Comment? Comment { get; set; }

    public string? ResolvedById { get; set; }

    public ApplicationUser? ResolvedBy { get; set; }

    public DateTime? ResolvedOn { get; set; }
}
