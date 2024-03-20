namespace RealEstatePortal.Application.Models.Dto.Deal.GetDeal;

public class GetDealRequestDto(Guid dealId)
{
    public Guid DealId { get; set; } = dealId;
}