using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.DTOs.ProductBatch
{
public class ProductBatchDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime ReceivedAt { get; set; }
    public DateTime ExpirationDate { get; set; }
}
}
