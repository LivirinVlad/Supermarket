using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Product> Products { get; }
    DbSet<StockItem> StockItems { get; }

    DbSet<StockMovement> StockMovements { get; }


    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken);
}