using MediatR;
using Supermarket.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.Application.InventoryTransactions.Queries.GetInventoryTransactions;
public record GetInventoryTransactionsQuery
    : IRequest<List<InventoryTransactionDto>>;

public class GetInventoryTransactionsHandler
    : IRequestHandler<
        GetInventoryTransactionsQuery,
        List<InventoryTransactionDto>>
{
    private readonly IAppDbContext _db;

    public GetInventoryTransactionsHandler(
        IAppDbContext db)
    {
        _db = db;
    }

    public async Task<
        List<InventoryTransactionDto>>
        Handle(
            GetInventoryTransactionsQuery request,
            CancellationToken ct)
    {
        var products =
            await _db.Products
                .AsNoTracking()
                .ToDictionaryAsync(
                    x => x.Id,
                    ct);

        var transactions =
            await _db.InventoryTransactions
                .Include(x => x.Lines)
                .AsNoTracking()
                .OrderByDescending(
                    x => x.CreatedAt)
                .ToListAsync(ct);

        return transactions
            .Select(t =>
                new InventoryTransactionDto(
                    t.Id,
                    t.Type.ToString(),
                    t.CreatedAt,
                    t.Lines
                        .Select(l =>
                            new InventoryTransactionLineDto(
                                l.ProductId,
                                products[l.ProductId].Name,
                                l.Quantity,
                                l.UnitPrice))
                        .ToList()))
            .ToList();
    }
}