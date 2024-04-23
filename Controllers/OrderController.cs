using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecondProductShop.Models;

namespace SecondProductShop.Controllers;

public class OrderController : Controller
{
    private readonly ProductContext _context;
    
    public OrderController(ProductContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        List<Order> orders = _context.Orders.Include(o => o.Product).ToList();
        return View(orders);
    }
    
    public IActionResult Create(int Id)
    {
        Product product = _context.Products.FirstOrDefault(p => p.Id == Id);
        return View(new Order() {Product = product});
    }

    [HttpPost]
    public IActionResult Create(Order order)
    {
        if (ModelState.IsValid)
        {
            _context.Add(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(order);
    }
}