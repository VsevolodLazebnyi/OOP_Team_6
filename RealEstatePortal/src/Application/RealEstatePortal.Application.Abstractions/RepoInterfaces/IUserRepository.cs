using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Abstractions.RepoInterfaces;

public interface IUserRepository
{
    Task<string> CreateUser(UserModel userModel);

    Task<UserModel> FindUserById(int userId); // исправил такиештуки везде Task***<Int16***<UserModel>> FindUserById(int userId);

    Task UpdateUser(UserModel userModel);

    Task DeleteUser(int userId);
}