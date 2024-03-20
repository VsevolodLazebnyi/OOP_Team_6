using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Abstractions.RepoInterfaces;

public interface IReviewRepository
{
    Task<Guid> CreateReview(ReviewModel reviewModel);

    Task<ReviewModel> FindReviewById(Guid reviewId);

    Task UpdateReview(ReviewModel reviewModel);

    Task DeleteReview(Guid reviewId);
}