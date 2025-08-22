using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vendra.Data;
using Vendra.Models;

namespace Vendra.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize] // sadece giriş yapmış kullanıcılar
    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public DashboardController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // Ana sayfa (dashboard)
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.Type != "Seller")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var products = _context.Products.ToList();

            ViewBag.TotalProducts = products.Count;
            ViewBag.TotalStock = products.Sum(p => p.Stock);
            ViewBag.TotalValue = products.Sum(p => p.Price * p.Stock);

            return View(products);
        }

        // Ürün ekleme sayfası GET
        public async Task<IActionResult> AddProduct()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.Type != "Seller")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }

        // Ürün ekleme sayfası POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.Type != "Seller")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                TempData["Success"] = "Ürün başarıyla eklendi!";
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // Ürün sil
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.Type != "Seller")
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
