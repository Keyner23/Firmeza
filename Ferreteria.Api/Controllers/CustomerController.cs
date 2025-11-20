using Ferreteria.Application.Services;
using Ferreteria.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : Controller
{
    private readonly CustomerService _service;

    public CustomerController(CustomerService service)
    {
        _service = service;
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetCustomer()
    {
        var customer = await _service.GetCustomersAsync();
        return Ok(customer);
    }
    
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
    {
        await _service.AddCustomerAsync(customer);
        return Ok(new { message = "Cliente creado correctamente" });
    }
    
    
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        await _service.DeleteCustomerAsync(id);
        return Ok(new { message = "Cliente eliminado correctamente" });
    }
}