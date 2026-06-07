using MediatR;
using Supermarket.Application.Inventory.Commands.ReceiveStock;
using Supermarket.Application.Inventory.Commands.SellStock;
using Supermarket.Application.Inventory.Queries.GetCurrentStock;
using Supermarket.Api.Contracts.Inventory;

namespace Supermarket.Api.Endpoints;

public static class InventoryEndpoints
{
    public static void MapInventoryEndpoints(
        this WebApplication app)
    {
        var group =
            app.MapGroup("/api/inventory");

        group.MapPost("/receive", Receive);

        group.MapPost("/sell", Sell);

        group.MapGet(
            "/{productId:guid}",
            GetCurrentStock);
    }

    private static async Task<IResult> Receive(
        ReceiveStockRequest request,
        ISender sender,
        CancellationToken ct)
    {
        var command = new ReceiveStockCommand(
            request.ProductId,
            request.Quantity,
            request.UnitPrice,
            request.Comment);

        await sender.Send(command, ct);

        return Results.Ok();
    }

    private static async Task<IResult> Sell(
        SellStockRequest request,
        ISender sender,
        CancellationToken ct)
    {
        var command = new SellStockCommand(
            request.ProductId,
            request.Quantity,
            request.UnitPrice);

        await sender.Send(command, ct);

        return Results.Ok();
    }

    private static async Task<IResult>
        GetCurrentStock(
        Guid productId,
        ISender sender,
        CancellationToken ct)
    {
        var result = await sender.Send(
            new GetCurrentStockQuery(productId),
            ct);

        return Results.Ok(result);
    }
}