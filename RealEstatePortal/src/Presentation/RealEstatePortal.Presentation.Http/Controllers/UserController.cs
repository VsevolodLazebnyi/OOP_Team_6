using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstatePortal.Application.Contracts.ServiceInterfaces;
using RealEstatePortal.Application.Models.Dto.User.CreateUser;
using RealEstatePortal.Application.Models.Dto.User.GetUser;
using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Presentation.Http.Controllers;

[Route("/api/user")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<GetUserResponseDto>> GetUserAsync(Guid userId)
    {
        try
        {
            UserModel user = await _userService.GetUserAsync(userId);
            GetUserResponseDto userDto = _mapper.Map<GetUserResponseDto>(user);
            return Ok(userDto);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<CreateUserResponseDto>> AddNewUser([FromBody] CreateUserRequestDto request)
    {
        try
        {
            UserModel userModel = _mapper.Map<UserModel>(request);
            Guid userId = await _userService.AddNewUser(userModel);
            var responseDto = new CreateUserResponseDto(userId);
            Console.WriteLine(userModel.Name);
            return Ok(responseDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{userId}")]
    public async Task<ActionResult> DeleteUser(Guid userId)
    {
        try
        {
            await _userService.DeleteUser(userId);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
