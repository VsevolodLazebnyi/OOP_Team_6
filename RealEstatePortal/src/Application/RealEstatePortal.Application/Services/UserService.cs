using RealEstatePortal.Application.Abstractions.RepoInterfaces;
using RealEstatePortal.Application.Contracts.ServiceInterfaces;
using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserModel> GetUserAsync(Guid userId)
    {
        UserModel user = await _userRepository.FindUserById(userId);
        if (user == null)
        {
            throw new Exception($"Object with such ID not found");
        }

        return user;
    }

    public async Task<Guid> AddNewUser(UserModel userModel)
    {
        Guid id = await _userRepository.CreateUser(userModel);
        return id;
    }

    public async Task DeleteUser(Guid userId)
    {
        await _userRepository.DeleteUser(userId);
    }

    public async Task<UserModel> GetUserData(Guid userId)
    {
        UserModel user = await _userRepository.FindUserById(userId);
        if (user == null)
        {
            throw new Exception($"User with ID {userId} not found");
        }

        return user;
    }

    public async Task ChangeUserData(Guid userId, string name, string surname, string email, string phone, int roleId)
    {
        UserModel user = await _userRepository.FindUserById(userId);
        if (user == null)
            {
                throw new Exception($"User with ID {userId} not found");
            }

            // user.Username = userModel.Username;
        user.Name = name;
        user.Surname = surname;
        user.Phone = phone;
        user.Email = email;
        user.RoleId = roleId;

        await _userRepository.UpdateUser(user);
    }
}