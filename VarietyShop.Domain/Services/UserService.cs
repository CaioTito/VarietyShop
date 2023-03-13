using VarietyShop.Domain.InputModels;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.Domain.Interfaces.Services;
using VarietyShop.Domain.ViewModels;

namespace VarietyShop.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> Create(CreateUserInputModel inputModel)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<UserViewModel> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<UserViewModel>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(UpdateUserInputModel inputModel)
    {
        throw new NotImplementedException();
    }
}
