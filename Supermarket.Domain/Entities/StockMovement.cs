using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Domain.Enums;

namespace Supermarket.Domain.Entities
{
    public class StockMovement
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public StockMovementType Type { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? Note { get; set; }
    }
}
