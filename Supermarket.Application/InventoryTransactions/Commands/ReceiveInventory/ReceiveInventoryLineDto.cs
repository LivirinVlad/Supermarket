using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.InventoryTransactions.Commands.ReceiveInventory;
public record ReceiveInventoryLineDto(
    Guid ProductId,
    int Quantity,
    decimal UnitPrice);
