using MediatR;

namespace VarietyShop.Application.Commands.Users.CreateUserRole
{
    public class CreateUserRoleCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
