using System.ComponentModel.DataAnnotations;

namespace RealEstatePortal.Infrastructure.Persistence.Entity;

public class DealEntity
{
    [Key]
    public Guid DealId { get; set; }

    public Guid ObjectId { get; set; }

    public Guid CustomerId { get; set; }

    public Guid RealtorId { get; set; }

    public int DealStatusId { get; set; }

    public DateTime DateDeal { get; set; }
}