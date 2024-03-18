namespace RealEstatePortal.Application.Models.Dto.Deal.GetDeal;

public class GetDealRequestDto(int dealId)
{
    public int DealId { get; set; } = dealId;
}