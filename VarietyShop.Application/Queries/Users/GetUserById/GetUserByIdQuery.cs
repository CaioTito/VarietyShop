using MediatR;
using VarietyShop.Application.ViewModels;

namespace VarietyShop.Application.Queries.Users.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public int Id { get; private set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
