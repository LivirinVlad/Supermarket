using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Inventory.Interfaces;

public interface IInventoryService
{
    Task<int> GetStockAsync(Guid productId);

    Task AddStockAsync(Guid productId, int quantity);

    Task SellAsync(Guid productId, int quantity);
}