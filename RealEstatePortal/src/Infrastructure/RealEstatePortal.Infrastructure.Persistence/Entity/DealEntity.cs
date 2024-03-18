namespace RealEstatePortal.Infrastructure.Persistence.Entity;

public class DealEntity
{
    public int DealId { get; set; }

    public int ObjectId { get; set; }

    public int CustomerId { get; set; }

    public int RealtorId { get; set; }

    public int DealStatusId { get; set; }

    public DateTime DateDeal { get; set; }
}