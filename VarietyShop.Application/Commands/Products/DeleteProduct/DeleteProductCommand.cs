using MediatR;

namespace VarietyShop.Application.Commands.Products.DeleteProduct;

public class DeleteProductCommand : IRequest<Unit>
{
    public DeleteProductCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
