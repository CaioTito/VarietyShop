using VarietyShop.Domain.InputModels;
using VarietyShop.Domain.ViewModels;

namespace VarietyShop.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<List<UserViewModel>> GetUsers();
    Task<UserViewModel> GetById(int id);
    Task<int> Create(CreateUserInputModel inputModel);
    Task<bool> Update(UpdateUserInputModel inputModel);
    Task<boo>l Delete(int id);
}
