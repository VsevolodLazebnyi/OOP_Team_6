using AutoMapper;
using RealEstatePortal.Application.Models.Dto.User.CreateUser;
using RealEstatePortal.Application.Models.Dto.User.GetUser;
using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Infrastructure.Persistence.Mapping;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserModel, GetUserResponseDto>();
        CreateMap<CreateUserRequestDto, UserModel>();

        // Я не ебу как это всё сопоставить
    }
}