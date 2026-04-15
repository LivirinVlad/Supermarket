using Microsoft.EntityFrameworkCore;
using Supermarket.Application.Interfaces;
using Supermarket.Domain.Entities;
using Supermarket.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Infrastructure.Repositories
{
    public class ProductBatchRepository : IProductBatchRepository
    {
        private readonly AppDbContext _context;

        public ProductBatchRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProductBatch batch)
        {
            _context.ProductBatches.Add(batch);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductBatch?> GetByIdAsync(int id)
        {
            return await _context.ProductBatches
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
