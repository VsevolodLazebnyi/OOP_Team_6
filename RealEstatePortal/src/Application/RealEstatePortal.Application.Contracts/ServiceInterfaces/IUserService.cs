using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Contracts.ServiceInterfaces;

public interface IUserService
{
    Task<UserModel> GetUserAsync(Guid userId);

    Task<Guid> AddNewUser(UserModel userModel);

    Task DeleteUser(Guid userId);

    Task<UserModel> GetUserData(Guid userId);

    Task ChangeUserData(Guid userId, string name, string surname, string email, string phone, int roleId);
}