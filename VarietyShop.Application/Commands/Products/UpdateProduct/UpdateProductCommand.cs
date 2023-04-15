using MediatR;

namespace VarietyShop.Application.Commands.Products.UpdateProduct;

public class UpdateProductCommand : IRequest<Unit>
{
    public UpdateProductCommand(int id, int categoryId, string name, string slug)
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        Slug = slug;
    }

    public int Id { get; set; }
    public int CategoryId { get; set; }    
    public string Name { get; set; }
    public string Slug { get; set; }
}
