using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Enums
{
    public enum StockMovementType
    {
        Purchase = 1,
        Sale = 2,
        Return = 3,
        Adjustment = 4,
        Expired = 5,
        Transfer = 6
    }
}
