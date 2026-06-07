using Supermarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Entities;

public class StockItem
{
    public Guid Id { get; private set; }

    public Guid ProductId { get; private set; }

    public int CurrentQuantity { get; private set; }

    private readonly List<StockMovement>
        _movements = [];

    public IReadOnlyCollection<StockMovement>
        Movements => _movements;

    private StockItem() { }

    public StockItem(Guid productId)
    {
        Id = Guid.NewGuid();

        ProductId = productId;

        CurrentQuantity = 0;
    }

    public void ApplyMovement(
        int quantity,
        decimal unitPrice,
        StockMovementType type,
        string? comment = null)
    {
        if (quantity == 0)
            throw new ArgumentException(
                "Quantity cannot be zero");

        var newQuantity =
            CurrentQuantity + quantity;

        if (newQuantity < 0)
            throw new InvalidOperationException(
                "Not enough stock");

        var movement = StockMovement.Create(
            Id,
            quantity,
            unitPrice,
            type,
            comment);

        _movements.Add(movement);

        CurrentQuantity = newQuantity;
    }
}
