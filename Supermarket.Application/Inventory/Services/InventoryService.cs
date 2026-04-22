using Supermarket.Application.Inventory.Interfaces;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Inventory.Services;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _repo;

    public InventoryService(IInventoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<int> GetStockAsync(Guid productId)
    {
        return await _repo.GetStockAsync(productId);
    }

    public async Task AddStockAsync(Guid productId, int quantity)
    {
        await _repo.AddMovementAsync(new StockMovement
        {
            ProductId = productId,
            Quantity = quantity,
            Type = StockMovementType.Purchase,
            CreatedAt = DateTime.UtcNow
        });
    }

    public async Task SellAsync(Guid productId, int quantity)
    {
        var stock = await _repo.GetStockAsync(productId);

        if (stock < quantity)
            throw new Exception("Not enough stock");

        await _repo.AddMovementAsync(new StockMovement
        {
            ProductId = productId,
            Quantity = -quantity,
            Type = StockMovementType.Sale,
            CreatedAt = DateTime.UtcNow
        });
    }
}
