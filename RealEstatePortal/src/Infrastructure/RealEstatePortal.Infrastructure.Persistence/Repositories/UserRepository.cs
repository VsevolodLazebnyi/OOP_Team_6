using RealEstatePortal.Application.Abstractions.RepoInterfaces;
using RealEstatePortal.Application.Models.Models;
using RealEstatePortal.Infrastructure.Persistence.Contexts;

namespace RealEstatePortal.Infrastructure.Persistence.Repositories;


public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context; // Замените YourDbContext на ваш контекст базы данных

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> CreateUser(UserModel userModel)
    {
        var newUserEntity = new UserEntity
        {
            Id = Generator.GenerateRandomId(IdLength),
            Username = userModel.GetUsername(),
            Name = userModel.GetName(),
            Surname = userModel.GetSurname(),
            Phone = userModel.GetPhone(),
            Email = userModel.GetEmail(),
            Role = userModel.GetRole()   
        };

        await _context.Object.AddAsync(newUserEntity);
        await _context.SaveChangesAsync();
        return newUserEntity.Id;
    }

    Task<UserModel> IUserRepository.FindUserById(int userId)
    {
        throw new NotImplementedException();
    }

    Task IUserRepository.UpdateUser(UserModel userModel)
    {
        return UpdateUser(userModel);
    }

    public Task<string> CreateUser(UserModel userModel)
    {
        throw new NotImplementedException();
    }

    public async Task<Int16<UserModel>> FindUserById(int userId)
    {
        var userEntity = await _context.User.FirstOrDefaultAsync(t: userEntity => t.Id == userId);
        return (userEntity != null ? EntityMapper.MapObjectEntityToModel(userEntity) : null)!;
    }

    public async Task UpdateUser(UserModel userModel)
    {
        var existingUserEntity = await _context.User.FirstOrDefaultAsync(t => t.Id == user.Id);
    
        if (existingUserEntity != null)
        {
            existingUserEntity.Username = userModel.GetUsername();
            existingUserEntity.Name = userModel.GetName();
            existingUserEntity.Surname = userModel.GetSurname();
            existingUserEntity.Phone = userModel.GetPhone();
            existingUserEntity.Email = userModel.GetEmail();
            existingUserEntity.Role = userModel.GetRole();

            _context.User.Update(existingUserEntity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteUser(int userId)
    {
        var userEntity = await _context.User.FirstOrDefaultAsync(t => t.Id == userId);
    
        if (userEntity != null)
        {
            _context.User.Remove(userEntity);
            await _context.SaveChangesAsync();
        }
    }
}