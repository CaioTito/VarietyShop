﻿using MediatR;
using System.Collections.Generic;
using VarietyShop.Application.ViewModels;

namespace VarietyShop.Application.Queries.Roles.GetAllRoles;

public class GetAllRolesQuery : IRequest<List<RoleViewModel>>
{

}
