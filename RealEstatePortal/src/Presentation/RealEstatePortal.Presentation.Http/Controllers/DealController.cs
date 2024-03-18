using AutoMapper; //хз как артем обошёлся без мапера

using Microsoft.AspNetCore.Mvc;
using RealEstatePortal.Application.Contracts.ServiceInterfaces;
using RealEstatePortal.Application.Models.Dto.Deal.AddNewDeal;
using RealEstatePortal.Application.Models.Dto.Deal.GetDeal;
using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Presentation.Http.Controllers;

[Route("/api/deal")]
[ApiController]

public class DealController : Controller
{
    private readonly IDealService _dealService;

    public DealController(IDealService dealService)
    {
        _dealService = dealService;
    }

    [HttpGet("{dealId}")]
    public async Task<ActionResult<GetDealResponseDto>> GetDealAsync(int dealId)
    {
        try
        {
            DealModel deal = await _dealService.GetDealAsync(dealId);
            return new GetDealResponseDto(deal.ObjectId, deal.CustomerId, deal.RealtorId, deal.DealStatusId, deal.DateDeal);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddNewDeal([FromBody] AddNewDealRequestDto request)
    {
        try
        {
            var model = new DealModel();
            model.ObjectId = request.ObjectId;
            model.CustomerId = request.CustomerId;
            model.RealtorId = request.RealtorId;
            model.DealStatusId = request.DealStatusId;
            model.DateDeal = request.DateDeal;
            await _dealService.AddNewDeal(model);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{dealId}")]
    public async Task<ActionResult> DeleteDeal(int dealId)
    {
        try
        {
            await _dealService.DeleteDeal(dealId);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("{dealId}/realtor/{userId}")]
    public async Task<ActionResult> PutRealtorToDeal(int dealId, int userId)
    {
        try
        {
            await _dealService.PutRealtorToDeal(dealId, userId);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("{dealId}/status")]
    public async Task<ActionResult> GetDealStatus(int dealId)
    {
        try
        {
            DealModel status = await _dealService.GetDealStatus(dealId);
            return Ok(status);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("{dealId}/buyer/{userId}")]
    public async Task<ActionResult> GetBuyerOfDeal(int dealId)
    {
        try
        {
            int buyer = await _dealService.GetBuyerOfDeal(dealId);
            return Ok(buyer);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}