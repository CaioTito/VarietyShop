using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Domain.Interfaces.Abstractions;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Commands.Products.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
            return default;

        product.Deactivate();

        _productRepository.Update(product);

        await _unitOfWork.Commit();

        return Unit.Value;
    }
}
