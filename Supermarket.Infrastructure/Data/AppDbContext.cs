using Microsoft.EntityFrameworkCore;
using Supermarket.Application.Common.Interfaces;
using Supermarket.Domain.Entities;

namespace Supermarket.Infrastructure.Data;

public class AppDbContext
    : DbContext, IAppDbContext
{
    public DbSet<Product> Products
        => Set<Product>();

    public DbSet<StockItem> StockItems =>
        Set<StockItem>();

    public DbSet<StockMovement> StockMovements =>
        Set<StockMovement>();


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


