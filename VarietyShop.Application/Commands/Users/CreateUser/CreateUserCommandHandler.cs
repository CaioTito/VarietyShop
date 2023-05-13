using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Abstractions;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.Domain.Interfaces.Services;

namespace VarietyShop.Application.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.GeneratePasswordHash(request.PasswordHash);

            var roles = new List<Role>();

            foreach (var role in request.RolesId)
            {
                var actualRole = await _unitOfWork.Roles.GetByIdAsync(role);
                roles.Add(actualRole);
            }

            var user = new User(request.Name,
                                request.Cpf,
                                request.Email,
                                passwordHash,
                                request.Slug,
                                request.Active,
                                roles);

            await _unitOfWork.Users.AddAsync(user);

            return user.Id;
        }
    }
}
