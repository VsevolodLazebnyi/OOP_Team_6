using RealEstatePortal.Application.Abstractions.RepoInterfaces;
using RealEstatePortal.Application.Contracts.ServiceInterfaces;
using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Services;

public class ObjectService : IObjectService
{
    private readonly IObjectRepository _objectRepository;
    private readonly IUserRepository _userRepository;

    public ObjectService(IObjectRepository objectRepository, IUserRepository userRepository)
    {
        _objectRepository = objectRepository;
        _userRepository = userRepository;
    }

    public async Task<ObjectModel> GetObjectAsync(Guid objectId)
    {
        ObjectModel obj = await _objectRepository.FindObjectById(objectId);
        if (obj == null)
        {
            throw new Exception($"Object with such ID not found");
        }

        return obj;
    }

    public async Task<Guid> AddNewObject(ObjectModel objectModel)
    {
        Guid id = await _objectRepository.CreateObject(objectModel);
        return id;
    }

    public async Task DeleteObject(Guid objectId)
    {
        await _objectRepository.DeleteObject(objectId);
    }

    public async Task PutRealtorToObject(Guid objectId, Guid userId)
    {
        ObjectModel obj = await _objectRepository.FindObjectById(objectId);
        if (obj != null)
        {
            obj.RealtorId = userId;
            await _objectRepository.UpdateObject(obj);
        }
        else
        {
            throw new Exception($"Object with ID {objectId} not found");
        }
    }

    public async Task<UserModel> GetSellerOfObject(Guid objectId, Guid userId)
    {
        ObjectModel obj = await _objectRepository.FindObjectById(objectId);
        if (obj == null)
        {
            throw new Exception($"Object with ID {objectId} not found");
        }

        if (obj.SellerId != userId)
        {
            throw new Exception($"User with ID {userId} is not the seller of object with ID {objectId}");
        }

        UserModel seller = await _userRepository.FindUserById(userId);
        if (seller == null)
        {
            throw new Exception($"Seller with ID {userId} not found");
        }

        return seller;
    }

    public async Task ChangeRealtorToObject(Guid objectId, Guid userId)
    {
        ObjectModel obj = await _objectRepository.FindObjectById(objectId);
        if (obj == null)
        {
            throw new Exception($"Object with ID {objectId} not found");
        }

        UserModel user = await _userRepository.FindUserById(userId);
        if (user == null)
        {
            throw new Exception($"User with ID {userId} not found");
        }

        obj.RealtorId = userId;
        await _objectRepository.UpdateObject(obj);
    }
}