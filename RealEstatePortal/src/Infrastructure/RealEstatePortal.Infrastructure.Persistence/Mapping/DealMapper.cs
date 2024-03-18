using AutoMapper;
using RealEstatePortal.Application.Models.Dto.Deal.AddNewDeal;
using RealEstatePortal.Application.Models.Dto.Deal.GetDeal;
using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Infrastructure.Persistence.Mapping;

public class DealMapper : Profile
{
    public DealMapper()
    {
        CreateMap<DealModel, GetDealResponseDto>();
        CreateMap<AddNewDealRequestDto, DealModel>();

        // Добавьте другие необходимые маппинги, если есть
    }
}