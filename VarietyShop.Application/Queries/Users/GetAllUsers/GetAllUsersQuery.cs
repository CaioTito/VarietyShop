using MediatR;
using System.Collections.Generic;
using VarietyShop.Application.ViewModels;

namespace VarietyShop.Application.Queries.Users.GetAllUsers;

public class GetAllUsersQuery : IRequest<List<UserViewModel>>
{

}
