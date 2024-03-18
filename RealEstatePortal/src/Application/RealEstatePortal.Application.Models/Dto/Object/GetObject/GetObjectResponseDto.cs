namespace RealEstatePortal.Application.Models.Dto.Object.GetObject;

public class GetObjectResponseDto(int sellerId, int realtorId, int square, string area, int roomNumber, int objectStatusId)
{
    public int SellerId { get; set; } = sellerId;

    public int RealtorId { get; set; } = realtorId;

    public int Square { get; set; } = square;

    public string Area { get; set; } = area;

    public int RoomNumber { get; set; } = roomNumber;

    public int ObjectStatusId { get; set; } = objectStatusId;
}