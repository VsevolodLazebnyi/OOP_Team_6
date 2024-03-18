using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Abstractions.RepoInterfaces;

public interface IObjectRepository
{
    Task<string> CreateObject(ObjectModel objectModel);

    Task<ObjectModel> FindObjectById(int objectId);

    Task UpdateObject(ObjectModel objModel);

    Task DeleteObject(int objectId);
}