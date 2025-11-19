using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Api.Controllers;

public class CustomerController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}