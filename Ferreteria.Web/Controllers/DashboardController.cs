using Ferreteria.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Web.Controllers;

[Authorize(Roles = "Admin")]
public class DashboardController : Controller
{
    private readonly ProductService _productService;

    public DashboardController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetProductsAsync();
        return View(products);
    }
}