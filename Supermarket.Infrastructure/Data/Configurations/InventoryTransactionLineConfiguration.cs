using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supermarket.Domain.InventoryTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Infrastructure.Data.Configurations;

public class InventoryTransactionLineConfiguration
    : IEntityTypeConfiguration<InventoryTransactionLine>
{
    public void Configure(
        EntityTypeBuilder<InventoryTransactionLine> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UnitPrice)
            .HasPrecision(18, 2);

        builder.Property(x => x.Quantity)
            .IsRequired();
    }
}