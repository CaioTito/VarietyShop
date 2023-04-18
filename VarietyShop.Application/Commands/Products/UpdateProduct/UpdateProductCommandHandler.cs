using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Commands.Products.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
            return default;

        product.Update(request.CategoryId, request.Name, request.Slug);

        _productRepository.Update(product);

        await _productRepository.Commit();

        return Unit.Value;
    }
}
