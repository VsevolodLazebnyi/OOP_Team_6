using Microsoft.AspNetCore.Mvc;
using RealEstatePortal.Application.Contracts.ServiceInterfaces;
using RealEstatePortal.Application.Models.Dto.Object.AddNewObject;

// using RealEstatePortal.Application.Models.Dto.Object.ChangeObject;
// using RealEstatePortal.Application.Models.Dto.Object.DeleteObject;
// using RealEstatePortal.Application.Models.Dto.Object.GetObject;
using RealEstatePortal.Application.Models.Models;

namespace RealEstatePortal.Presentation.Http.Controllers;

[Route("/api/object")]
[ApiController]

public class ObjectController : Controller
{
    private readonly IObjectService _objectService;

    public ObjectController(IObjectService objectService)
    {
        _objectService = objectService;
    }

    [HttpGet("{objectId}")]
    public async Task<ActionResult<ObjectModel>> GetObjectAsync(Guid objectId)
    {
        try
        {
            ObjectModel obj = await _objectService.GetObjectAsync(objectId);
            return Ok(obj);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddNewObject([FromBody] AddNewObjectRequestDto request)
    {
        try
        {
            var objectModel = new ObjectModel
            {
                SellerId = request.SellerId,
                RealtorId = request.RealtorId,
                Square = request.Square,
                Area = request.Area,
                RoomNumber = request.RoomNumber,
                ObjectStatusId = request.ObjectStatusId,
            };

            await _objectService.AddNewObject(objectModel);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{objectId}")]
    public async Task<ActionResult> DeleteObject(Guid objectId)
    {
        try
        {
            await _objectService.DeleteObject(objectId);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("{objectId}/realtor/{userId}")]
    public async Task<ActionResult> PutRealtorToObject(Guid objectId, Guid userId)
    {
        try
        {
            await _objectService.PutRealtorToObject(objectId, userId);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("{objectId}/seller/{userId}")]
    public async Task<ActionResult> GetSellerOfObject(Guid objectId, Guid userId)
    {
        try
        {
            await _objectService.GetSellerOfObject(objectId, userId);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("{objectId}/change-realtor/{userId}")]
    public async Task<ActionResult> ChangeRealtorToObject(Guid objectId, Guid userId)
    {
        try
        {
            await _objectService.ChangeRealtorToObject(objectId, userId);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
