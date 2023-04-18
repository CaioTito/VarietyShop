using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Commands.Users.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            user.Deactivate();

            await _userRepository.SaveShangesAsync();

            return Unit.Value;
        }
    }
}
