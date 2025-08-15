using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vendra.Data;
using Vendra.Models;

namespace Vendra.Areas.Seller.Pages
{
    [Authorize]
    public class AddProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AddProductModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Product Product { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = await _userManager.GetUserAsync(User);
            Product.SellerId = user.Id;

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Seller/Home");
        }
    }
}
