﻿namespace RealEstatePortal.Application.Models.Dto.User.CreateUser;

public class CreateUserRequestDto(string name, string surname, string email, string phone, int roleId)
{
    public string Name { get; set; } = name;

    public string Surname { get; set; } = surname;

    public string Email { get; set; } = email;

    public string Phone { get; set; } = phone;

    public int RoleId { get; set; } = roleId;
}