using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.InventoryTransactions.Queries.GetInventoryTransactions;
public record InventoryTransactionLineDto(
    Guid ProductId,
    string ProductName,
    int Quantity,
    decimal UnitPrice);
