using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Products.DTOs;

public class SellProductDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
