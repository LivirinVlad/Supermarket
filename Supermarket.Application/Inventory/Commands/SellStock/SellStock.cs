using MediatR;
using Supermarket.Application.Common.Interfaces;
using Supermarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.Application.Inventory.Commands.SellStock;

public record SellStockCommand(
    Guid ProductId,
    int Quantity,
    decimal UnitPrice)
    : IRequest;

public class SellStockCommandHandler
    : IRequestHandler<SellStockCommand>
{
    private readonly IAppDbContext _db;

    public SellStockCommandHandler(
        IAppDbContext db)
    {
        _db = db;
    }

    public async Task Handle(
        SellStockCommand request,
        CancellationToken cancellationToken)
    {
        var stockItem = await _db.StockItems
            .Include(x => x.Movements)
            .FirstOrDefaultAsync(
                x => x.ProductId == request.ProductId,
                cancellationToken);

        if (stockItem is null)
            throw new Exception(
                "Stock item not found");

        stockItem.ApplyMovement(
            -request.Quantity,
            request.UnitPrice,
            StockMovementType.Sale);

        await _db.SaveChangesAsync(
            cancellationToken);
    }
}
