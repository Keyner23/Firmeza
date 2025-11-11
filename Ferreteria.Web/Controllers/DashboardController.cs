using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Web.Controllers;

[Authorize(Roles = "Admin")]
public class DashboardController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}