using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Abstractions.RepoInterfaces;

public interface IReviewRepository
{
    Task<string> CreateReview(ReviewModel reviewModel);

    Task<ReviewModel> FindReviewById(int reviewId);

    Task UpdateReview(ReviewModel reviewModel);

    Task DeleteReview(int reviewId);
}