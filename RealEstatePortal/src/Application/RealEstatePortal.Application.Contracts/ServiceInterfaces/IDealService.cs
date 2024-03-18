using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Contracts.ServiceInterfaces;
public interface IDealService
{
    Task<DealModel> GetDealAsync(int dealId);

    Task<string> AddNewDeal(DealModel dealModel);

    Task DeleteDeal(int dealId);

    Task PutRealtorToDeal(int dealId, int userId);

    Task<DealModel> GetDealStatus(int dealId);

    Task<int> GetBuyerOfDeal(int dealId);
}