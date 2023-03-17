using VarietyShop.Domain.Entities;

namespace VarietyShop.Domain.Models;

public class Role : BaseEntity
{
    public string Slug { get; set; }
    public bool Active { get; set; }
    public List<User> Users { get; private set; }
}
