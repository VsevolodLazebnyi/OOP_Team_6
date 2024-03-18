#pragma warning disable CA1716
namespace RealEstatePortal.Application.Models.Dto.Object.AddNewObject;
#pragma warning restore CA1716

public class AddNewObjectRequestDto(Guid objectId, int sellerId, int realtorId, int square, string area, int roomNumber, int objectStatusId)
{
    public Guid ObjectId { get; set; } = objectId;

    public int SellerId { get; set; } = sellerId;

    public int RealtorId { get; set; } = realtorId;

    public int Square { get; set; } = square;

    public string Area { get; set; } = area;

    public int RoomNumber { get; set; } = roomNumber;

    public int ObjectStatusId { get; set; } = objectStatusId;
}