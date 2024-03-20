namespace RealEstatePortal.Application.Models.Models;

public class ReviewModel
{
    public Guid ReviewId { get; set; }

    public string TextOfReview { get; set; } = string.Empty;

    public int Rating { get; set; }

    public Guid SenderId { get; set; }

    public DateTime DateOfReview { get; set; }

    public Guid RecieverId { get; set; }
}