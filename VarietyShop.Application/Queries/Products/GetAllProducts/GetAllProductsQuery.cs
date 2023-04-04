using MediatR;
using System.Collections.Generic;
using VarietyShop.Application.ViewModels;

namespace VarietyShop.Application.Queries.Products.GetAllProducts;

public class GetAllProductsQuery : IRequest<List<ProductViewModel>>
{
    public GetAllProductsQuery(int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
    }

    public int Page { get; set; }
    public int PageSize { get; set; }
}
