using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Abstractions.RepoInterfaces;

public interface IDealRepository
{
    Task<Guid> CreateDeal(DealModel dealModel);

    Task<DealModel> FindDealById(Guid dealId);

    Task UpdateDeal(DealModel dealModel);

    Task DeleteDeal(Guid dealId);
}