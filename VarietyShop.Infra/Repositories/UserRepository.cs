using Microsoft.EntityFrameworkCore;
using VarietyShop.Domain.Interfaces.Repositories;
using VarietyShop.Domain.Models;
using VarietyShop.Infra.Persistence.Data;

namespace VarietyShop.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly VarietyShopDataContext _dbContext;

        public UserRepository(VarietyShopDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByPasswordAndEmailAsync(string email, string password)
        {
            return await _dbContext.Users.Include(x => x.Roles).SingleOrDefaultAsync(u => u.Email == email && u.PasswordHash == password);
        }

        public async Task UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
