namespace VarietyShop.Domain.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
    }
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Slug { get; set; }
    public bool Active { get; private set; }
}
