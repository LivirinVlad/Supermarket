using Supermarket.Application.DTOs.ProductBatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Interfaces
{
    public interface IProductBatchService
    {
        Task<ProductBatchDto> CreateAsync(CreateProductBatchDto dto);
    }
}
