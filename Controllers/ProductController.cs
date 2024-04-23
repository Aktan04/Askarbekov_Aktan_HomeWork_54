using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecondProductShop.Models;
using SecondProductShop.Services;

namespace SecondProductShop.Controllers;

public class ProductController : Controller
{
    private ProductContext _context;
    private readonly IWebHostEnvironment _hostEnvironment;

    public ProductController(ProductContext context, IWebHostEnvironment hostEnvironment)
    {
        _context = context;
        _hostEnvironment = hostEnvironment;
    }

    
    public IActionResult Index(int? categoryId, int? brandId, ProductSortState sortState = ProductSortState.NameAsc)
    {
        ViewBag.Categories = _context.Categories.ToList();
        ViewBag.Brands = _context.Brands.ToList();
        IQueryable<Product> productsQuery = _context.Products.Include(p => p.Category).Include(p => p.Brand);
        ViewBag.NameSort = sortState == ProductSortState.NameAsc ? ProductSortState.NameDesc : ProductSortState.NameAsc;
        ViewBag.PriceSort = sortState == ProductSortState.PriceAsc ? ProductSortState.PriceDesc : ProductSortState.PriceAsc;
        ViewBag.DateSort = sortState == ProductSortState.DateAsc ? ProductSortState.DateDesc : ProductSortState.DateAsc;
        ViewBag.BrandSort = sortState == ProductSortState.BrandAsc ? ProductSortState.BrandDesc : ProductSortState.BrandAsc;
        ViewBag.CategorySort = sortState == ProductSortState.CategoryAsc ? ProductSortState.CategoryDesc : ProductSortState.CategoryAsc;
        switch (sortState)
        {
            case ProductSortState.NameAsc:
                productsQuery = productsQuery.OrderBy(p => p.Name);
                break;
            case ProductSortState.NameDesc:
                productsQuery = productsQuery.OrderByDescending(p => p.Name);
                break;
            case ProductSortState.PriceAsc:
                productsQuery = productsQuery.OrderBy(p => p.Price);
                break;
            case ProductSortState.PriceDesc:
                productsQuery = productsQuery.OrderByDescending(p => p.Price);
                break;
            case ProductSortState.DateAsc:
                productsQuery = productsQuery.OrderBy(p => p.DateOfCreation);
                break;
            case ProductSortState.DateDesc:
                productsQuery = productsQuery.OrderByDescending(p => p.DateOfCreation);
                break;
            case ProductSortState.BrandAsc:
                productsQuery = productsQuery.OrderBy(p => p.Brand.NameOfBrand);
                break;
            case ProductSortState.BrandDesc:
                productsQuery = productsQuery.OrderByDescending(p => p.Brand.NameOfBrand);
                break;
            case ProductSortState.CategoryAsc:
                productsQuery = productsQuery.OrderBy(p => p.Category.NameOfCategory);
                break;
            case ProductSortState.CategoryDesc:
                productsQuery = productsQuery.OrderByDescending(p => p.Category.NameOfCategory);
                break;
        }

        if (categoryId.HasValue)
        {
            productsQuery = productsQuery.Where(p => p.CategoryId == categoryId.Value);
        }

        if (brandId.HasValue)
        {
            productsQuery = productsQuery.Where(p => p.BrandId == brandId.Value);
        }

        var products = productsQuery.ToList();

        return View(products);
    }
}