using VarietyShop.Domain.Entities;

namespace VarietyShop.Domain.Models;

public class Transaction : BaseEntity
{
    public Transaction(int userId, int productId, DateTime creationDate)
    {
        UserId = userId;
        ProductId = productId;
        CreationDate = creationDate;
    }

    public int UserId { get; private set; }
    public int ProductId { get; private set; }
    public DateTime CreationDate { get; private set; }
}
