using MediatR;
using Supermarket.Application.Common.Interfaces;
using Supermarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    decimal Price,
    string? Description)
    : IRequest<Guid>;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IAppDbContext _db;

    public CreateProductCommandHandler(IAppDbContext db)
    {
        _db = db;
    }

    public async Task<Guid> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = new Product(
            request.Name,
            request.Price,
            request.Description);

        _db.Products.Add(product);

        await _db.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}

