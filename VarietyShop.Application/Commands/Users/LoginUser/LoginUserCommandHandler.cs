using MediatR;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.Domain.Interfaces.Services;

namespace VarietyShop.Application.Commands.Users.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;

    public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }

    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.GeneratePasswordHash(request.Password);

        var user = await _userRepository.GetByPasswordAndEmailAsync(request.Email, passwordHash);

        if (user == null)
        {
            return null;
        }

        return _authService.GenerateJwtToken(user.Email, user.Roles);
    }
}
