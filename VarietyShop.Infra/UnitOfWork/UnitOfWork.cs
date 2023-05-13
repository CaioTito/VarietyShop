using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using VarietyShop.Domain.Interfaces.Abstractions;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.Infra.Persistence.Data;

namespace VarietyShop.Infra.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private IDbContextTransaction _transaction;
    public ICategoryRepository Categories { get; }
    public IProductRepository Products { get; }
    public IRoleRepository Roles { get; }
    public IUserRepository Users { get; }
    private readonly VarietyShopDataContext _context;
    public UnitOfWork(VarietyShopDataContext context, ICategoryRepository categories, IProductRepository products, IRoleRepository roles, IUserRepository users)
    {
        _context = context;
        Categories = categories;
        Products = products;
        Roles = roles;
        Users = users;
    }
    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        try
        {
            await _transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await _transaction.RollbackAsync();
            throw ex;
        }
    }
}
