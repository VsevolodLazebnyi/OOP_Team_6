using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Contracts.ServiceInterfaces;

public interface IReviewService
{
    void GetReviewAsync(int reviewId);

    Task AddNewReview(ReviewModel reviewModel);

    Task PutUserToReview(int reviewId, int userId);

    Task PutReviewToObject(int reviewId, int objectId);

    Task ChangeReview(int reviewId);

    Task PutReviewToUser(int reviewId, int objectId, int userId);

    Task DeleteReview(Guid reviewId, int requestDtoSenderId);
}