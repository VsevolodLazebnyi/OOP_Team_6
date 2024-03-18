using AutoMapper;
using RealEstatePortal.Application.Models.Dto.Review.AddNewReview;
using RealEstatePortal.Application.Models.Dto.Review.GetReview;
using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Infrastructure.Persistence.Mapping;

public class ReviewMapper : Profile
{
    public ReviewMapper()
    {
        CreateMap<ReviewModel, GetReviewResponseDto>();
        CreateMap<AddNewReviewRequestDto, ReviewModel>();
        // Добавьте другие необходимые маппинги, если есть
    }
}