using System;
using VarietyShop.Domain.Entities;

namespace VarietyShop.Application.ViewModels;

public class ProductViewModel
{
    public ProductViewModel(int id, string name, string slug, bool active, string category, int quantity, decimal value, DateTime entryDate)
    {
        Id = id;
        Name = name;
        Slug = slug;
        Active = active;
        Category = category;
        Quantity = quantity;
        Value = value;
        EntryDate = entryDate;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public bool Active { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public decimal Value { get; set; }
    public DateTime EntryDate { get; set; }

}
