using Microsoft.EntityFrameworkCore;
using Supermarket.Application.Common.Interfaces;
using Supermarket.Domain.InventoryTransaction;
using Supermarket.Domain.Product;
using Supermarket.Domain.StockBalance;

namespace Supermarket.Infrastructure.Data;

public class AppDbContext
    : DbContext, IAppDbContext
{
    public DbSet<Product> Products
        => Set<Product>();

    public DbSet<InventoryTransaction>
        InventoryTransactions =>
            Set<InventoryTransaction>();

    public DbSet<InventoryTransactionLine>
        InventoryTransactionLines =>
            Set<InventoryTransactionLine>();

    public DbSet<StockBalance>
        StockBalances =>
            Set<StockBalance>();


    public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(
        ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly);
    }
}


