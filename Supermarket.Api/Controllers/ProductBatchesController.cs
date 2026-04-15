using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.ProductBatch;
using Supermarket.Application.Interfaces;

namespace Supermarket.Api.Controllers;

[ApiController]
[Route("api/product-batches")]
public class ProductBatchesController : ControllerBase
{
    private readonly IProductBatchService _service;

    public ProductBatchesController(IProductBatchService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductBatchDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return Ok(result);
    }
}