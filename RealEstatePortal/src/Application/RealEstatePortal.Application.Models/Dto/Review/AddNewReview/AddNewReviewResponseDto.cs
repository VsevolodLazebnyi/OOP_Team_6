namespace RealEstatePortal.Application.Models.Dto.Review.AddNewReview;

public class AddNewReviewResponseDto(Guid reviewId)
{
    public Guid ReviewId { get; set; } = reviewId;
}