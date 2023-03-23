using System.Collections.Generic;
using System.Threading.Tasks;
using VarietyShop.Domain.Models;

namespace VarietyShop.Domain.Interfaces.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<Product> AddAsync(Product product);
    Task<bool> UpdateAsync(Product product, int id);
    Task<bool> DeleteAsync(int id);
}