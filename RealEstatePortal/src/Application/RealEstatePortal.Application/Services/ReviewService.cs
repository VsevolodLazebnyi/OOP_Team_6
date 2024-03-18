using RealEstatePortal.Application.Abstractions.RepoInterfaces;
using RealEstatePortal.Application.Contracts.ServiceInterfaces;
using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<ReviewModel> GetReviewAsync(Guid reviewId)
    {
        var review = await _reviewRepository.FindReviewById(reviewId);
        if (review == null)
        {
            throw new Exception($"Review with ID {reviewId} not found");
        }

        return review;
    }

    public async Task AddNewReview(ReviewModel reviewModel)
    {
        await _reviewRepository.CreateReview(reviewModel);
    }

    public Task PutUserToReview(int reviewId, int userId)
    {
        throw new NotImplementedException();
    }

    public Task PutReviewToObject(int reviewId, int objectId)
    {
        // надо соединить с ентити и репой
    }

    public Task ChangeReview(int reviewId)
    {
        // надо соединить с ентити и репой
    }

    public Task PutReviewToUser(int reviewId, int objectId, int userId)
    {
        // надо соединить с ентити и репой
    }

    public async Task DeleteReview(Guid reviewId, int senderId)
    {
        var review = await _reviewRepository.FindReviewById(reviewId);
        if (review == null)
        {
            throw new Exception($"Review with ID {reviewId} not found");
        }

        if (review.SenderId != senderId)
        {
            throw new Exception($"User with ID {senderId} is not the sender of the review with ID {reviewId}");
        }

        await _reviewRepository.DeleteReview(reviewId);
    }

    public async Task ChangeReview(Guid reviewId, string newText, int newRating)
    {
        var review = await _reviewRepository.FindReviewById(reviewId);
        if (review == null)
        {
            throw new Exception($"Review with ID {reviewId} not found");
        }

        review.TextOfReview = newText;
        review.Rating = newRating;

        await _reviewRepository.UpdateReview(review);
    }

    public Task<ReviewModel> GetReviewAsync(int reviewId)
    {
        // надо соединить с ентити и репой
    }

    Task IReviewService.AddNewReview(ReviewModel reviewModel)
    {
        return AddNewReview(reviewModel);
    }
}
