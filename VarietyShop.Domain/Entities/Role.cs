namespace VarietyShop.Domain.Entities;

public class Role : BaseEntity
{
    public List<User> Users { get; private set; }
}
