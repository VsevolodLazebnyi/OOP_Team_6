using System.ComponentModel.DataAnnotations;

namespace RealEstatePortal.Infrastructure.Persistence.Entity;

public class RoleEntity
{
    [Key]
    public Guid RoleId { get; set; }

    public string RoleName { get; set; } = string.Empty;
}