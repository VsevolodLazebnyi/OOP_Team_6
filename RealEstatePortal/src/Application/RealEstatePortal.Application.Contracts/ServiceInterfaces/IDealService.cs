using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Contracts.ServiceInterfaces;
public interface IDealService
{
    Task<DealModel> GetDealAsync(Guid dealId);

    Task<Guid> AddNewDeal(DealModel dealModel);

    Task DeleteDeal(Guid dealId);

    Task PutRealtorToDeal(Guid dealId, Guid userId);

    Task<DealModel> GetDealStatus(Guid dealId);

    Task<Guid> GetBuyerOfDeal(Guid dealId);
}