namespace RealEstatePortal.Application.Models.Dto.Deal.GetDeal;

public class GetDealResponseDto(int objectId, int customerId, int realtorId, int dealStatusId, DateTime dateDeal)
{
    public int ObjectId { get; set; } = objectId;

    public int CustomerId { get; set; } = customerId;

    public int RealtorId { get; set; } = realtorId;

    public int DealStatusId { get; set; } = dealStatusId;

    public DateTime DateDeal { get; set; } = dateDeal;
}
