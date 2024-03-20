using AutoMapper; // используя автомапер отказываемся от собственных маперов, так понимаю
using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Application.Abstractions.RepoInterfaces;
using RealEstatePortal.Application.Models.Models;
using RealEstatePortal.Infrastructure.Persistence.Contexts;
using RealEstatePortal.Infrastructure.Persistence.Entity;

namespace RealEstatePortal.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context; // Замените YourDbContext на ваш контекст базы данных
    private readonly IMapper _mapper;

    public UserRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> CreateUser(UserModel userModel)
    {
        var newUserEntity = new UserEntity
        {
            UserId = Guid.NewGuid(),

            // Username = userModel.GetUsername(),
            Name = userModel.Name,
            Surname = userModel.Surname,
            Phone = userModel.Phone,
            Email = userModel.Email,
            RoleId = userModel.RoleId,
        };

        await _context.User.AddAsync(newUserEntity);
        await _context.SaveChangesAsync();
        return newUserEntity.UserId;
    }

    public async Task<UserModel> FindUserById(Guid userId)
    {
        UserEntity? userEntity = await _context.User.FirstOrDefaultAsync(t => t.UserId == userId);
        return (userEntity != null ? _mapper.Map<UserModel>(userEntity) : null)!;
    }

    public async Task UpdateUser(UserModel userModel)
    {
        UserEntity? existingUserEntity = await _context.User.FirstOrDefaultAsync(t => t.UserId == userModel.UserId);

        if (existingUserEntity != null)
        {
            // existingUserEntity.Username = userModel.Username;
            existingUserEntity.Name = userModel.Name;
            existingUserEntity.Surname = userModel.Surname;
            existingUserEntity.Phone = userModel.Phone;
            existingUserEntity.Email = userModel.Email;
            existingUserEntity.RoleId = userModel.RoleId;

            _context.User.Update(existingUserEntity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteUser(Guid userId)
    {
        UserEntity? userEntity = await _context.User.FirstOrDefaultAsync(t => t.UserId == userId);

        if (userEntity != null)
        {
            _context.User.Remove(userEntity);
            await _context.SaveChangesAsync();
        }
    }
}