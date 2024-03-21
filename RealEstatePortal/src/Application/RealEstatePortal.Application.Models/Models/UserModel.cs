﻿namespace RealEstatePortal.Application.Models.Models;

public class UserModel
{
    public Guid UserId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public int RoleId { get; set; }
}