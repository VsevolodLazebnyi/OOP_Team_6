using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Abstractions.RepoInterfaces;

public interface IObjectRepository
{
    Task<Guid> CreateObject(ObjectModel objectModel);

    Task<ObjectModel> FindObjectById(Guid objectId);

    Task UpdateObject(ObjectModel objModel);

    Task DeleteObject(Guid objectId);
}