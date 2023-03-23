namespace VarietyShop.Domain.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
    }
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public bool Active { get; set; }

    public void Activate()
    {
        if (Active == false)
        {
            Active = true;
        }
    }

    public void Deactivate()
    {
        if (Active == true)
        {
            Active = false;
        }
    }
}
