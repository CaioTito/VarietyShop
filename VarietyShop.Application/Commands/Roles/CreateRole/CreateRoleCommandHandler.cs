using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Commands.Roles.CreateRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, int>
{
    private readonly IRoleRepository _roleRepository;

    public CreateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    public async Task<int> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var slug = request.Name
            .ToLower()
            .Replace(" ", "-");

        var role = new Role
        {
            Name = request.Name,
            Slug = slug,
            Active = request.Active
        };

        await _roleRepository.AddAsync(role);

        return role.Id;
    }
}
