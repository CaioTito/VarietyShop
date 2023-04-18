using System;
using System.Collections.Generic;

namespace VarietyShop.Domain.Entities;

public class Product : BaseEntity
{
    public Product(int categoryId, int quantity, decimal value, DateTime entryDate, string name, string slug, bool active)
    {
        CategoryId = categoryId;
        Quantity = quantity;
        Value = value;
        EntryDate = entryDate;
        Name = name;
        Slug = slug;
        Active = active;
    }

    public int CategoryId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Value { get; private set; }
    public DateTime EntryDate { get; set; }
    public Category Category { get; private set; }
    public List<Activity> Activities { get; private set; }

    public void Update(int categoryId, string name, string slug)
    {
        CategoryId = categoryId;
        Name = name;
        Slug = slug;
    }
}
