using MediatR;

namespace VarietyShop.Application.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<Unit>
{
    public int Id { get; private set; }

    public DeleteUserCommand(int id)
    {
        Id = id;
    }
}
