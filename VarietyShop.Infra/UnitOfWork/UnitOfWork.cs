using System.Threading.Tasks;
using VarietyShop.Domain.Interfaces.Abstractions;
using VarietyShop.Infra.Persistence.Data;

namespace VarietyShop.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VarietyShopDataContext _dbContext;

        public UnitOfWork(VarietyShopDataContext dbContext) => 
            _dbContext = dbContext;       

        public async Task<bool> Commit()
        {
            var sucess = (await _dbContext.SaveChangesAsync()) > 0;

            return sucess;
        }

        public void Dispose() => _dbContext.Dispose();

        public Task Rollback() => Task.CompletedTask;
    }
}
