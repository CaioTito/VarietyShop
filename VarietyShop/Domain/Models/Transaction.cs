namespace VarietyShop.Domain.Models;

public class Transaction
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public DateTime CreationDate { get; set; }
    public string Description { get; set; }
}
