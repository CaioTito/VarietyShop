namespace VarietyShop.Domain.Entities;

public class Activity : BaseEntity
{
    public Activity(int clientId, int productId, int quantity, decimal value, DateTime createDate, DateTime lastUpdateDate)
    {
        ClientId = clientId;
        ProductId = productId;
        Quantity = quantity;
        Value = value;
        CreateDate = createDate;
        LastUpdateDate = lastUpdateDate;
    }

    public int ClientId { get; private set; }
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Value { get; private set; }
    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public User Client { get; private set; }
    public List<Product> Products { get; private set; }
}
