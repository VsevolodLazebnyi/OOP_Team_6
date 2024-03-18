namespace RealEstatePortal.Application.Models.Dto.Deal.ChangeDeal;

public class ChangeDealRequestDto(int dealId, int objectId, int customerId)
{
    public int DealId { get; set; } = dealId;

    public int ObjectId { get; set; } = objectId;

    public int CustomerId { get; set; } = customerId;
}