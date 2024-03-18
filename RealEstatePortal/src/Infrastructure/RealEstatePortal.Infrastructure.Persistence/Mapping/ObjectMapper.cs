using AutoMapper;
using RealEstatePortal.Application.Models.Dto.Object.AddNewObject;
using RealEstatePortal.Application.Models.Dto.Object.GetObject;
using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Infrastructure.Persistence.Mapping;

public class ObjectMapper : Profile
{
    public ObjectMapper()
    {
        CreateMap<ObjectModel, GetObjectResponseDto>();
        CreateMap<AddNewObjectRequestDto, ObjectModel>();
        // Добавьте другие необходимые маппинги, если есть
    }
}