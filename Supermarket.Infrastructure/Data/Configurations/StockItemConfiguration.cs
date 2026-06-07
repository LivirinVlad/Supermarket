using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supermarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Infrastructure.Data.Configurations;

public class StockItemConfiguration
    : IEntityTypeConfiguration<StockItem>
{
    public void Configure(
        EntityTypeBuilder<StockItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CurrentQuantity)
            .IsRequired();

        builder.HasMany(x => x.Movements)
            .WithOne()
            .HasForeignKey(
                x => x.StockItemId);

        builder.Navigation(x => x.Movements)
            .UsePropertyAccessMode(
                PropertyAccessMode.Field);
    }
}
