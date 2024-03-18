namespace RealEstatePortal.Application.Models.Dto.Deal.AddNewDeal;

public class AddNewDealResponseDto(int dealId)
{
    public int DealId { get; set; } = dealId;
}