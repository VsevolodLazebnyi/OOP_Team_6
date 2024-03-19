﻿namespace RealEstatePortal.Application.Models.Models;

public class DealModel
{
    public Guid DealId { get; set; }

    public int ObjectId { get; set; }

    public int CustomerId { get; set; }

    public int RealtorId { get; set; }

    public int DealStatusId { get; set; }

    public DateTime DateDeal { get; set; }
}