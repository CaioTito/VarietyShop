using MediatR;
using VarietyShop.Application.ViewModels;

namespace VarietyShop.Application.Queries.Products.GetProductById;

public class GetProductByIdQuery : IRequest<ProductViewModel>
{
    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
