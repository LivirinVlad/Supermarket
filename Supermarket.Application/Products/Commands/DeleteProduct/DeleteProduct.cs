using MediatR;
using Microsoft.EntityFrameworkCore;
using Supermarket.Application.Common.Exceptions;
using Supermarket.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(Guid Id)
    : IRequest;

public class DeleteProductCommandHandler
    : IRequestHandler<DeleteProductCommand>
{
    private readonly IAppDbContext _db;

    public DeleteProductCommandHandler(
        IAppDbContext db)
    {
        _db = db;
    }

    public async Task Handle(
        DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _db.Products
            .FirstOrDefaultAsync(
                x => x.Id == request.Id,
                cancellationToken);

        if (product is null)
            throw new NotFoundException("Product not found");

        product.Deactivate();

        await _db.SaveChangesAsync(
            cancellationToken);
    }
}