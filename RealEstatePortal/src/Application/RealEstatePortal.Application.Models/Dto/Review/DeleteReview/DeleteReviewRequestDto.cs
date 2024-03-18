namespace RealEstatePortal.Application.Models.Dto.Review.DeleteReview;

public class DeleteReviewRequestDto(Guid reviewId, int senderId)
{
    public Guid ReviewId { get; set; } = reviewId;

    public int SenderId { get; set; } = senderId; // я такпонимаю этот парень ответственныйза выстовлениеоценки
}