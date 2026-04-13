using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Entities
{
    public class ProductBatch
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }

        public DateTime ReceivedAt { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
