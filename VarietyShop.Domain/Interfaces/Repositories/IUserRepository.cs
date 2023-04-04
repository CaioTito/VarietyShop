using System.Collections.Generic;
using System.Threading.Tasks;
using VarietyShop.Domain.Entities;

namespace VarietyShop.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task SaveShangesAsync();
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> GetByPasswordAndEmailAsync(string email, string password);
    }
}
