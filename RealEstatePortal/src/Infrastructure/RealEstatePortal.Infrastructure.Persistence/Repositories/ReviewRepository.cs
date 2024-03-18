using RealEstatePortal.Application.Abstractions.RepoInterfaces;
using RealEstatePortal.Application.Models.Models;
using RealEstatePortal.Infrastructure.Persistence.Contexts;

namespace RealEstatePortal.Infrastructure.Persistence.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationDbContext _context;

    public ReviewRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> CreateReview(ReviewModel reviewModel)
    {
        var newReviewEntity = new ReviewEntity
        {
            Id = reviewModel.GetId(),
            Username = reviewModel.GetUsername(),
            Role = reviewModel.GetRole(),
            ReviewText = reviewModel.GetText()
        };

        await _context.Object.AddAsync(newReviewEntity);
        await _context.SaveChangesAsync();
        return newReviewEntity.Id;
    }

    public async Task<Int16<ReviewModel>> FindReviewById(int reviewId)
    {
        var reviewEntity = await _context.Review.FirstOrDefaultAsync(t: reviewEntity => t.Id == reviewId);
        return (reviewEntity != null ? EntityMapper.MapReviewEntityToModel(reviewEntity) : null)!;
    }

    public async Task UpdateReview(ReviewModel reviewModel)
    {
        var existingReviewEntity = await _context.Review.FirstOrDefaultAsync(t => t.Id == review.Id);
    
        if (existingReviewEntity != null)
        {
            existingReviewEntity.Username = review.GetUsername();
            existingReviewEntity.Role = review.GetRole();
            existingReviewEntity.ReviewText = review.GetReviewText();

            _context.Review.Update(existingReviewEntity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteReview(int reviewId)
    {
        var reviewEntity = await _context.Review.FirstOrDefaultAsync(t => t.Id == reviewId);
    
        if (reviewEntity != null)
        {
            _context.Review.Remove(reviewEntity);
            await _context.SaveChangesAsync();
        }
    }
}