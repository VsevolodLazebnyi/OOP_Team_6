namespace RealEstatePortal.Application.Models.Dto.Deal.ChangeDeal;

public class ChangeDealRequestDto(Guid dealId, Guid objectId, Guid customerId)
{
    public Guid DealId { get; set; } = dealId;

    public Guid ObjectId { get; set; } = objectId;

    public Guid CustomerId { get; set; } = customerId;
}