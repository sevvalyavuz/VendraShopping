using Microsoft.AspNetCore.Mvc;
using Vendra.Models;
using Vendra.Data;

namespace Vendra.Controllers
{
    public class AdminController : Controller
    {
        private readonly string testUsername = "admin";
        private readonly string testPassword = "12345";

        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: /Admin/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Admin/Login
        [HttpPost]
        public IActionResult Login(Admin user)
        {
            if (user.Username == testUsername && user.Password == testPassword)
            {
                // Session kaydet
                HttpContext.Session.SetString("IsAdmin", "true");
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Hatalı kullanıcı adı veya şifre!";
                return View();
            }
        }

        // GET: /Admin/Index (Admin paneli)
        public IActionResult Index()
        {
            var isAdmin = HttpContext.Session.GetString("IsAdmin");
            if (isAdmin == null)
            {
                return RedirectToAction("Login");
            }

            return View(); // Admin paneli sayfası
        }

        // GET: /Admin/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult AddProduct()
        {
            var isAdmin = HttpContext.Session.GetString("IsAdmin");
            if (isAdmin == null) return RedirectToAction("Login");
            return View();
        }

        // POST: /Admin/AddProduct
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var isAdmin = HttpContext.Session.GetString("IsAdmin");
            if (isAdmin == null) return RedirectToAction("Login");

            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Admin paneli
            }
            return View(product);
        }
    }
}
