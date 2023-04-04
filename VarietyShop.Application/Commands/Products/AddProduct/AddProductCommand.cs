using MediatR;
using System;

namespace VarietyShop.Application.Commands.Products.AddProduct;

public class AddProductCommand : IRequest<int>
{
    public int CategoryId { get; set; }
    public int Quantity { get; set; }
    public decimal Value { get; set; }
    public DateTime EntryDate { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public bool Active { get; set; }
}
