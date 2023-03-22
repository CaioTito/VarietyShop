using MediatR;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.Domain.Interfaces.Services;

namespace VarietyShop.Application.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;

    public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }

    public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.GeneratePasswordHash(request.Password);

        var user = await _userRepository.GetByPasswordAndEmailAsync(request.Email, passwordHash);

        if (user == null)
        {
            return null;
        }

        var token = _authService.GenerateJwtToken(user.Email, user.Roles);

        return new LoginUserViewModel(user.Email, token);
    }
}
