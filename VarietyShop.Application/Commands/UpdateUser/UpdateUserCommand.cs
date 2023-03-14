using MediatR;

namespace VarietyShop.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public string Email { get; private set; }
        public string Role { get; private set; }
    }
}
