namespace RealEstatePortal.Application.Models.Dto.Review.AddNewReview;

public class AddNewReviewRequestDto(Guid reviewId, string textOfReview, int rating, int senderId, int recieverId, DateTime dateDeal)
{
    public Guid ReviewId { get; set; } = reviewId;

    public string TextOfReview { get; set; } = textOfReview;

    public int Rating { get; set; } = rating;

    public int SenderId { get; set; } = senderId;

    public int RecieverId { get; set; } = recieverId;

    public DateTime DateDeal { get; set; } = dateDeal;
}