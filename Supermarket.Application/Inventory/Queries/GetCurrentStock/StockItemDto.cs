using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Inventory.Queries.GetCurrentStock;


public record StockItemDto
{
    public Guid ProductId { get; set; }

    public int CurrentQuantity { get; set; }
}
