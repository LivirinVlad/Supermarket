using MediatR;
using Supermarket.Application.Products.Commands.CreateProduct;
using Supermarket.Application.Products.Commands.DeleteProduct;
using Supermarket.Application.Products.Commands.UpdateProduct;
using Supermarket.Application.Products.Queries.GetAllProducts;
using Supermarket.Api.Contracts.Products;


namespace Supermarket.Api.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(
        this WebApplication app)
    {
        var group = app.MapGroup("/api/products");

        group.MapPost("/", Create);

        group.MapGet("/", GetAll);

        group.MapPut("/{id}", Update);

        group.MapDelete("/{id}", Delete);
    }

    private static async Task<IResult> Create(
    CreateProductRequest request,
    ISender sender,
    CancellationToken ct)
    {
        var command = new CreateProductCommand(
            request.Name,
            request.Price,
            request.Description);

        var id = await sender.Send(command, ct);

        return Results.Ok(id);
    }

    private static async Task<IResult> GetAll(
        ISender sender,
        CancellationToken ct)
    {
        var products = await sender.Send(
            new GetAllProductsQuery(),
            ct);

        return Results.Ok(products);
    }

    private static async Task<IResult> Update(
    Guid id,
    UpdateProductRequest request,
    ISender sender,
    CancellationToken ct)
    {
        var command = new UpdateProductCommand(
            id,
            request.Name,
            request.Price,
            request.Description);

        await sender.Send(command, ct);

        return Results.NoContent();
    }

    private static async Task<IResult> Delete(
    Guid id,
    ISender sender,
    CancellationToken ct)
    {
        await sender.Send(
            new DeleteProductCommand(id),
            ct);

        return Results.NoContent();
    }


}