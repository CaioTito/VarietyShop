using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Commands.Products.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
            return default;

        product.Deactivate();

        _productRepository.Update(product);

        await _productRepository.Commit();

        return Unit.Value;
    }
}
