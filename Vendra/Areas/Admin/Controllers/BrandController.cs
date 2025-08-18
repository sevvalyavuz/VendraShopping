using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vendra.Data;
using Vendra.Models;

namespace Vendra.Areas.Admin.Controllers;

[Area("Admin")]
public class BrandController : Controller
{
    private readonly ApplicationDbContext _context;

    public BrandController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Listeleme
    public IActionResult Index()
    {
        var brands = _context.Brands.ToList();
        return View(brands);
    }

    // GET: Yeni Marka Ekle
    public IActionResult Create()
    {
        return View();
    }

    // POST: Yeni Marka Ekle
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Brand brand)
    {
        if (ModelState.IsValid)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(brand);
    }

    // GET: Düzenle
    public IActionResult Edit(int id)
    {
        var brand = _context.Brands.Find(id);
        if (brand == null) return NotFound();
        return View(brand);
    }

    // POST: Düzenle
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Brand brand)
    {
        if (ModelState.IsValid)
        {
            _context.Entry(brand).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(brand);
    }

    // GET: Sil
    public IActionResult Delete(int id)
    {
        var brand = _context.Brands.Find(id);
        if (brand == null) return NotFound();
        return View(brand);
    }

    // POST: Sil
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var brand = _context.Brands.Find(id);
        _context.Brands.Remove(brand);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
