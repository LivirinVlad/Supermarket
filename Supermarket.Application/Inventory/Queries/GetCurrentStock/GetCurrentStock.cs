using MediatR;
using Supermarket.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.Application.Inventory.Queries.GetCurrentStock;


public record GetCurrentStockQuery(
    Guid ProductId)
    : IRequest<StockItemDto?>;

public class GetCurrentStockQueryHandler
    : IRequestHandler<
        GetCurrentStockQuery,
        StockItemDto?>
{
    private readonly IAppDbContext _db;

    public GetCurrentStockQueryHandler(
        IAppDbContext db)
    {
        _db = db;
    }

    public async Task<StockItemDto?> Handle(
        GetCurrentStockQuery request,
        CancellationToken cancellationToken)
    {
        return await _db.StockItems
            .AsNoTracking()
            .Where(x =>
                x.ProductId == request.ProductId)
            .Select(x => new StockItemDto
            {
                ProductId = x.ProductId,
                CurrentQuantity =
                    x.CurrentQuantity
            })
            .FirstOrDefaultAsync(
                cancellationToken);
    }
}
