using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.Domain.Models;
using VarietyShop.Infra.Persistence.Data;

namespace VarietyShop.Infra.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly VarietyShopDataContext _dbContext;

    public ProductRepository(VarietyShopDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
    public Task<Product> AddAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Product product, int id)
    {
        throw new NotImplementedException();
    }
    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}