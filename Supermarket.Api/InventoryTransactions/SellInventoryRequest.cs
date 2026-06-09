namespace Supermarket.Api.InventoryTransactions;

public record SellInventoryRequest(
    List<SellInventoryLineRequest> Lines);

public record SellInventoryLineRequest(
    Guid ProductId,
    int Quantity);