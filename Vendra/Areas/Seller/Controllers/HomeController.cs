using Microsoft.AspNetCore.Mvc;

namespace Vendra.Areas.Seller.Controllers;

[Area("Seller")]
public class HomeController : Controller
{
    
    public IActionResult Index()
    {
        ViewData["Title"] = "Seller";
        return View();
    }
}
