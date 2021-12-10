using Ilk_Mvc_Projesi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilk_Mvc_Projesi.Controllers
{
    public class ProductController : Controller
    {
        private readonly NorthwindContext _context;

        public ProductController(NorthwindContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var data = _context.Categories.Include(x => x.Products).OrderBy(x => x.CategoryName).ToList();
            var data = _context.Products.OrderBy(x => x.ProductName).ToList();
            return View(data);
        }
        public IActionResult Detail(int? id)
        {
            //var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            var product = _context.Products.OrderBy(x => x.ProductId == id);
            if (product == null)
                return RedirectToAction(nameof(Index));
            return View(product);
        }
    }
}
