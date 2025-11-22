using Ferreteria.Application.Dtos.Sale;
using Ferreteria.Application.Interfaces;
using Ferreteria.Application.Services;
using Ferreteria.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaleController : Controller
{
    private readonly SaleService _saleService;

    public SaleController(SaleService saleService)
    {
        _saleService = saleService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleDto dto)
    {
        var sale = await _saleService.CreateSaleAsync(dto);
        return Ok(sale);
    }


    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetSale(Guid id)
    {
        var sale = await _saleService.GetSaleAsync(id);
        if (sale is null)
            return NotFound();

        return Ok(sale);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _saleService.GetAllSalesAsync());
    }
}