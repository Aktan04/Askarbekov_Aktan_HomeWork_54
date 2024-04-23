using Microsoft.AspNetCore.Mvc;
using SecondProductShop.Models;

namespace SecondProductShop.Controllers;

public class CategoryController : Controller
{
    private ProductContext _context;

    public CategoryController(ProductContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var categories = _context.Categories.ToList();
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        
        if (_context.Categories.Any(b => b.NameOfCategory == category.NameOfCategory))
        {
            ModelState.AddModelError("NameOfCategory", "Категория с таким названием уже существует!");
            return View(category);
        }

        if (ModelState.IsValid)
        {
            _context.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(category);
    }
    
    public IActionResult Edit(int id)
    {
        var category = _context.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    [HttpPost]
    public IActionResult Edit(Category category, int id)
    {
        if (_context.Categories.Any(c => c.NameOfCategory == category.NameOfCategory && c.Id != id))
        {
            ModelState.AddModelError("NameOfCategory", "Категория с таким названием уже существует!");
            return View(category);
        }
        if (ModelState.IsValid)
        {
            _context.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        return View(category);
    }
    
    
    public IActionResult Delete(int id)
    {
        var category = _context.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        _context.Categories.Remove(category);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}