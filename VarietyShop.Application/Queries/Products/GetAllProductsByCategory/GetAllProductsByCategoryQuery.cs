using MediatR;
using System.Collections.Generic;
using VarietyShop.Application.ViewModels;

namespace VarietyShop.Application.Queries.Products.GetAllProductsByCategory;

public class GetAllProductsByCategoryQuery : IRequest<List<ProductViewModel>>
{
    public GetAllProductsByCategoryQuery(int page, int pageSize, string categorySlug)
    {
        Page = page;
        PageSize = pageSize;
        CategorySlug = categorySlug;
    }

    public int Page { get; set; }
    public int PageSize { get; set; }
    public string CategorySlug { get; set; }
}
