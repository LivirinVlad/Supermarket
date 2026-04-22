using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.Entities;

namespace Supermarket.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<StockMovement> StockMovements { get; set; }



    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureProduct(modelBuilder);
        ConfigureStockMovement(modelBuilder);
    }

    private void ConfigureStockMovement(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StockMovement>(entity =>
        {
            entity.Property(x => x.Quantity)
                .IsRequired();

            entity.Property(x => x.CreatedAt)
                .IsRequired();

            entity.Property(x => x.Type)
                .IsRequired();

            entity.HasOne<Product>()
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private void ConfigureProduct(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            entity.Property(p => p.Description)
                .HasMaxLength(500);

            entity.Property(p => p.IsActive)
                .HasDefaultValue(true);

            // Index
            entity.HasIndex(p => p.Name);
            entity.HasIndex(p => p.IsActive);
        });
    }

}


