using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Application.ViewModels;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Queries.Products.GetAllProductsByCategory;

public class GetAllProductsByCategoryQueryHandler : IRequestHandler<GetAllProductsByCategoryQuery, List<ProductViewModel>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsByCategoryQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductViewModel>> Handle(GetAllProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllByCategoryAsync(request.Page, request.PageSize, request.CategorySlug);

        return products
            .Select(x => new ProductViewModel(
                x.Id,
                x.Name,
                x.Slug,
                x.Active,
                x.Category.Name,
                x.Quantity,
                x.Value,
                x.EntryDate))
            .ToList();
    }
}
