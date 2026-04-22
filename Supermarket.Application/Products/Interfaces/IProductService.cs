using Supermarket.Application.Products.DTOs;
using Supermarket.Application.Products.Queries;
using Supermarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Products.Interfaces;

public interface IProductService
{
    Task<Guid> CreateAsync(CreateProductDto dto);
    Task UpdateAsync(Guid id, UpdateProductDto dto);
    Task DeleteAsync(Guid id);

    Task<Product?> GetByIdAsync(Guid id);
    Task<List<ProductWithStockDto>> GetAllWithStockAsync();

    Task SellAsync(SellProductDto dto);
}
