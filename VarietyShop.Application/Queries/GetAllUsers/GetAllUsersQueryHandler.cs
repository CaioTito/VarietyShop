using MediatR;
using VarietyShop.Application.ViewModels;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAllAsync();

            return user
                .Select(p => new UserViewModel(p.Name, p.Cpf, p.Email, p.Roles))
                .ToList();
        }
    }
}
