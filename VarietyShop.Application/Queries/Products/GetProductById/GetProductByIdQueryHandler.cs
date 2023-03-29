using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Application.ViewModels;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Queries.Products.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductViewModel>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

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
