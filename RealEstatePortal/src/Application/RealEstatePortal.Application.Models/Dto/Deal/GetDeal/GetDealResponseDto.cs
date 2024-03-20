namespace RealEstatePortal.Application.Models.Dto.Deal.GetDeal;

public class GetDealResponseDto(Guid objectId, Guid customerId, Guid realtorId, int dealStatusId, DateTime dateDeal)
{
    public Guid ObjectId { get; set; } = objectId;

    public Guid CustomerId { get; set; } = customerId;

    public Guid RealtorId { get; set; } = realtorId;

    public int DealStatusId { get; set; } = dealStatusId;

    public DateTime DateDeal { get; set; } = dateDeal;
}
