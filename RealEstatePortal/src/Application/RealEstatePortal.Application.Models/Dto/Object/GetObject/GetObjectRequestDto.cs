#pragma warning disable CA1716
namespace RealEstatePortal.Application.Models.Dto.Object.GetObject;
#pragma warning restore CA1716

public class GetObjectRequestDto(Guid objectId)
{
    public Guid ObjectId { get; set; } = objectId;
}