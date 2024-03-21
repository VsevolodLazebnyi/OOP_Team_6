﻿namespace RealEstatePortal.Application.Models.Dto.User.ChangeUser;

public class ChangeUserRequestDto(Guid userId, string name, string surname, string email, string phone, int roleId)
{
    public Guid UserId { get; set; } = userId;

    public string Name { get; set; } = name;

    public string Surname { get; set; } = surname;

    public string Email { get; set; } = email;

    public string Phone { get; set; } = phone;

    public int RoleId { get; set; } = roleId;
}