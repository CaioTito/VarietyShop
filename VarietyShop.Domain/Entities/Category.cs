namespace VarietyShop.Domain.Entities;

public class Category : BaseEntity
{
    public IList<Product> Products { get; set; }
}
