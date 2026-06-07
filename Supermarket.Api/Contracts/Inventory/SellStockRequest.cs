namespace Supermarket.Api.Contracts.Inventory;
public record SellStockRequest(
    Guid ProductId,
    int Quantity,
    decimal UnitPrice);
