namespace RealEstatePortal.Application.Models.Dto.Review.GetReview;

public class GetReviewRequestDto(Guid reviewId)
{
    public Guid ReviewId { get; set; } = reviewId;
}