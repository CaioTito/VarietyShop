using MediatR;
using VarietyShop.Application.ViewModels;

namespace VarietyShop.Application.Queries.Roles.GetRoleById;

public class GetRoleByIdQuery : IRequest<RoleViewModel>
{
    public GetRoleByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
