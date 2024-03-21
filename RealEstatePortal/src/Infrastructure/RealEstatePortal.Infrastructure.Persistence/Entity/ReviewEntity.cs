using System.ComponentModel.DataAnnotations;

namespace RealEstatePortal.Infrastructure.Persistence.Entity;

public class ReviewEntity
{
    [Key]
    public Guid ReviewId { get; set; }

    public string TextOfReview { get; set; } = string.Empty;

    public int Rating { get; set; }

    public Guid SenderId { get; set; }

    public DateTime DateOfReview { get; set; }

    public Guid RecieverId { get; set; }
}