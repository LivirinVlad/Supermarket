using Supermarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Interfaces
{
    public interface IProductBatchRepository
    {
        Task AddAsync(ProductBatch batch);
        Task<ProductBatch?> GetByIdAsync(int id);
    }
}
