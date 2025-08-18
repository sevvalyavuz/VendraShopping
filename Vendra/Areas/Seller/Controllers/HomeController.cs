using Microsoft.AspNetCore.Mvc;

namespace Vendra.Areas.Seller.Controllers;

public class HomeController : Controller
{
    [Area("Seller")]
    public IActionResult Index()
    {
        return View();
    }
}
