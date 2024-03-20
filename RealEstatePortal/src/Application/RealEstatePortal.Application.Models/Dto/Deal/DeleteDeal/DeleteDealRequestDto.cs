namespace RealEstatePortal.Application.Models.Dto.Deal.DeleteDeal;

public class DeleteDealRequestDto(Guid dealId)
{
    public Guid DealId { get; set; } = dealId;
}