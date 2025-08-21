using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vendra.Data;
using Vendra.Models;

namespace Vendra.Areas.Identity.Pages.Customer
{
    public class HomeModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public HomeModel(ApplicationDbContext context) => _context = context;

        public List<Product> Products { get; set; } = new();

        public void OnGet()
        {
            Products = _context.Products.ToList();
        }
    }
}
