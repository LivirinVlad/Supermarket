using Microsoft.EntityFrameworkCore;
using Supermarket.Application.Inventory.Interfaces;
using Supermarket.Domain.Entities;
using Supermarket.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Infrastructure.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly AppDbContext _context;

    public InventoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddMovementAsync(StockMovement movement)
    {
        _context.StockMovements.Add(movement);
        await _context.SaveChangesAsync();
    }

    public async Task<int> GetStockAsync(Guid productId)
    {
        return await _context.StockMovements
            .Where(x => x.ProductId == productId)
            .SumAsync(x => (int?)x.Quantity) ?? 0;
    }
}

