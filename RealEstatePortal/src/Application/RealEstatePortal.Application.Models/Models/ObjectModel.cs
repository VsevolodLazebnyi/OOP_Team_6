#pragma warning disable CA1724
namespace RealEstatePortal.Application.Models.Models;

public class ObjectModel
{
    public Guid ObjectId { get; set; }

    public Guid SellerId { get; set; }

    public Guid RealtorId { get; set; }

    public int Square { get; set; }

    public string Area { get; set; } = string.Empty;

    public int RoomNumber { get; set; }

    public int ObjectStatusId { get; set; }
}