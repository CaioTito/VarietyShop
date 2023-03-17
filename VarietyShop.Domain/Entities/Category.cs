using VarietyShop.Domain.Entities;

namespace VarietyShop.Domain.Models;

public class Category : BaseEntity
{
    public string Slug { get; set; }
    public bool Active { get; private set; }
    public IList<Product> Products { get; set; }
}
