using MediatR;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Commands.Roles.DeleteRole;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, Unit>
{
    private readonly IRoleRepository _roleRepository;

    public DeleteRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(request.Id);

        role.Deactivate();

        await _roleRepository.SaveChangesAsync();

        return Unit.Value;
    }
}
