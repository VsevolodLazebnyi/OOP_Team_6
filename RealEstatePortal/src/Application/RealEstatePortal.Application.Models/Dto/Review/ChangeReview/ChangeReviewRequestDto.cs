namespace RealEstatePortal.Application.Models.Dto.Review.ChangeReview;

public class ChangeReviewRequestDto(Guid reviewId, string textOfReview, int rating)
{
    public Guid ReviewId { get; set; } = reviewId;

    public string TextOfReview { get; set; } = textOfReview;

    public int Rating { get; set; } = rating;

    // public int SenderId { get; set; } = senderId;
    // public int RecieverId { get; set; } = recieverId
    // мы ведь хотим изменить не наш комментарий, но комментарий кому мы дали?
}