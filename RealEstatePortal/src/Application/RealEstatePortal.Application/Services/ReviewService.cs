#pragma warning disable CA1725

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
        ReviewModel review = await _reviewRepository.FindReviewById(reviewId);
        if (review == null)
        {
            throw new Exception($"Review with ID not found");
        }

        return review;
    }

    public async Task<Guid> AddNewReview(ReviewModel reviewModel)
    {
        Guid id = await _reviewRepository.CreateReview(reviewModel);
        return id;
    }

    public async Task PutUserToReview(Guid reviewId, Guid userId)
    {
        ReviewModel review = await _reviewRepository.FindReviewById(reviewId);
        if (review != null)
        {
            review.SenderId = userId; // поставила оправителя отзыва
            await _reviewRepository.UpdateReview(review);
        }
        else
        {
            throw new Exception($"Object with ID {reviewId} not found");
        }
    }

    public async Task PutReviewToObject(Guid reviewId, Guid recieverId)
    {
        ReviewModel review = await _reviewRepository.FindReviewById(reviewId);
        if (review != null)
        {
            review.RecieverId = recieverId; // поставила отзыв на получателя (читай: объект или риелтора)
            await _reviewRepository.UpdateReview(review);
        }
        else
        {
            throw new Exception($"Object with ID {reviewId} not found");
        }
    }

    // public Task ChangeReview(Guid reviewId)
    // {
    //     // надо соединить с ентити и репой
    // }
    public async Task PutReviewToUser(Guid reviewId, Guid objectId, Guid senderId)
    {
        ReviewModel review = await _reviewRepository.FindReviewById(reviewId);
        if (review != null)
        {
            review.SenderId = senderId; // создатель отзыва
            await _reviewRepository.UpdateReview(review);
        }
        else
        {
            throw new Exception($"Object with ID {reviewId} not found");
        }
    }

    public async Task DeleteReview(Guid reviewId, Guid senderId)
    {
        ReviewModel review = await _reviewRepository.FindReviewById(reviewId);
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

    public async Task ChangeReview(Guid reviewId, string textOfReview, int rating)
    {
        ReviewModel review = await _reviewRepository.FindReviewById(reviewId);
        if (review == null)
        {
            throw new Exception($"Review with ID {reviewId} not found");
        }

        review.TextOfReview = textOfReview;
        review.Rating = rating;

        await _reviewRepository.UpdateReview(review);
    }

    // public Task<ReviewModel> GetReviewAsync(Guid reviewId)
    // {
    //     // надо соединить с ентити и репой
    // }

    // Task IReviewService.AddNewReview(ReviewModel reviewModel)
    // {
    //     return AddNewReview(reviewModel);
    // }
}
