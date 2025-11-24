using Ferreteria.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Web.Controllers;

public class SalesController : Controller
{
    private readonly ISaleRepository _saleRepository;

    public SalesController(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    // TRAER VENTASSS
    public async Task<IActionResult> Index()
    {
        var sales = await _saleRepository.GetAllSalesAsync();
        return View(sales);
    }

}