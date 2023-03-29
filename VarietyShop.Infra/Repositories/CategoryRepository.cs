using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.Infra.Persistence.Data;

namespace VarietyShop.Infra.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly VarietyShopDataContext _dbContext;

    public CategoryRepository(VarietyShopDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Category> GetById(int id) =>    
        await _dbContext
                .Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
    
}
