using Microsoft.AspNetCore.Mvc;
using Vendra.Data;

namespace Vendra.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{

    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Admin/Index (Admin paneli)
    public IActionResult Index()
    {
        return View(); // Admin paneli sayfası
    }

    public ActionResult Dashboard()
    {
        return RedirectToAction("Index", "Brand");
    }

}
