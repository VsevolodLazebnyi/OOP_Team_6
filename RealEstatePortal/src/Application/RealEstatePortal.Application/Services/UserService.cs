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

    public async Task<UserModel> GetUserAsync(int userId)
    {
        var user = await _userRepository.FindUserById(userId);

        return user;
    }

    public async Task AddNewUser(UserModel userModel)
    {
        var id = await _userRepository.CreateUser(userModel);
    }

    public async Task DeleteUser(int userId)
    {
        await _userRepository.DeleteUser(userId);
    }

    public async Task GetUserData(int userId)
    {
        var user = await _userRepository.FindUserById(userId);
        if (user == null)
        {
            throw new Exception($"User with ID {userId} not found");
        }
        return user;
    }

    public async Task ChangeUserData(int userId)
    {
        var user = await _userRepository.FindUserById(userModel.Id);
            if (user == null)
            {
                throw new Exception($"User with ID {userModel.Id} not found");
            }

            // Обновляем данные пользователя
            user.Username = userModel.GetUsername();
            user.Name = userModel.GetName();
            user.Surname = userModel.GetSurname();
            user.Phone = userModel.GetPhone();
            user.Email = userModel.GetEmail();
            user.Role = userModel.GetRole();

            // Вызываем метод репозитория для обновления пользователя
            await _userRepository.UpdateUser(user);
    }
}