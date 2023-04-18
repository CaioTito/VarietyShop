using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VarietyShop.Application.Commands.Products.CreateProduct;
using VarietyShop.Application.Commands.Products.DeleteProduct;
using VarietyShop.Application.Commands.Products.UpdateProduct;
using VarietyShop.Application.Queries.Products.GetAllProducts;
using VarietyShop.Application.Queries.Products.GetAllProductsByCategory;
using VarietyShop.Application.Queries.Products.GetProductById;
using VarietyShop.Application.Queries.Products.GetProductBySlug;

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
    [Authorize]
    public async Task<IActionResult> GetAllProducts(
        [FromRoute] int page,
        [FromRoute] int pageSize)
    {
        var query = new GetAllProductsQuery(page, pageSize);

        var products = await _mediator.Send(query);

        return Ok(products);
    }

    [HttpGet("{page:int}/{pageSize:int}/{category}")]
    [Authorize]
    public async Task<IActionResult> GetAllProductsByCategory(
        [FromRoute] int page,
        [FromRoute] int pageSize,
        [FromRoute] string category)
    {
        var query = new GetAllProductsByCategoryQuery(page, pageSize, category);

        var products = await _mediator.Send(query);

        return Ok(products);
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<IActionResult> GetProductById(
        [FromRoute] int id)
    {
        var query = new GetProductByIdQuery(id);

        var product = await _mediator.Send(query);

        return Ok(product);
    }

    [HttpGet("{slug}")]
    [Authorize]
    public async Task<IActionResult> GetProductBySlug(
        [FromRoute] string slug)
    {
        var query = new GetProductBySlugQuery(slug);

        var product = await _mediator.Send(query);

        return Ok(product);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var id = await _mediator.Send(command);

        return Ok(new { productId = id });
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var command = new DeleteProductCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }
}
