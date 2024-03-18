using RealEstatePortal.Application.Abstractions.RepoInterfaces;
using RealEstatePortal.Application.Contracts.ServiceInterfaces;
using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Services;

public class ObjectService : IObjectService
{
    private readonly IObjectRepository _objectRepository;
    private readonly IUserRepository _userRepository;

    public ObjectService(IObjectRepository objectRepository)
    {
        _objectRepository = objectRepository;
    }
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ObjectModel> GetObjectAsync(int objectId)
    {
        var obj = await _objectRepository.FindObjectById(objectId);
        if (obj == null)
        {
            throw new Exception($"Object with such ID not found");
        }

        return obj;
    }

    public async Task AddNewObject(ObjectModel objectModel)
    {
        var id = await _objectRepository.CreateObject(objectModel);
    }

    public async Task DeleteObject(Guid guid, int objectId)
    {
        await _objectRepository.DeleteObject(objectId);
    }

    public async Task PutRealtorToObject(int objectId, int userId)
    {
        var obj = await _objectRepository.FindObjectById(objectId);
        if (obj != null)
        {
            // Устанавливаем RealtorId для объекта
            obj.UserId = userId;
            await _objectRepository.UpdateObject(obj); // Обновляем объект
        }
        else
        {
            throw new Exception($"Object with ID {objectId} not found");
        }
    }

    public async Task GetSellerOfObject(int objectId, int userId)
    {
        var obj = await _objectRepository.FindObjectById(objectId);
        if (obj == null)
        {
            throw new Exception($"Object with ID {objectId} not found");
        }

        if (obj.UserId != userId)
        {
            throw new Exception($"User with ID {userId} is not the seller of object with ID {objectId}");
        }

        var seller = await _userRepository.FindUserById(userId);
        if (seller == null)
        {
            throw new Exception($"Seller with ID {userId} not found");
        }

        return seller;
    }

    public async Task ChangeRealtorToObject(int objectId, int userId)
    {
        var obj = await _objectRepository.FindObjectById(objectId);
        if (obj == null)
        {
            throw new Exception($"Object with ID {objectId} not found");
        }

        var user = await _userRepository.FindUserById(userId);
        if (user == null)
        {
            throw new Exception($"User with ID {userId} not found");
        }

        obj.UserId = userId;
        await _objectRepository.UpdateObject(obj);
    }
}