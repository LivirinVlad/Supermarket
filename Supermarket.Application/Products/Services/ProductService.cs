using Supermarket.Application.Inventory.Interfaces;
using Supermarket.Application.Products.DTOs;
using Supermarket.Application.Products.Interfaces;
using Supermarket.Application.Products.Queries;
using Supermarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Products.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;
    private readonly IInventoryService _inventoryService;

    public ProductService(IProductRepository repo, IInventoryService inventoryService)
    {
        _repo = repo;
        _inventoryService = inventoryService;
    }

    public async Task<Guid> CreateAsync(CreateProductDto dto)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            IsActive = true
        };

        await _repo.AddAsync(product);
        return product.Id;
    }

    public async Task UpdateAsync(Guid id, UpdateProductDto dto)
    {
        var product = await _repo.GetByIdAsync(id);
        if (product == null) return;

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;

        await _repo.UpdateAsync(product);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repo.DeleteAsync(id);
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task<List<ProductWithStockDto>> GetAllWithStockAsync()
    {
        return await _repo.GetAllWithStockAsync();
    }


    public async Task SellAsync(SellProductDto dto)
    {
        var product = await _repo.GetByIdAsync(dto.ProductId);

        if (product == null)
            throw new Exception("Product not found");

        await _inventoryService.SellAsync(dto.ProductId, dto.Quantity);
    }

}


