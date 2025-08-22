using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vendra.Data;
using Vendra.Models;
using System.Threading.Tasks;

namespace Vendra.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize] // sadece giriş yapmış kullanıcılar
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Ürün ekleme formunu aç
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.Type != "Seller")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }

        // Ürün ekleme işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.Type != "Seller")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            if (ModelState.IsValid)
            {
                product.SellerId = user.Id;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Ürün başarıyla eklendi!";
                return RedirectToAction("Create");
            }
            return View(product);
        }
    }
}
