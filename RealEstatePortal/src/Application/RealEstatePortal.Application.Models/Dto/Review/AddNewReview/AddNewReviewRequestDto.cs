namespace RealEstatePortal.Application.Models.Dto.Review.AddNewReview;

public class AddNewReviewRequestDto(Guid reviewId, string textOfReview, int rating, Guid senderId, Guid recieverId, DateTime dateDeal)
{
    public Guid ReviewId { get; set; } = reviewId;

    public string TextOfReview { get; set; } = textOfReview;

    public int Rating { get; set; } = rating;

    public Guid SenderId { get; set; } = senderId;

    public Guid RecieverId { get; set; } = recieverId;

    public DateTime DateOfReview { get; set; } = dateDeal;
}