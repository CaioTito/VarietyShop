using VarietyShop.Domain.Entities;

namespace VarietyShop.Domain.Models;

public class Category : BaseEntity
{    
    public IList<Product> Products { get; set; }
}
