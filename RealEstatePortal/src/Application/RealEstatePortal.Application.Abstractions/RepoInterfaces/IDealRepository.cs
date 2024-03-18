using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Abstractions.RepoInterfaces;

public interface IDealRepository
{
    Task<string> CreateDeal(DealModel dealModel);

    Task<DealModel> FindDealById(int dealId);

    Task UpdateDeal(DealModel dealModel);

    Task DeleteDeal(int dealId);
}