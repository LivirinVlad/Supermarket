namespace Supermarket.Api.InventoryTransactions;
public record ReceiveInventoryRequest(
    List<ReceiveInventoryLineRequest> Lines);

public record ReceiveInventoryLineRequest(
    Guid ProductId,
    int Quantity,
    decimal UnitPrice);