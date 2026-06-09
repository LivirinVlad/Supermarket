using MediatR;
using Microsoft.EntityFrameworkCore;
using Supermarket.Application.Common.Exceptions;
using Supermarket.Application.Common.Interfaces;
using Supermarket.Domain.InventoryTransaction;
using Supermarket.Domain.Product;
using Supermarket.Domain.StockBalance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.InventoryTransactions.Commands.ReceiveInventory;

public record ReceiveInventoryCommand(
    List<ReceiveInventoryLineDto> Lines)
    : IRequest<Guid>;

public class ReceiveInventoryHandler
    : IRequestHandler<
        ReceiveInventoryCommand,
        Guid>
{
    private readonly IAppDbContext _db;

    public ReceiveInventoryHandler(
        IAppDbContext db)
    {
        _db = db;
    }

    public async Task<Guid> Handle(
        ReceiveInventoryCommand request,
        CancellationToken ct)
    {
        var transaction =
            new InventoryTransaction(
                InventoryTransactionType.Receive);

        foreach (var line in request.Lines)
        {
            var productExists =
                await _db.Products.AnyAsync(
                    x => x.Id == line.ProductId,
                    ct);

            if (!productExists)
                throw new Exception(
                    $"Product {line.ProductId} not found");

            transaction.AddLine(
                line.ProductId,
                line.Quantity,
                line.UnitPrice);

            var balance =
                await _db.StockBalances
                    .FindAsync(
                        [line.ProductId],
                        ct);

            if (balance is null)
            {
                balance =
                    new StockBalance(
                        line.ProductId);

                _db.StockBalances
                    .Add(balance);
            }

            balance.Increase(
                line.Quantity);
        }

        _db.InventoryTransactions
            .Add(transaction);

        await _db.SaveChangesAsync(ct);

        return transaction.Id;
    }
}