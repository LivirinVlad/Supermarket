using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.InventoryTransactions.Queries.GetInventoryTransactions;

public record InventoryTransactionDto(
    Guid TransactionId,
    string Type,
    DateTime CreatedAt,
    List<InventoryTransactionLineDto> Lines);
