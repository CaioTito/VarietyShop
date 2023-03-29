using MediatR;

namespace VarietyShop.Application.Commands.Roles.CreateRole;

public class CreateRoleCommand : IRequest<int>
{
    public string Name { get; set; }
    public bool Active { get; set; }
}
