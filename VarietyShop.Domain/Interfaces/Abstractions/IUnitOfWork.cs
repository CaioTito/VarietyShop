using System;
using System.Threading.Tasks;

namespace VarietyShop.Domain.Interfaces.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
        Task Rollback();
    }
}
