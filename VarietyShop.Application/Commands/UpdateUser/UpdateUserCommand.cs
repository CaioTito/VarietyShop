using MediatR;

namespace VarietyShop.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public UpdateUserCommand(int id, string email, string role)
        {
            Id = id;
            Email = email;
            Role = role;
        }

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }
    }
}
