﻿using System.Threading.Tasks;
using VarietyShop.Domain.Entities;

namespace VarietyShop.Domain.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task<Category> GetById(int id);
}
