using Ferreteria.Application.Services;
using Ferreteria.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController : Controller
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _service.GetProductsAsync();
        return Ok(products);
    }
    
    
    
    [Authorize] //Solo usuarios autenticados pueden crear productos
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] Product product)
    {
        await _service.AddProductAsync(product);
        return Ok(new { message = "Producto creado correctamente" });
    }
    
    
    
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        await _service.DeleteProductAsync(id);
        return Ok(new { message = "Producto eliminado correctamente" });
    }

    
    //Lo usamos para chekear la conexion a la DB
    // [HttpGet("check")]
    // public async Task<IActionResult> Check([FromServices] ApplicationDbContext context)
    // {
    //     try
    //     {
    //         var count = await context.Products.CountAsync();
    //         return Ok(new { ok = true, count });
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest(new { ok = false, error = ex.Message });
    //     }
    // }
}