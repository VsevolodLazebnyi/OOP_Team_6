using System.ComponentModel.DataAnnotations;

namespace RealEstatePortal.Infrastructure.Persistence.Entity;

public class ObjectStatusEntity
{
    [Key]
    public Guid ObjectStatusId { get; set; }

    public string StatusName { get; set; } = string.Empty;
}