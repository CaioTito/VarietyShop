using MediatR;

namespace VarietyShop.Application.Commands.Roles.DeleteRole;

public class DeleteRoleCommand : IRequest<Unit>
{
    public DeleteRoleCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
