using Supermarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Entities;

public class StockMovement
{
    public Guid Id { get; private set; }

    public Guid StockItemId { get; private set; }

    public int Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    public StockMovementType Type { get; private set; }

    public string? Comment { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private StockMovement() { }

    private StockMovement(
        Guid stockItemId,
        int quantity,
        decimal unitPrice,
        StockMovementType type,
        string? comment)
    {
        Id = Guid.NewGuid();

        StockItemId = stockItemId;

        Quantity = quantity;

        UnitPrice = unitPrice;

        Type = type;

        Comment = comment;

        CreatedAt = DateTime.UtcNow;
    }

    public static StockMovement Create(
        Guid stockItemId,
        int quantity,
        decimal unitPrice,
        StockMovementType type,
        string? comment = null)
    {
        return new StockMovement(
            stockItemId,
            quantity,
            unitPrice,
            type,
            comment);
    }
}
