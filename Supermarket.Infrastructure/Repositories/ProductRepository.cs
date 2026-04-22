using Microsoft.EntityFrameworkCore;
using Supermarket.Application.Products.DTOs;
using Supermarket.Application.Products.Interfaces;
using Supermarket.Application.Products.Queries;
using Supermarket.Domain.Entities;
using Supermarket.Infrastructure.Data;

namespace Supermarket.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ProductWithStockDto>> GetAllWithStockAsync()
    {
        return await _context.Products
            .Select(p => new ProductWithStockDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,

                Stock = _context.StockMovements
                    .Where(m => m.ProductId == p.Id)
                    .Sum(m => (int?)m.Quantity) ?? 0
            })
            .ToListAsync();
    }
}