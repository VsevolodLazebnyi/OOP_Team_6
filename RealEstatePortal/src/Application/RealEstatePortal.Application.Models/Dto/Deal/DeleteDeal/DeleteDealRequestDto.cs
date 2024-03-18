namespace RealEstatePortal.Application.Models.Dto.Deal.DeleteDeal;

public class DeleteDealRequestDto(int dealId)
{
    public int DealId { get; set; } = dealId;
}