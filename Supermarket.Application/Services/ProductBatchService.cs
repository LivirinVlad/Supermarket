using Supermarket.Application.DTOs.ProductBatch;
using Supermarket.Application.Interfaces;
using Supermarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Supermarket.Application.Services
{
    public class ProductBatchService : IProductBatchService
    {
        private readonly IProductBatchRepository _repo;

        public ProductBatchService(IProductBatchRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProductBatchDto> CreateAsync(CreateProductBatchDto dto)
        {
            var batch = new ProductBatch
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                ReceivedAt = dto.ReceivedAt,
                ExpirationDate = dto.ExpirationDate
            };

            await _repo.AddAsync(batch);

            return new ProductBatchDto
            {
                Id = batch.Id,
                ProductId = batch.ProductId,
                Quantity = batch.Quantity
            };
        }
    }
}
