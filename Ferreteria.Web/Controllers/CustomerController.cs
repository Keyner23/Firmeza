using Ferreteria.Application.Services;
using Ferreteria.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Web.Controllers;

public class CustomerController : Controller
{
    private readonly CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<IActionResult> IndexCustomer()
    {
        var customers = await _customerService.GetCustomersAsync();
        return View(customers);
    }

    [HttpGet]
    public IActionResult CreateCustomer() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Customer customer)
    {
        if (ModelState.IsValid)
        {
            await _customerService.AddCustomerAsync(customer);
            return RedirectToAction("IndexCustomer");
        }
        return View(CreateCustomer());
    }

    // [HttpPost]
    // public async Task<IActionResult> Delete(Guid id)
    // {
    //     await _customerService.DeleteCustomerAsync(id);
    //     return RedirectToAction(nameof(Index));
    // }
}