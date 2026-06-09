using MediatR;
using Supermarket.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.Application.StockBalances.Queries.GetStockBalancesQuery;

public record GetStockBalancesQuery
    : IRequest<List<StockBalanceDto>>;

public class GetStockBalancesHandler
    : IRequestHandler<
        GetStockBalancesQuery,
        List<StockBalanceDto>>
{
    private readonly IAppDbContext _db;

    public GetStockBalancesHandler(
        IAppDbContext db)
    {
        _db = db;
    }

    public async Task<List<StockBalanceDto>>
        Handle(
            GetStockBalancesQuery request,
            CancellationToken ct)
    {
        return await
            (
                from balance in _db.StockBalances
                join product in _db.Products
                    on balance.ProductId equals product.Id
                select new StockBalanceDto(
                    product.Id,
                    product.Name,
                    product.CurrentPrice,
                    balance.QuantityOnHand
                )
            )
            .AsNoTracking()
            .ToListAsync(ct);
    }
}