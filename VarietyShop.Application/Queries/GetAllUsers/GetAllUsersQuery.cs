using MediatR;
using System.Collections.Generic;
using VarietyShop.Application.ViewModels;

namespace VarietyShop.Application.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<List<UserViewModel>>
{

}
