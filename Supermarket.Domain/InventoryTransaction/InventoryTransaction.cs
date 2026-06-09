using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.InventoryTransaction;

public class InventoryTransaction
{
    public Guid Id { get; private set; }

    public InventoryTransactionType Type { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private readonly List<InventoryTransactionLine> _lines = [];

    public IReadOnlyCollection<InventoryTransactionLine>
        Lines => _lines;

    private InventoryTransaction() { }

    public InventoryTransaction(
        InventoryTransactionType type)
    {
        Id = Guid.NewGuid();
        Type = type;
        CreatedAt = DateTime.UtcNow;
    }

    public void AddLine(
        Guid productId,
        int quantity,
        decimal unitPrice)
    {
        if (quantity <= 0)
            throw new ArgumentException(
                "Quantity must be greater than zero");

        _lines.Add(
            new InventoryTransactionLine(
                productId,
                quantity,
                unitPrice));
    }
}
