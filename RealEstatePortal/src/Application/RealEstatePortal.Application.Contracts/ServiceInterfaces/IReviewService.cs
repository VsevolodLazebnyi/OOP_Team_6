using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Contracts.ServiceInterfaces;

public interface IReviewService
{
    Task<ReviewModel> GetReviewAsync(Guid reviewId);

    Task<Guid> AddNewReview(ReviewModel reviewModel);

    Task PutUserToReview(Guid reviewId, Guid userId);

    Task PutReviewToObject(Guid reviewId, Guid recieverId);

    Task ChangeReview(Guid reviewId, string textOfReview, int rating);

    Task PutReviewToUser(Guid reviewId, Guid objectId, Guid userId);

    Task DeleteReview(Guid reviewId, Guid requestDtoSenderId);
}