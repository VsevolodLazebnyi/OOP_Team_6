namespace RealEstatePortal.Application.Models.Dto.Review.GetReview;

public class GetReviewResponseDto(string textOfReview, int rating)
{
    public string TextOfReview { get; set; } = textOfReview;

    public int Rating { get; set; } = rating;
}