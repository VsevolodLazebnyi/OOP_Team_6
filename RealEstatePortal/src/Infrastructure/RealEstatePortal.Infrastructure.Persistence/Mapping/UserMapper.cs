using AutoMapper;
using RealEstatePortal.Application.Models.Dto.User.CreateUser;
using RealEstatePortal.Application.Models.Dto.User.GetUser;
using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Infrastructure.Persistence.Mapping;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<GetUserRequestDto, UserModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.UserId, opt => opt.Ignore());
        CreateMap<UserModel, GetUserRequestDto>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Name));

        CreateMap<GetUserResponseDto, UserModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.UserId, opt => opt.Ignore());
        CreateMap<UserModel, GetUserResponseDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<CreateUserRequestDto, UserModel>()
            .ForMember(dest => dest.UserId, opt => opt.Ignore());
        CreateMap<UserModel, CreateUserRequestDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<CreateUserResponseDto, UserModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.UserId, opt => opt.Ignore());
        CreateMap<UserModel, GetUserResponseDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        // Я  как это всё сопоставить
    }
}