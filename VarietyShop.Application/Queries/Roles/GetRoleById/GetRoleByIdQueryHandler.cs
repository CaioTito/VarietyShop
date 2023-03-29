using MediatR;
using VarietyShop.Application.ViewModels;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Queries.Roles.GetRoleById;

public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleViewModel>
{
    private readonly IRoleRepository _roleRepository;

    public GetRoleByIdQueryHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<RoleViewModel> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(request.Id);

        return new RoleViewModel(role.Id, role.Name, role.Slug, role.Active);
    }
}
