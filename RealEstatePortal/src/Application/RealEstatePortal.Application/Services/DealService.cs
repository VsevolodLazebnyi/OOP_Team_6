using RealEstatePortal.Application.Abstractions.RepoInterfaces;
using RealEstatePortal.Application.Contracts.ServiceInterfaces;
using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Application.Services;

public class DealService : IDealService
{
    private readonly IDealRepository _dealRepository;

    public DealService(IDealRepository dealRepository)
    {
        _dealRepository = dealRepository;
    }

    public async Task<DealModel> GetDealAsync(int dealId)
    {
        DealModel deal = await _dealRepository.FindDealById(dealId);
        if (deal == null)
        {
            throw new Exception($"Object with such ID not found");
        }

        return deal;
    }

    public async Task<string> AddNewDeal(DealModel dealModel)
    {
        string id = await _dealRepository.CreateDeal(dealModel);
        return id;
    }

    public async Task DeleteDeal(int dealId)
    {
        await _dealRepository.DeleteDeal(dealId);
    }

    public async Task PutRealtorToDeal(int dealId, int userId)
    {
        DealModel deal = await _dealRepository.FindDealById(dealId);
        if (deal != null)
        {
            deal.RealtorId = userId;
            await _dealRepository.UpdateDeal(deal); 
        }
        else
        {
            throw new Exception($"Object with ID {dealId} not found");
        }
    }

    public async Task<DealModel> GetDealStatus(int dealId)
    {
        DealModel deal = await _dealRepository.FindDealById(dealId);

        return deal.Status;
    }

    public async Task<int> GetBuyerOfDeal(int dealId)
    {
        DealModel deal = await _dealRepository.FindDealById(dealId);
        if (deal == null)
        {
            throw new Exception($"Object with ID {dealId} not found");
        }

        return deal.UserId;
    }
}