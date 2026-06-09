using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.StockBalances.Queries.GetStockBalancesQuery;

public record StockBalanceDto(
    Guid ProductId,
    string ProductName,
    decimal CurrentPrice,
    int QuantityOnHand);