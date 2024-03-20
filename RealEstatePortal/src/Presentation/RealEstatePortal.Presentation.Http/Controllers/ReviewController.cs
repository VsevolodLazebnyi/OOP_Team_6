using Microsoft.AspNetCore.Mvc;
using RealEstatePortal.Application.Contracts.ServiceInterfaces;
using RealEstatePortal.Application.Models.Dto.Review.AddNewReview;
using RealEstatePortal.Application.Models.Dto.Review.ChangeReview;
using RealEstatePortal.Application.Models.Dto.Review.DeleteReview;
using RealEstatePortal.Application.Models.Dto.Review.GetReview;
using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Presentation.Http.Controllers;

[Route("/api/review")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet("{reviewId}")]
    public async Task<ActionResult> GetReviewAsync(Guid reviewId)
    {
        try
        {
            ReviewModel review = await _reviewService.GetReviewAsync(reviewId);
            var responseDto = new GetReviewResponseDto(review.TextOfReview, review.Rating);
            return Ok(responseDto);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddNewReview([FromBody] AddNewReviewRequestDto requestDto)
    {
        try
        {
            var reviewModel = new ReviewModel
            {
                ReviewId = requestDto.ReviewId,
                TextOfReview = requestDto.TextOfReview,
                Rating = requestDto.Rating,
                SenderId = requestDto.SenderId,
                DateOfReview = requestDto.DateOfReview,
                RecieverId = requestDto.RecieverId,
            };

            await _reviewService.AddNewReview(reviewModel);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{reviewId}")]
    public async Task<ActionResult> DeleteReview(Guid reviewId, [FromBody] DeleteReviewRequestDto requestDto)
    {
        try
        {
            await _reviewService.DeleteReview(reviewId, requestDto.SenderId);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("{reviewId}")]
    public async Task<ActionResult> ChangeReview(Guid reviewId, [FromBody] ChangeReviewRequestDto requestDto)
    {
        try
        {
            if (reviewId != requestDto.ReviewId)
                return BadRequest("Provided ReviewId does not match the route parameter.");

            await _reviewService.ChangeReview(reviewId, requestDto.TextOfReview, requestDto.Rating);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
