using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supermarket.Domain.StockBalance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Infrastructure.Data.Configurations;

public class StockBalanceConfiguration
    : IEntityTypeConfiguration<StockBalance>
{
    public void Configure(
        EntityTypeBuilder<StockBalance> builder)
    {
        builder.HasKey(x => x.ProductId);

        builder.Property(x => x.QuantityOnHand)
            .IsRequired();
    }
}