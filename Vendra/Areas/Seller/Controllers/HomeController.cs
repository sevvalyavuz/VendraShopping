using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Vendra.Models;

namespace Vendra.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null && user.Type == "Seller")
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Seller" });
            }

            // Eğer kullanıcı Seller değilse ana sayfaya dön
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
