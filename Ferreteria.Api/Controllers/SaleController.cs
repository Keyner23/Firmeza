using Ferreteria.Application.Dtos.Sale;
using Ferreteria.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SaleController : Controller
{
    private readonly SaleService _saleService;

    public SaleController(SaleService saleService)
    {
        _saleService = saleService;
    }

    // Crear venta
    [HttpPost]
    public async Task<IActionResult> CreateSale(CreateSaleDto dto)
    {
        var result = await _saleService.CreateSaleAsync(dto);
        return Ok(result);
    }
    
    [Authorize]
    // Obtener venta por ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSale(Guid id)
    {
        var sale = await _saleService.GetSaleAsync(id);
        if (sale == null) return NotFound();

        return Ok(sale);
    }
    
    [Authorize]
    // Obtener todas las ventas
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sales = await _saleService.GetAllSalesAsync();

        //  mapearlas a DTOs
        var dtoList = sales.Select(s => new SaleResponseDto
        {
            Id = s.Id,
            SaleDate = s.SaleDate,
            Subtotal = s.Subtotal,
            IVA = s.IVA,
            Total = s.Total,

            Customer = new CustomerSimpleDto
            {
                Name = s.Customer?.Name,
                Document = s.Customer?.Document ?? 0
            },

            Details = s.Details.Select(d => new SaleDetailResponseDto
            {
                ProductId = d.ProductId,
                ProductName = d.Product?.name,
                Quantity = d.Quantity,
                UnitPrice = d.UnitPrice ?? 0,
                Subtotal = d.Total
            }).ToList()

        }).ToList();

        return Ok(dtoList);
    }
}