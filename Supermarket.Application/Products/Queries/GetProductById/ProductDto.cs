using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Products.Queries.GetProductById;
public record ProductDto(
    Guid Id,
    string Name,
    decimal Price);

