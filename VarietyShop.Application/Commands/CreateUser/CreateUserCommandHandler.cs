using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.Domain.Interfaces.Services;

namespace VarietyShop.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.GeneratePasswordHash(request.PasswordHash);

            var user = new User(request.Name, request.Cpf, request.Email, passwordHash, request.Slug, request.Active);

            await _userRepository.AddAsync(user);

            return user.Id;
        }
    }
}
