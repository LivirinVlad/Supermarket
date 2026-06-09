using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.InventoryTransactions.Commands.SellInventory;

public record SellInventoryLineDto(
    Guid ProductId,
    int Quantity);