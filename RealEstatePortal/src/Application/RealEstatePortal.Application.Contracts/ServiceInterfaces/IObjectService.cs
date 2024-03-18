using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Contracts.ServiceInterfaces;

public interface IObjectService
{
    Task<ObjectModel> GetObjectAsync(int objectId);

    Task AddNewObject(ObjectModel objectModel);

    Task DeleteObject(int objectId);

    Task PutRealtorToObject(int objectId, int userId);

    Task GetSellerOfObject(int objectId, int userId);

    Task ChangeRealtorToObject(int objectId, int userId);
}