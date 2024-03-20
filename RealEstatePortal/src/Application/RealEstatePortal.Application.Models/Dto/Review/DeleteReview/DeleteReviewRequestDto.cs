namespace RealEstatePortal.Application.Models.Dto.Review.DeleteReview;

public class DeleteReviewRequestDto(Guid reviewId, Guid senderId)
{
    public Guid ReviewId { get; set; } = reviewId;

    public Guid SenderId { get; set; } = senderId; // я такпонимаю этот парень ответственныйза выстовлениеоценки
}