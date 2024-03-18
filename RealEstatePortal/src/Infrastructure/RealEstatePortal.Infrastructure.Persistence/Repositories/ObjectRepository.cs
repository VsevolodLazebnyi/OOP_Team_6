using RealEstatePortal.Application.Abstractions.RepoInterfaces;
using RealEstatePortal.Infrastructure.Persistence.Contexts;

namespace RealEstatePortal.Infrastructure.Persistence.Repositories;

public class ObjectRepository : IObjectRepository
{
    private readonly ApplicationDbContext _context; 

    public ObjectRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> CreateObject(ObjectModel objectModel)
    {
        var newObjectEntity = new ObjectEntity
        {
            Id = Generator.GenerateRandomId(),
            Price = objectModel.GetPrice(),
            Seller = objectModel.GetId()
        };

        await _context.Object.AddAsync(newObjectEntity);
        await _context.SaveChangesAsync();
        return newObjectEntity.Id;
    }

    public async Task<Int16<ObjectModel>> FindObjectById(int objectId)
    {
        var objectEntity = await _context.Object.FirstOrDefaultAsync(t: objectEntity => t.Id == objectId);
        return (objectEntity != null ? EntityMapper.MapObjectEntityToModel(objectEntity) : null)!;
    }

    public async Task UpdateObject(ObjectModel objModel)
    {
        var existingObjectEntity = await _context.Object.FirstOrDefaultAsync(t => t.Id == obj.Id);
    
        if (existingObjectEntity != null)
        {
            existingObjectEntity.Price = obj.GetPrice();
            existingObjectEntity.Seller = obj.GetSellerId();

            _context.Object.Update(existingObjectEntity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteObject(int objectId)
    {
        var objectEntity = await _context.Object.FirstOrDefaultAsync(t => t.Id == objectId);
    
        if (objectEntity != null)
        {
            _context.Object.Remove(objectEntity);
            await _context.SaveChangesAsync();
        }
    }
}