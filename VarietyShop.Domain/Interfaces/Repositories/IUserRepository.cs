﻿using System.Collections.Generic;
using System.Threading.Tasks;
using VarietyShop.Domain.Models;

namespace VarietyShop.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync();
        Task DeleteAsync();
        Task UpdateAsync();
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);

        Task<User> GetByPasswordAndEmailAsync(string email, string password);
    }
}
