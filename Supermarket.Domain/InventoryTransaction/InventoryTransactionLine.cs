using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.InventoryTransaction;

public class InventoryTransactionLine
{
    public Guid Id { get; private set; }

    public Guid InventoryTransactionId { get; private set; }

    public Guid ProductId { get; private set; }

    public int Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    private InventoryTransactionLine() { }

    internal InventoryTransactionLine(
        Guid productId,
        int quantity,
        decimal unitPrice)
    {
        Id = Guid.NewGuid();

        ProductId = productId;

        Quantity = quantity;

        UnitPrice = unitPrice;
    }
}
