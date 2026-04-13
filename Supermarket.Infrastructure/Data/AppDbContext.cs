using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.Entities;

namespace Supermarket.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ProductBatch> ProductBatches { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureProduct(modelBuilder);
        ConfigureCategory(modelBuilder);
        ConfigureTag(modelBuilder);
        ConfigureProductBatch(modelBuilder);
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

            // Category (1:N)
            entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // важливо
        });
    }

    private void ConfigureCategory(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict); // щоб не було каскадного хаосу
        });
    }

    private void ConfigureTag(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tag>(entity =>
        {
            entity.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        // Many-to-Many
        modelBuilder.Entity<Product>()
            .HasMany(p => p.Tags)
            .WithMany(t => t.Products)
            .UsingEntity(j => j.ToTable("ProductTags"));
    }

    private void ConfigureProductBatch(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductBatch>(entity =>
        {
            entity.Property(b => b.Quantity)
                .IsRequired();

            entity.Property(b => b.ReceivedAt)
                .IsRequired();

            entity.Property(b => b.ExpirationDate)
                .IsRequired();

            entity.HasOne(b => b.Product)
                .WithMany(p => p.Batches)
                .HasForeignKey(b => b.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}


