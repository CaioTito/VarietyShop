namespace VarietyShop.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Quantity { get; set; }
    public decimal Value { get; set; }
}
