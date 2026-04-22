using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Inventory.DTOs
{
    public class AddStockDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
