using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Application.ViewModels;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Queries.Products.GetProductBySlug;

public class GetProductBySlugQueryHandler : IRequestHandler<GetProductBySlugQuery, ProductViewModel>
{
    private readonly IProductRepository _productRepository;

    public GetProductBySlugQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductViewModel> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetBySlugAsync(request.ProductSlug);

        if (product == null)
            return default;

        return new ProductViewModel(
                            product.Id,
                            product.Name,
                            product.Slug,
                            product.Active,
                            product.Category.Name,
                            product.Quantity,
                            product.Value,
                            product.EntryDate);
    }
}
