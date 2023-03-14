using VarietyShop.Domain.Entities;

namespace VarietyShop.Domain.Models;

public class Role : BaseEntity
{
    public List<User> Users { get; private set; }
}
