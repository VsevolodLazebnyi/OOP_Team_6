using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Contracts.ServiceInterfaces;

public interface IObjectService
{
    Task<ObjectModel> GetObjectAsync(Guid objectId);

    Task<Guid> AddNewObject(ObjectModel objectModel);

    Task DeleteObject(Guid objectId);

    Task PutRealtorToObject(Guid objectId, Guid userId);

    Task<UserModel> GetSellerOfObject(Guid objectId, Guid userId);

    Task ChangeRealtorToObject(Guid objectId, Guid userId);
}