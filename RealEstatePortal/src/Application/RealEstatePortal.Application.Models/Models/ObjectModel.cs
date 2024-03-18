#pragma warning disable CA1724
namespace RealEstatePortal.Application.Models.Models;

public class ObjectModel
{
    public int SellerId { get; set; }

    public int RealtorId { get; set; }

    public int Square { get; set; }

    public string Area { get; set; } = string.Empty;

    public int RoomNumber { get; set; }

    public int ObjectStatusId { get; set; }
}