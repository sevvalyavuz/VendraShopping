using Microsoft.AspNetCore.Mvc;
using Vendra.Data;
using Vendra.Models;

namespace Vendra.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Ürün ekleme formunu aç
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Ürün ekleme işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                TempData["Success"] = "Ürün başarıyla eklendi!";
                return RedirectToAction("Create");
            }
            return View(product);
        }
    }
}

