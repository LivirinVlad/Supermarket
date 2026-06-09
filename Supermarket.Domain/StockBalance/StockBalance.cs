using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.StockBalance;

public class StockBalance
{
    public Guid ProductId { get; private set; }

    public int QuantityOnHand { get; private set; }

    private StockBalance() { }

    public StockBalance(Guid productId)
    {
        ProductId = productId;
        QuantityOnHand = 0;
    }

    public void Increase(int quantity)
    {
        QuantityOnHand += quantity;
    }

    public void Decrease(int quantity)
    {
        if (QuantityOnHand < quantity)
            throw new InvalidOperationException(
                "Not enough stock");

        QuantityOnHand -= quantity;
    }
}
