using MediatR;

namespace VarietyShop.Application.Commands.CreateUser;

public class CreateUserCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
}
