using VarietyShop.Domain.Entities;

namespace VarietyShop.Domain.Models;

public class Product : BaseEntity
{
    public Product(string category, int quantity, decimal value)
    {
        Category = category;
        Quantity = quantity;
        Value = value;
    }

    public string Category { get; private set; }
    public int Quantity { get; private set; }
    public decimal Value { get; private set; }
}
