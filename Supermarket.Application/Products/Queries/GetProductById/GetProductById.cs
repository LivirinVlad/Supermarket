using MediatR;
using Microsoft.EntityFrameworkCore;
using Supermarket.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Products.Queries.GetProductById;

public record GetProductByIdQuery(Guid Id)
    : IRequest<ProductDto?>;

public class GetProductByIdQueryHandler
    : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IAppDbContext _db;

    public GetProductByIdQueryHandler(
        IAppDbContext db)
    {
        _db = db;
    }

    public async Task<ProductDto?> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _db.Products
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .Select(x => new ProductDto
            (
                x.Id,
                x.Name,
                x.CurrentPrice
            ))
            .FirstOrDefaultAsync(cancellationToken);
    }
}