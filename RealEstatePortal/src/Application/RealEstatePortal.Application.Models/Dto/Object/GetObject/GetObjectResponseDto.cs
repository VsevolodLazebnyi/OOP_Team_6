namespace RealEstatePortal.Application.Models.Dto.Object.GetObject;

public class GetObjectResponseDto(Guid sellerId, Guid realtorId, int square, string area, int roomNumber, int objectStatusId)
{
    public Guid SellerId { get; set; } = sellerId;

    public Guid RealtorId { get; set; } = realtorId;

    public int Square { get; set; } = square;

    public string Area { get; set; } = area;

    public int RoomNumber { get; set; } = roomNumber;

    public int ObjectStatusId { get; set; } = objectStatusId;
}