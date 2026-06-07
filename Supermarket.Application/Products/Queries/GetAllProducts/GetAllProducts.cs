using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Supermarket.Application.Common.Interfaces;

namespace Supermarket.Application.Products.Queries.GetAllProducts;

public record GetAllProductsQuery
    : IRequest<List<ProductDto>>;

public class GetAllProductsQueryHandler
    : IRequestHandler<
        GetAllProductsQuery,
        List<ProductDto>>
{
    private readonly IAppDbContext _db;

    public GetAllProductsQueryHandler(
        IAppDbContext db)
    {
        _db = db;
    }

    public async Task<List<ProductDto>> Handle(
        GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        return await _db.Products
            .AsNoTracking()
            .Where(x => x.IsActive)
            .Select(x => new ProductDto(
                x.Id,
                x.Name,
                x.CurrentPrice))
            .ToListAsync(cancellationToken);
    }
}