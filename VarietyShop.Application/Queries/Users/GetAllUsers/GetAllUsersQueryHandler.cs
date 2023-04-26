using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Application.ViewModels;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Queries.Users.GetAllUsers
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

            var userViewModel =  user
                .Select(u => new UserViewModel(u.Name, 
                    u.Cpf, 
                    u.Email, 
                    u.Roles.Select(r => new RoleViewModel(r.Id,
                    r.Name, 
                    r.Slug, 
                    r.Active)).ToList()))
                .ToList();

            return userViewModel;
        }
    }
}
