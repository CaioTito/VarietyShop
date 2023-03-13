using VarietyShop.Domain.InputModels;
using VarietyShop.Domain.ViewModels;

namespace VarietyShop.Domain.Interfaces.Services;

public interface IUserService
{
    Task<List<UserViewModel>> GetUsers();
    Task<UserViewModel> GetById(int id);
    Task<int> Create(CreateUserInputModel inputModel);
    Task<bool> Update(UpdateUserInputModel inputModel);
    Task<bool> Delete(int id);
}
