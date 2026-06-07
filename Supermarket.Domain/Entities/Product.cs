using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = null!;

    public decimal CurrentPrice { get; private set; }

    public string? Description { get; private set; }

    public bool IsActive { get; private set; }

    private Product() { }

    public Product(
        string name,
        decimal currentPrice,
        string? description = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name required");

        if (currentPrice <= 0)
            throw new ArgumentException("Price invalid");

        Id = Guid.NewGuid();

        Name = name;

        CurrentPrice = currentPrice;

        Description = description;

        IsActive = true;
    }

    public void ChangePrice(decimal newPrice)
    {
        if (newPrice <= 0)
            throw new ArgumentException("Price invalid");

        CurrentPrice = newPrice;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Update(
        string name,
        decimal currentPrice,
        string? description = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name required");
        if (currentPrice <= 0)
            throw new ArgumentException("Price invalid");
        Name = name;
        CurrentPrice = currentPrice;
        Description = description;
    }

}