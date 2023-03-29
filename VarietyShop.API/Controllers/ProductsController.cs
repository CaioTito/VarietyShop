using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VarietyShop.Application.Commands.Products.AddProduct;
using VarietyShop.Application.Queries.Products.GetAllProducts;
using VarietyShop.Application.Queries.Products.GetProductById;

namespace VarietyShop.API.Controllers;

[ApiController]
[Route("v1/products")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{page:int}/{pageSize:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllProducts(
        [FromRoute] int page,
        [FromRoute] int pageSize)
    {
        var query = new GetAllProductsQuery(page, pageSize);

        var products = await _mediator.Send(query);

        return Ok(products);
    }

    [HttpGet("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetProductById(
        [FromRoute] int id)
    {
        var query = new GetProductByIdQuery(id);

        var product = await _mediator.Send(query);

        return Ok(product);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] AddProductCommand command)
    {
        var id = await _mediator.Send(command);

        return Ok(new { productId = id });
    }
}
