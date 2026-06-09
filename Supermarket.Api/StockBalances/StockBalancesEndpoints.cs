using MediatR;
using Supermarket.Application.StockBalances.Queries.GetStockBalancesQuery;


namespace Supermarket.Api.InventoryTransactions;

public static class StockBalancesEndpoints
{
    public static void MapStockBalancesEndpoints(
        this WebApplication app)
    {
        app.MapGet(
            "/stock",
            GetStockBalances);
    }

    private static async Task<IResult>
    GetStockBalances(
        ISender sender,
        CancellationToken ct)
    {
        var result =
            await sender.Send(
                new GetStockBalancesQuery(),
                ct);

        return Results.Ok(result);
    }
}