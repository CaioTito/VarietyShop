using MediatR;
using VarietyShop.Application.ViewModels;

namespace VarietyShop.Application.Queries.Products.GetProductBySlug;

public class GetProductBySlugQuery : IRequest<ProductViewModel>
{
    public string ProductSlug { get; set; }

    public GetProductBySlugQuery(string productSlug)
    {
        ProductSlug = productSlug;
    }
}
