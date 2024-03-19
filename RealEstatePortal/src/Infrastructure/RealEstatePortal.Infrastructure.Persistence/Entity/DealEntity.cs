namespace RealEstatePortal.Infrastructure.Persistence.Entity;

public class DealEntity
{
    public Guid DealId { get; set; }

    public Guid ObjectId { get; set; }

    public Guid CustomerId { get; set; }

    public Guid RealtorId { get; set; }

    public Guid DealStatusId { get; set; }

    public DateTime DateDeal { get; set; }
}