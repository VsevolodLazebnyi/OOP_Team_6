namespace RealEstatePortal.Application.Models.Dto.User.GetUser;

public class GetUserRequestDto(Guid userId)
{
    public Guid UserId { get; set; } = userId;
}