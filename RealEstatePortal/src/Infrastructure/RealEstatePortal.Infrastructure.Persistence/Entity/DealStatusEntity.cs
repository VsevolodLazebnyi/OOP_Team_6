using System.ComponentModel.DataAnnotations;

namespace RealEstatePortal.Infrastructure.Persistence.Entity;

public class DealStatusEntity
{
    [Key]
    public int DealStatusId { get; set; }

    public string StatusName { get; set; } = string.Empty;
}