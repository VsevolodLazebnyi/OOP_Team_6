namespace RealEstatePortal.Infrastructure.Persistence.Entity;

public class ObjectEntity
{
    public Guid ObjectId { get; set; }

    public Guid SellerId { get; set; }

    public Guid RealtorId { get; set; }

    public int Square { get; set; }

    public string Area { get; set; } = string.Empty;

    public int RoomNumber { get; set; }

    public int ObjectStatusId { get; set; }
}