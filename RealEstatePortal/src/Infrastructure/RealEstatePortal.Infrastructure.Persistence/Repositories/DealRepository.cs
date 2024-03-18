﻿using AutoMapper; // используя автомапер отказываемся от собственных маперов, так понимаю
using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Application.Abstractions.RepoInterfaces;
using RealEstatePortal.Application.Models.Models;
using RealEstatePortal.Infrastructure.Persistence.Contexts;
using RealEstatePortal.Infrastructure.Persistence.Entity;

namespace RealEstatePortal.Infrastructure.Persistence.Repositories;

public class DealRepository : IDealRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper; // мапер наш (входит в автомапер)

    public DealRepository(ApplicationDbContext context, IMapper mapper) // Изменяем конструктор
    {
        _context = context;
        _mapper = mapper; // Инициализируем поле маппера
    }

    public async Task<int> CreateDeal(DealModel dealModel)
    {
        var newDealEntity = new DealEntity
        {
            ObjectId = dealModel.ObjectId(),
            CustomerId = dealModel.CustomerId(),
            RealtorId = dealModel.RealtorId(),
            DealStatusId = dealModel.DealStatusId(),
            DateDeal = dealModel.DateDeal(),
        };

        await _context.Object.AddAsync(newDealEntity);
        await _context.SaveChangesAsync();
        return newDealEntity.Id;
    }

    public async Task<DealModel> FindDealById(int dealId)
    {
        DealEntity? dealEntity = await _context.Deal.FirstOrDefaultAsync(t => t.DealId == dealId);
        return dealEntity != null ? _mapper.Map<DealModel>(dealEntity) : null; // Используем маппер для преобразования сущности в модель
    }

    public async Task UpdateDeal(DealModel dealModel)
    {
        DealEntity? existingDealEntity = await _context.Deal.FirstOrDefaultAsync(t => t.DealId == dealModel.DealId);

        if (existingDealEntity != null)
        {
            // Обновляем данные существующей сделки на основе переданной сделки
            existingDealEntity.Buyer = deal.GetBuyerId();
            existingDealEntity.Seller = deal.GetSellerId();

            _context.Deal.Update(existingDealEntity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteDeal(int dealId)
    {
        DealEntity? dealEntity = await _context.Deal.FirstOrDefaultAsync(t => t.DealId == dealId);

        if (dealEntity != null)
        {
            _context.Deal.Remove(dealEntity);
            await _context.SaveChangesAsync();
        }
    }
}