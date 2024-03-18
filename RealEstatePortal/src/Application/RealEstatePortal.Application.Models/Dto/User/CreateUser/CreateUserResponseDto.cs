namespace RealEstatePortal.Application.Models.Dto.User.CreateUser;

public class CreateUserResponseDto(Guid userId)
{
    public Guid UserId { get; set; } = userId;
}