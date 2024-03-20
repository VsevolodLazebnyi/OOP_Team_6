using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Application.Abstractions.RepoInterfaces;
using RealEstatePortal.Application.Models.Models;
using RealEstatePortal.Infrastructure.Persistence.Contexts;
using RealEstatePortal.Infrastructure.Persistence.Entity;

namespace RealEstatePortal.Infrastructure.Persistence.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ReviewRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> CreateReview(ReviewModel reviewModel)
    {
        var newReviewEntity = new ReviewEntity
        {
            ReviewId = Guid.NewGuid(),
            TextOfReview = reviewModel.TextOfReview,
            Rating = reviewModel.Rating,
            SenderId = reviewModel.SenderId,
            DateOfReview = reviewModel.DateOfReview,
            RecieverId = reviewModel.RecieverId,
        };

        await _context.Review.AddAsync(newReviewEntity);
        await _context.SaveChangesAsync();
        return newReviewEntity.ReviewId;
    }

    public async Task<ReviewModel> FindReviewById(Guid reviewId)
    {
        ReviewEntity? reviewEntity = await _context.Review.FirstOrDefaultAsync(t => t.ReviewId == reviewId);
        return (reviewEntity != null ? _mapper.Map<ReviewModel>(reviewEntity) : null)!;
    }

    public async Task UpdateReview(ReviewModel reviewModel)
    {
        ReviewEntity? existingReviewEntity = await _context.Review.FirstOrDefaultAsync(t => t.ReviewId == reviewModel.ReviewId);

        if (existingReviewEntity != null)
        {
            existingReviewEntity.TextOfReview = reviewModel.TextOfReview;
            existingReviewEntity.Rating = reviewModel.Rating;
            existingReviewEntity.DateOfReview = reviewModel.DateOfReview;

            _context.Review.Update(existingReviewEntity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteReview(Guid reviewId)
    {
        ReviewEntity? reviewEntity = await _context.Review.FirstOrDefaultAsync(t => t.ReviewId == reviewId);

        if (reviewEntity != null)
        {
            _context.Review.Remove(reviewEntity);
            await _context.SaveChangesAsync();
        }
    }
}