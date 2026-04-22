using Supermarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Inventory.Interfaces;

public interface IInventoryRepository
{
    Task<int> GetStockAsync(Guid productId);
    Task AddMovementAsync(StockMovement movement);
}
