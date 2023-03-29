namespace VarietyShop.Application.ViewModels;

public class CategoryViewModel
{
    public CategoryViewModel(int id, string name, string slug, bool active)
    {
        Id = id;
        Name = name;
        Slug = slug;
        Active = active;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public bool Active { get; set; }
}
