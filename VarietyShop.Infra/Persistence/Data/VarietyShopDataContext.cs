using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VarietyShop.Domain.Models;

namespace VarietyShop.Infra.Persistence.Data;

public class VarietyShopDataContext : DbContext
{
	public VarietyShopDataContext(DbContextOptions<VarietyShopDataContext> options) : base(options)
	{

	}

    public DbSet<Category> Category { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Activity> Transaction { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
