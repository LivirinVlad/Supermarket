using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.Inventory.DTOs;
using Supermarket.Application.Inventory.Interfaces;
using Supermarket.Application.Inventory.Services;
using Supermarket.Application.Products.DTOs;

namespace Supermarket.API.Controllers;

[ApiController]
[Route("api/inventory")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _service;

    public InventoryController(IInventoryService service)
    {
        _service = service;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(AddStockDto dto)
    {
        await _service.AddStockAsync(dto.ProductId, dto.Quantity);
        return Ok();
    }

    [HttpPost("sell")]
    public async Task<IActionResult> Sell(SellProductDto dto)
    {
        await _service.SellAsync(dto.ProductId, dto.Quantity);
        return Ok();
    }

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetStock(Guid productId)
    {
        return Ok(await _service.GetStockAsync(productId));
    }
}