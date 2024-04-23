using Microsoft.AspNetCore.Mvc;
using SecondProductShop.Models;

namespace SecondProductShop.Controllers;

public class BrandController : Controller
{
    private ProductContext _context;

    public BrandController(ProductContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        var brands = _context.Brands.ToList();
        return View(brands);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Brand brand)
    {
        if (_context.Brands.Any(b => b.NameOfBrand== brand.NameOfBrand))
        {
            ModelState.AddModelError("NameOfBrand", "Бренд с таким названием уже существует!");
            return View(brand);
        }

        if (ModelState.IsValid)
        {
            _context.Add(brand);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(brand);
    }
    
    public IActionResult Edit(int id)
    {
        var brand = _context.Brands.Find(id);
        if (brand == null)
        {
            return NotFound();
        }
        return View(brand);
    }

    [HttpPost]
    public IActionResult Edit(Brand brand, int id)
    {
        if (_context.Brands.Any(b => b.NameOfBrand == brand.NameOfBrand && b.Id != id))
        {
            ModelState.AddModelError("NameOfBrand", "Бренд с таким названием уже существует!");
            return View(brand);
        }
        if (ModelState.IsValid)
        {
            _context.Update(brand);
            _context.SaveChanges();
            return RedirectToAction("Index", "Brand");
        }
        return View(brand);
    }
    
    public IActionResult Delete(int id)
    {
        var brand = _context.Brands.Find(id);
        if (brand == null)
        {
            return NotFound();
        }
        _context.Brands.Remove(brand);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}