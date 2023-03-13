using VarietyShop.Domain.InputModels;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.Domain.ViewModels;

namespace VarietyShop.Infra.Repositories;

public class UserRepository : IUserRepository
{
    public Task<int> Create(CreateUserInputModel inputModel)
    {
        throw new NotImplementedException();
    }

    public Task<UserViewModel> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserViewModel>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(UpdateUserInputModel inputModel)
    {
        throw new NotImplementedException();
    }
}
