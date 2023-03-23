using Microsoft.EntityFrameworkCore;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Repositories;
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

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveShangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users
                .Include(x => x.Roles)
                .ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _dbContext.Users
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<User> GetByPasswordAndEmailAsync(string email, string password)
        {
            return await _dbContext.Users
                .Include(x => x.Roles)
                .SingleOrDefaultAsync(u => u.Email == email && u.PasswordHash == password);
        }

        public async Task AddUserRoleAsync(UserRole userRole)
        {
            await _dbContext.UserRoles.AddAsync(userRole);
            await _dbContext.SaveChangesAsync();
        }
    }
}
