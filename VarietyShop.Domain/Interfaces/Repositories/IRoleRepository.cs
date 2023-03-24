using System.Threading.Tasks;
using VarietyShop.Domain.Entities;

namespace VarietyShop.Domain.Interfaces.Repositories;

public interface IRoleRepository
{
    Task AddAsync(Role role);
}
