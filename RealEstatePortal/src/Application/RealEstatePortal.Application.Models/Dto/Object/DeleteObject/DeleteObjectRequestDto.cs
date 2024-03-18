#pragma warning disable CA1716
namespace RealEstatePortal.Application.Models.Dto.Object.DeleteObject;
#pragma warning restore CA1716

public class DeleteObjectRequestDto(Guid objectId)
{
    public Guid ObjectId { get; set; } = objectId;
}