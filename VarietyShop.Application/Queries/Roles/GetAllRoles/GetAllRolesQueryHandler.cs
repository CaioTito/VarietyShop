using MediatR;
using VarietyShop.Application.ViewModels;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Queries.Roles.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<RoleViewModel>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetAllRolesQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<RoleViewModel>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetAllAsync();

            return roles
                 .Select(p => new RoleViewModel(p.Id, p.Name, p.Slug, p.Active))
                 .ToList();
        }
    }
}
