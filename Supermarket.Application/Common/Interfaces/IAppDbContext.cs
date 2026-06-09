using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.InventoryTransaction;
using Supermarket.Domain.Product;
using Supermarket.Domain.StockBalance;

namespace Supermarket.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Product> Products { get; }
    DbSet<InventoryTransaction> InventoryTransactions { get; }

    DbSet<InventoryTransactionLine> InventoryTransactionLines { get; }

    DbSet<StockBalance> StockBalances { get; }


    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken);
}