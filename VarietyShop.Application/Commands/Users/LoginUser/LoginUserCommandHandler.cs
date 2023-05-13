using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Domain.Interfaces.Abstractions;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.Domain.Interfaces.Services;

namespace VarietyShop.Application.Commands.Users.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IAuthService _authService;
    private readonly IUnitOfWork _unitOfWork;

    public LoginUserCommandHandler(IAuthService authService, IUnitOfWork unitOfWork)
    {
        _authService = authService;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.GeneratePasswordHash(request.Password);

        var user = await _unitOfWork.Users.GetByPasswordAndEmailAsync(request.Email, passwordHash);

        if (user == null)
        {
            return null;
        }

        return _authService.GenerateJwtToken(user.Email, user.Roles);
    }
}
