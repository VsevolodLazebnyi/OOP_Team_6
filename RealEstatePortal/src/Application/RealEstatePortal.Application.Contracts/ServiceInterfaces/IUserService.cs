using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Contracts.ServiceInterfaces;

public interface IUserService
{
    Task<UserModel> GetUserAsync(int userId);

    Task AddNewUser(UserModel userModel);

    Task DeleteUser(int userId);

    Task GetUserData(int userId);

    Task ChangeUserData(int userId);
}