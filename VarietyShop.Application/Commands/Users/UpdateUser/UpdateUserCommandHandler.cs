using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Commands.Users.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        user.Update(user.Email, user.Roles);

        await _userRepository.SaveShangesAsync();

        return Unit.Value;
    }
}
