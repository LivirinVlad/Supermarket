using MediatR;
using Microsoft.EntityFrameworkCore;
using Supermarket.Application.Common.Interfaces;
using Supermarket.Domain.InventoryTransaction;
using Supermarket.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.InventoryTransactions.Commands.SellInventory;

public record SellInventoryCommand(
    List<SellInventoryLineDto> Lines)
    : IRequest<Guid>;

public class SellInventoryHandler
    : IRequestHandler<
        SellInventoryCommand,
        Guid>
{
    private readonly IAppDbContext _db;

    public SellInventoryHandler(
        IAppDbContext db)
    {
        _db = db;
    }

    public async Task<Guid> Handle(
        SellInventoryCommand request,
        CancellationToken ct)
    {
        var productIds =
            request.Lines
                .Select(x => x.ProductId)
                .Distinct()
                .ToList();

        var products =
            await _db.Products
                .Where(x =>
                    productIds.Contains(x.Id))
                .ToDictionaryAsync(
                    x => x.Id,
                    ct);

        var balances =
            await _db.StockBalances
                .Where(x =>
                    productIds.Contains(
                        x.ProductId))
                .ToDictionaryAsync(
                    x => x.ProductId,
                    ct);

        var transaction =
            new InventoryTransaction(
                InventoryTransactionType.Sale);

       

        foreach (var line in request.Lines)
        {
            if (!products.TryGetValue(
                line.ProductId,
                out var product))
            {
                throw new Exception(
                    $"Product {line.ProductId} not found");
            }

            if (!balances.TryGetValue(
                line.ProductId,
                out var balance))
            {
                throw new InvalidOperationException(
                    $"No stock for {product.Name}");
            }

            balance.Decrease(
                line.Quantity);

            transaction.AddLine(
                product.Id,
                line.Quantity,
                product.CurrentPrice);
        }

        _db.InventoryTransactions
            .Add(transaction);

        await _db.SaveChangesAsync(
            ct);

        return transaction.Id;
    }
}
