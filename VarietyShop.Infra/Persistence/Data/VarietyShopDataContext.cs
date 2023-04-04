using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VarietyShop.Domain.Entities;

namespace VarietyShop.Infra.Persistence.Data;

public class VarietyShopDataContext : DbContext
{
    public VarietyShopDataContext(DbContextOptions<VarietyShopDataContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Activity> Transactions { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
