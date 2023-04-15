using System.Collections.Generic;
using System.Threading.Tasks;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Abstractions;

namespace VarietyShop.Domain.Interfaces.Repositories;

public interface IProductRepository : IUnitOfWork
{
    Task<int> Count();
    Task<List<Product>> GetAllAsync(int page, int pageSize);
    Task<List<Product>> GetAllByCategoryAsync(int page, int pageSize, string category);
    Task<Product> GetByIdAsync(int id);
    Task<Product> GetBySlugAsync(string slug);
    Task AddAsync(Product product);
    void Update(Product product);
}