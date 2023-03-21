using VarietyShop.Domain.Entities;

namespace VarietyShop.Domain.Models;

public class Product : BaseEntity
{
    public Product(string categoryId, int quantity, decimal value, DateTime entryDate)
    {
        CategoryId = categoryId;
        Quantity = quantity;
        Value = value;
        EntryDate = entryDate;
    }

    public string CategoryId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Value { get; private set; }
    public DateTime EntryDate { get; set; }
    public Category Category { get; private set; }
    public List<Activity> Activities { get; private set; }
}
