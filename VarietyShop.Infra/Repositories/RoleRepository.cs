using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.Infra.Persistence.Data;

namespace VarietyShop.Infra.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly VarietyShopDataContext _dbContext;

    public RoleRepository(VarietyShopDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Role role)
    {
        await _dbContext.Roles.AddAsync(role);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Role>> GetAllAsync()
    {
        return await _dbContext.Roles.AsNoTracking().ToListAsync();
    }

    public async Task<Role> GetByIdAsync(int id)
    {
        var role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);

        if (role == null)
        {
            return null;
        }

        return role;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
