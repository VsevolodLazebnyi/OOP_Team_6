namespace RealEstatePortal.Infrastructure.Persistence.Entity;

public class ReviewEntity
{
    public Guid ReviewId { get; set; }

    public string TextOfReview { get; set; } = string.Empty;

    public int Rating { get; set; }

    public int SenderId { get; set; }

    public DateTime DateDeal { get; set; }

    public int RecieverId { get; set; }
}