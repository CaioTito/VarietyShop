using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Application.ViewModels;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Queries.Users.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            return new UserViewModel(user.Name, user.Cpf, user.Email, user.Roles.Select(r=> new RoleViewModel(r.Id, r.Name, r.Slug, r.Active)).ToList());
        }
    }
}
