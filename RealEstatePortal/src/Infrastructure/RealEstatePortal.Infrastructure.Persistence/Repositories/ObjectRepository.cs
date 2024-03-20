using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Application.Abstractions.RepoInterfaces;
using RealEstatePortal.Application.Models.Models;
using RealEstatePortal.Infrastructure.Persistence.Contexts;
using RealEstatePortal.Infrastructure.Persistence.Entity;

namespace RealEstatePortal.Infrastructure.Persistence.Repositories;

public class ObjectRepository : IObjectRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ObjectRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> CreateObject(ObjectModel objectModel)
    {
        var newObjectEntity = new ObjectEntity
        {
            ObjectId = Guid.NewGuid(),
            SellerId = objectModel.SellerId,
            RealtorId = objectModel.RealtorId,
            Square = objectModel.Square,
            Area = objectModel.Area,
            RoomNumber = objectModel.RoomNumber,
            ObjectStatusId = objectModel.ObjectStatusId,

            // цена
        };

        await _context.Object.AddAsync(newObjectEntity);
        await _context.SaveChangesAsync();
        return newObjectEntity.ObjectId;
    }

    public async Task<ObjectModel> FindObjectById(Guid objectId)
    {
        ObjectEntity? objectEntity = await _context.Object.FirstOrDefaultAsync(t => t.ObjectId == objectId);
        return (objectEntity != null ? _mapper.Map<ObjectModel>(objectEntity) : null)!;
    }

    public async Task UpdateObject(ObjectModel objModel)
    {
        ObjectEntity? existingObjectEntity = await _context.Object.FirstOrDefaultAsync(t => t.ObjectId == objModel.ObjectId);

        if (existingObjectEntity != null)
        {
            existingObjectEntity.RealtorId = objModel.RealtorId;
            existingObjectEntity.ObjectStatusId = objModel.ObjectStatusId;

            _context.Object.Update(existingObjectEntity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteObject(Guid objectId)
    {
        ObjectEntity? objectEntity = await _context.Object.FirstOrDefaultAsync(t => t.ObjectId == objectId);

        if (objectEntity != null)
        {
            _context.Object.Remove(objectEntity);
            await _context.SaveChangesAsync();
        }
    }
}