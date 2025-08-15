using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vendra.Data;
using Vendra.Models;

namespace Vendra.Areas.Seller.Pages
{
    [Authorize] // giriþ zorunlu
    public class HomeModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<Product> MyProducts { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToPage("/Account/Login", new { area = "Identity" });

            // Sadece satýcýlar burayý görebilsin
            if (user.Type != UserType.Seller)
                return RedirectToPage("/Customer/Home");

            MyProducts = _context.Products.Where(p => p.SellerId == user.Id).ToList();
            return Page();
        }
    }
}
