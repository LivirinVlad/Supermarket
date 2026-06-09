using MediatR;
using Supermarket.Application.InventoryTransactions.Commands.ReceiveInventory;
using Supermarket.Application.InventoryTransactions.Commands.SellInventory;
using Supermarket.Application.InventoryTransactions.Queries.GetInventoryTransactions;

namespace Supermarket.Api.InventoryTransactions;

public static class InventoryTransactionsEndpoints
{
    public static void MapInventoryTransactionsEndpoints(
        this WebApplication app)
    {
        var group = app.MapGroup("/api/transactions");

        group.MapPost(
            "/receive",
            Receive);

        group.MapPost(
            "/sell",
            Sell);

        group.MapGet(
            "/",
            GetTransactions);
    }
    private static async Task<IResult> Receive(
        ReceiveInventoryRequest request,
        ISender sender,
        CancellationToken ct)
    {
        var command =
            new ReceiveInventoryCommand(
                request.Lines
                    .Select(x =>
                        new ReceiveInventoryLineDto(
                            x.ProductId,
                            x.Quantity,
                            x.UnitPrice))
                    .ToList());

        var id =
            await sender.Send(
                command,
                ct);

        return Results.Ok(id);
    }

    private static async Task<IResult> Sell(
    SellInventoryRequest request,
    ISender sender,
    CancellationToken ct)
    {
        var command =
            new SellInventoryCommand(
                request.Lines
                    .Select(x =>
                        new SellInventoryLineDto(
                            x.ProductId,
                            x.Quantity))
                    .ToList());

        var id =
            await sender.Send(
                command,
                ct);

        return Results.Ok(id);
    }

    private static async Task<IResult>
    GetTransactions(
        ISender sender,
        CancellationToken ct)
    {
        var result =
            await sender.Send(
                new GetInventoryTransactionsQuery(),
                ct);

        return Results.Ok(result);
    }

}