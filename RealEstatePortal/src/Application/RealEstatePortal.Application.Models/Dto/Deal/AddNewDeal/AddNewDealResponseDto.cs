namespace RealEstatePortal.Application.Models.Dto.Deal.AddNewDeal;

public class AddNewDealResponseDto(Guid dealId)
{
    public Guid DealId { get; set; } = dealId;
}