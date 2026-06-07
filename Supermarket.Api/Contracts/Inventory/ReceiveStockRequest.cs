namespace Supermarket.Api.Contracts.Inventory;
public record ReceiveStockRequest(
    Guid ProductId,
    int Quantity,
    decimal UnitPrice,
    string? Comment);
