using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VarietyShop.Domain.Entities;
using VarietyShop.Domain.Interfaces.Repositories;

namespace VarietyShop.Application.Commands.Products.AddProduct;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
{
    private readonly IProductRepository _productRepository;

    public AddProductCommandHandler(IProductRepository productRepository) => _productRepository = productRepository;

    public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.CategoryId, request.Quantity, request.Value, request.EntryDate, request.Name, request.Slug, request.Active);

        await _productRepository.AddAsync(product);

        return product.Id;
    }
}
