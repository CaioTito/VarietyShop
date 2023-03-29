using VarietyShop.Domain.Entities;

namespace VarietyShop.Domain.Interfaces.Repositories;

public interface IRoleRepository
{
    Task AddAsync(Role role);
    Task<Role> GetByIdAsync(int id);
    Task<List<Role>> GetAllAsync();

    Task SaveChangesAsync();
}
