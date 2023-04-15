using System.Threading.Tasks;

namespace VarietyShop.Domain.Interfaces.Abstractions
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        Task Rollback();
    }
}
