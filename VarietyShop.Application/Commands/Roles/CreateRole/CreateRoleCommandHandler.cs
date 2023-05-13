using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Abstractions;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Commands.Roles.CreateRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRoleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var slug = request.Name
            .ToLower()
            .Replace(" ", "-");

        var role = new Role(request.Name, slug, request.Active);

        await _unitOfWork.Roles.AddAsync(role);

        await _unitOfWork.SaveChangesAsync();

        return role.Id;
    }
}
