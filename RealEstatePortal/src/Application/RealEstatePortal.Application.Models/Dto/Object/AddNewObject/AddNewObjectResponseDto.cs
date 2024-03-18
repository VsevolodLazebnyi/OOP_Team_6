namespace RealEstatePortal.Application.Models.Dto.Object.AddNewObject;

public class AddNewObjectResponseDto
{
    public class AddNewObjectRequestDto(Guid objectId)
    {
        public Guid ObjectId { get; set; } = objectId;
    }
}