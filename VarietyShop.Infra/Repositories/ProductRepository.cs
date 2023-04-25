using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.Infra.Persistence.Data;

namespace VarietyShop.Infra.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly VarietyShopDataContext _dbContext;

    public ProductRepository(VarietyShopDataContext dbContext) => _dbContext = dbContext;

    public async Task<int> Count() => await _dbContext.Products.AsNoTracking().CountAsync();

    public async Task<List<Product>> GetAllAsync(int page, int pageSize) =>
        await _dbContext
                .Products
                .AsNoTracking()
                .Include(x => x.Category)
                .Skip(page * pageSize)
                .Take(pageSize)
                .OrderBy(x => x.Name)
                .ToListAsync();

    public async Task<List<Product>> GetAllByCategoryAsync(int page, int pageSize, string category) =>
        await _dbContext
                .Products
                .AsNoTracking()
                .Include(x => x.Category)
                .Where(x => x.Category.Slug == category)
                .Skip(page * pageSize)
                .Take(pageSize)
                .OrderBy(x => x.Name)
                .ToListAsync();

    public async Task<Product> GetByIdAsync(int id) =>
        await _dbContext
                .Products
                .AsNoTracking()
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Product> GetBySlugAsync(string slug) =>
        await _dbContext
                .Products
                .AsNoTracking()
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Slug == slug);

    public async Task AddAsync(Product product) => await _dbContext.Products.AddAsync(product);

    public void Update(Product product) => _dbContext.Products.Update(product);

    public void Dispose() => _dbContext.Dispose();

}