using System.Collections.Generic;
using System.Threading.Tasks;
using VarietyShop.Domain.Entities;

namespace VarietyShop.Domain.Interfaces.Repositories;

public interface IProductRepository
{
    Task<int> Count();
    Task<List<Product>> GetAllAsync(int page, int pageSize);
    Task<List<Product>> GetAllByCategoryAsync(int page, int pageSize, string category);
    Task<Product> GetByIdAsync(int id);
    Task<Product> GetBySlugAsync(string slug);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
}