﻿using MediatR;
using System.Collections.Generic;

namespace VarietyShop.Application.Commands.Users.CreateUser;

public class CreateUserCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Slug { get; set; }
    public bool Active { get; set; }
    public List<int> RolesId { get; set; }
}
