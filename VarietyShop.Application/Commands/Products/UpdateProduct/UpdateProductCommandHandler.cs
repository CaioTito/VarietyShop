using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Domain.Interfaces.Abstractions;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Commands.Products.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
            return default;

        product.Update(request.CategoryId, request.Name, request.Slug);

        _productRepository.Update(product);
        
        await _unitOfWork.Commit();

        return Unit.Value;
    }
}
