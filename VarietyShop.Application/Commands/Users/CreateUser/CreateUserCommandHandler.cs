using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.Domain.Interfaces.Services;

namespace VarietyShop.Application.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.GeneratePasswordHash(request.PasswordHash);

            var roles = new List<Role>();

            foreach (var role in request.RolesId)
            {
                var actualRole = await _roleRepository.GetByIdAsync(role);
                roles.Add(actualRole);
            }

            var user = new User(request.Name,
                                request.Cpf,
                                request.Email,
                                passwordHash,
                                request.Slug,
                                request.Active,
                                roles);

            await _userRepository.AddAsync(user);

            return user.Id;
        }
    }
}
