using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Abstractions.RepoInterfaces;

public interface IUserRepository
{
    Task<Guid> CreateUser(UserModel userModel);

    Task<UserModel> FindUserById(Guid userId);

    Task UpdateUser(UserModel userModel);

    Task DeleteUser(Guid userId);
}