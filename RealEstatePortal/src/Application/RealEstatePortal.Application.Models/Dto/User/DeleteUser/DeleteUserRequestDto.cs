namespace RealEstatePortal.Application.Models.Dto.User.DeleteUser;

public class DeleteUserRequestDto(Guid userId)
{
    public Guid UserId { get; set; } = userId;
}