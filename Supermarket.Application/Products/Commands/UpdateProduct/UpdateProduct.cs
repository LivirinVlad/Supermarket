using MediatR;
using Supermarket.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.Application.Common.Exceptions;

namespace Supermarket.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    decimal Price,
    string? Description)
    : IRequest;

public class UpdateProductCommandHandler
    : IRequestHandler<UpdateProductCommand>
{
    private readonly IAppDbContext _db;

    public UpdateProductCommandHandler(
        IAppDbContext db)
    {
        _db = db;
    }

    public async Task Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _db.Products
            .FirstOrDefaultAsync(
                x => x.Id == request.Id,
                cancellationToken);

        if (product is null)
            throw new NotFoundException("Product not found");

        product.Update(
            request.Name,
            request.Price,
            request.Description);

        await _db.SaveChangesAsync(
            cancellationToken);
    }
}
