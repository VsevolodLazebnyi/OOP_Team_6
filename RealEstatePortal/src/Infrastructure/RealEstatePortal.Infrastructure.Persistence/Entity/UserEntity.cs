using System.ComponentModel.DataAnnotations;

namespace RealEstatePortal.Infrastructure.Persistence.Entity;

public class UserEntity
{
    [Key]
    public Guid UserId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public int RoleId { get; set; }
}