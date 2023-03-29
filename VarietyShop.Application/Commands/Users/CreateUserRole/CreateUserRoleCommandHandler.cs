using MediatR;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Commands.Users.CreateUserRole
{
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserRoleCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // TO DO Ajustar criação de realcionamento.
        public async Task<Unit> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var userRole = new UserRole(request.UserId, request.RoleId);

            await _userRepository.AddUserRoleAsync(userRole);

            return Unit.Value;
        }
    }
}
